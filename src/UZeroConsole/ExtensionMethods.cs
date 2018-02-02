using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UZeroConsole.Helpers;

namespace UZeroConsole
{
    public static partial class ExtensionMethods
    {
        public const string ExceptionLogPrefix = "ErrorLog-";

        public static T AddLoggedData<T>(this T ex, string key, string value) where T : Exception
        {
            ex.Data[ExceptionLogPrefix + key] = value;
            return ex;
        }


        public static string ToHumanReadableSize(this long size) => string.Format(new FileSizeFormatProvider(), "{0:fs}", size);

        public static string ToComma(this int? number, string valueIfZero = null) => number.HasValue ? ToComma(number.Value, valueIfZero) : "";

        public static string ToComma(this int number, string valueIfZero = null) => number == 0 && valueIfZero != null ? valueIfZero : number.ToString("n0");

        public static string ToComma(this long? number, string valueIfZero = null) => number.HasValue ? ToComma(number.Value, valueIfZero) : "";

        public static string ToComma(this long number, string valueIfZero = null) => number == 0 && valueIfZero != null ? valueIfZero : number.ToString("n0");

        /// <summary>
        /// Gets the current data via <paramref name="lookup"/>. 
        /// When data is missing or stale (older than <paramref name="duration"/>), a background refresh is 
        /// initiated on stale fetches still within <paramref name="staleDuration"/> after <paramref name="duration"/>.
        /// </summary>
        /// <typeparam name="T">The type of value to get.</typeparam>
        /// <param name="cache">The cache to use.</param>
        /// <param name="key">The cache key to use.</param>
        /// <param name="lookup">Refreshes the data if necessary, passing the old data if we have it.</param>
        /// <param name="duration">The time to cache the data, before it's considered stale.</param>
        /// <param name="staleDuration">The time available to serve stale data, while a background fetch is performed.</param>
        public static T GetSet<T>(this LocalCache cache, string key, Func<T, MicroContext, T> lookup, TimeSpan duration, TimeSpan staleDuration)
            where T : class
        {
            var possiblyStale = cache.Get<GetSetWrapper<T>>(key);
            var localLockName = key;
            var nullLoadLock = _getSetNullLocks.AddOrUpdate(localLockName, k => new object(), (k, old) => old);
            if (possiblyStale == null)
            {
                // We can't prevent multiple web server's from running this (well, we can but its probably overkill) but we can
                //   at least stop the query from running multiple times on *this* web server
                lock (nullLoadLock)
                {
                    possiblyStale = cache.Get<GetSetWrapper<T>>(key);

                    if (possiblyStale == null)
                    {
                        T data;
                        using (var ctx = new MicroContext())
                        {
                            data = lookup(null, ctx);
                        }
                        possiblyStale = new GetSetWrapper<T>
                        {
                            Data = data,
                            StaleAfter = DateTime.Now + duration
                        };

                        cache.Set(key, possiblyStale, duration + staleDuration);
                        Interlocked.Increment(ref totalGetSetSync);
                    }
                }
            }

            if (possiblyStale.StaleAfter > DateTime.Now) return possiblyStale.Data;

            bool gotCompeteLock = false;
            if (Monitor.TryEnter(nullLoadLock, 0))
            {   // it isn't actively being refreshed; we'll check for a mutex on the cache
                try
                {
                    gotCompeteLock = GotCompeteLock(cache, key);
                }
                finally
                {
                    Monitor.Exit(nullLoadLock);
                }
            }

            if (gotCompeteLock)
            {
                var old = possiblyStale.Data;
                var task = new Task(delegate
                {
                    lock (nullLoadLock) // holding this lock allows us to locally short-circuit all the other threads that come asking
                    {
                        try
                        {
                            var updated = new GetSetWrapper<T>();
                            using (var ctx = new MicroContext())
                            {
                                updated.Data = lookup(old, ctx);
                                updated.StaleAfter = DateTime.Now + duration;
                            }
                            cache.Remove(key);
                            cache.Set(key, updated, duration + staleDuration);
                        }
                        finally
                        {
                            ReleaseCompeteLock(cache, key);
                        }
                    }
                });
                task.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Interlocked.Increment(ref totalGetSetAsyncError);
                        Current.LogException(t.Exception);
                    }
                    else
                    {
                        Interlocked.Increment(ref totalGetSetAsyncSuccess);
                    }
                });
                task.Start();
            }

            return possiblyStale.Data;
        }

        private static bool GotCompeteLock(LocalCache cache, string key)
        {
            while (true)
            {
                var competeKey = key + "-cload";
                if (cache.SetNXSync(competeKey, DateTime.Now))
                {
                    // Got it!
                    return true;
                }

                var x = cache.Get<DateTime>(competeKey);
                // Did somebody abandoned the lock?
                if (DateTime.Now - x > TimeSpan.FromMinutes(5))
                {
                    // Yep, clear it and try again
                    cache.Remove(competeKey);
                    continue;
                }
                // Lost the lock competition
                return false;
            }

        }

        private static int totalGetSetSync, totalGetSetAsyncSuccess, totalGetSetAsyncError;
        private static readonly ConcurrentDictionary<string, object> _getSetNullLocks = new ConcurrentDictionary<string, object>();
        // called by a winner of CompeteToLoad, to make it so the next person to call CompeteToLoad will get true
        private static void ReleaseCompeteLock(LocalCache cache, string key) => cache.Remove(key + "-cload");
        internal class GetSetWrapper<T>
        {
            public DateTime StaleAfter { get; set; }
            public T Data { get; set; }
        }

        public class MicroContext : IDisposable
        {
            void IDisposable.Dispose() { }
        }


    }

    //Credits to http://stackoverflow.com/questions/128618/c-file-size-format-provider/3968504#3968504
    public static class IntToBytesExtension
    {
        private const int DefaultPrecision = 2;
        private static readonly IList<string> Units = new List<string> { "", "K", "M", "G", "T" };

        /// <summary>
        /// Formats the value as a filesize in bytes (KB, MB, etc.)
        /// </summary>
        /// <param name="bytes">This value.</param>
        /// <param name="unit">Unit to use in the fomat, defaults to B for bytes</param>
        /// <param name="precision">How much precision to show, defaults to 2</param>
        /// <param name="zero">String to show if the value is 0</param>
        /// <returns>Filesize and quantifier formatted as a string.</returns>
        public static string ToSize(this int bytes, string unit = "B", int precision = DefaultPrecision, string zero = "n/a") =>
            ToSize((double)bytes, unit, precision, zero: zero);

        /// <summary>
        /// Formats the value as a filesize in bytes (KB, MB, etc.)
        /// </summary>
        /// <param name="bytes">This value.</param>
        /// <param name="unit">Unit to use in the fomat, defaults to B for bytes</param>
        /// <param name="precision">How much precision to show, defaults to 2</param>
        /// <param name="zero">String to show if the value is 0</param>
        /// <returns>Filesize and quantifier formatted as a string.</returns>
        public static string ToSize(this long bytes, string unit = "B", int precision = DefaultPrecision, string zero = "n/a") =>
            ToSize((double)bytes, unit, precision, zero: zero);

        /// <summary>
        /// Formats the value as a filesize in bytes (KB, MB, etc.)
        /// </summary>
        /// <param name="bytes">This value.</param>
        /// <param name="unit">Unit to use in the fomat, defaults to B for bytes</param>
        /// <param name="precision">How much precision to show, defaults to 2</param>
        /// <param name="zero">String to show if the value is 0</param>
        /// <returns>Filesize and quantifier formatted as a string.</returns>
        public static string ToSize(this float bytes, string unit = "B", int precision = DefaultPrecision, string zero = "n/a") =>
            ToSize((double)bytes, unit, precision, zero: zero);

        /// <summary>
        /// Formats the value as a filesize in bytes (KB, MB, etc.)
        /// </summary>
        /// <param name="bytes">This value.</param>
        /// <param name="unit">Unit to use in the fomat, defaults to B for bytes</param>
        /// <param name="precision">How much precision to show, defaults to 2</param>
        /// <param name="zero">String to show if the value is 0</param>
        /// <returns>Filesize and quantifier formatted as a string.</returns>
        public static string ToSize(this decimal bytes, string unit = "B", int precision = DefaultPrecision, string zero = "n/a") =>
            ToSize((double)bytes, unit, precision, zero: zero);

        /// <summary>
        /// Formats the value as a filesize in bytes (KB, MB, etc.)
        /// </summary>
        /// <param name="bytes">This value.</param>
        /// <param name="unit">Unit to use in the fomat, defaults to B for bytes</param>
        /// <param name="precision">How much precision to show, defaults to 2</param>
        /// <param name="kiloSize">1k size, usually 1024 or 1000 depending on context</param>
        /// <param name="zero">String to show if the value is 0</param>
        /// <returns>Filesize and quantifier formatted as a string.</returns>
        public static string ToSize(this double bytes, string unit = "B", int precision = DefaultPrecision, int kiloSize = 1024, string zero = "n/a")
        {
            if (bytes < 1) return zero;
            var pow = Math.Floor((bytes > 0 ? Math.Log(bytes) : 0) / Math.Log(kiloSize));
            pow = Math.Min(pow, Units.Count - 1);
            var value = bytes / Math.Pow(kiloSize, pow);
            return value.ToString(pow == 0 ? "F0" : "F" + precision.ToString()) + " " + Units[(int)pow] + unit;
        }

        internal static StringBuilder Pipend(this StringBuilder sb, string value) => sb.Append("|").Append(value);
    }
}
