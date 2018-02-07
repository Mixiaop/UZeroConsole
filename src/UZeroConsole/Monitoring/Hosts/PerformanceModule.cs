using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace UZeroConsole.Monitoring
{
    public class PerformanceModule
    {
        static PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        static PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        static PerformanceCounter webService_ConnectionsCounter = new PerformanceCounter("Web Service", "Current Connections", "_Total");

        static PerformanceModule()
        {
        }

        public static HostInfo Current()
        {
            HostInfo info = new HostInfo();
            //cpu
            info.CPUUsagePercent = (float)Math.Round(cpuCounter.NextValue(), 2, MidpointRounding.AwayFromZero);
            //memory
            info.RAMUsedPercent = (float)Math.Round(((GetTotalRAMInMB() - ramCounter.NextValue()) / GetTotalRAMInMB() * 100), 2, MidpointRounding.AwayFromZero);
            //disk
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    var d = new DiskInfo();
                    d.Name = drive.Name;
                    d.TotalSize = drive.TotalSize;
                    d.FreeTotalSpace = drive.TotalFreeSpace;
                    info.Disks.Add(d);
                }
            }

            info.WebService_CurrentConnections = webService_ConnectionsCounter.NextValue();
            return info;
        }

        #region Memory
        /// <summary>
        /// returns in MBytes
        /// </summary>
        /// <returns></returns>
        private static float GetTotalRAMInMB()
        {
            ulong installedMemory = 0;
            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(memStatus))
            {
                installedMemory = memStatus.ullTotalPhys;
            }
            return (installedMemory / 1000000);
        }

        /// <summary>
        /// returns in Bytes
        /// </summary>
        /// <returns></returns>
        private static float GetTotalRAMInBytes()
        {
            ulong installedMemory = 0;
            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(memStatus))
            {
                installedMemory = memStatus.ullTotalPhys;
            }
            return installedMemory;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private class MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
            public MEMORYSTATUSEX()
            {
                this.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            }
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);
        #endregion
    }

    public class HostInfo
    {
        public float CPUUsagePercent { get; set; }
        public float RAMUsedPercent { get; set; }

        public List<DiskInfo> Disks { get; } = new List<DiskInfo>();

        public float WebService_CurrentConnections { get; set; }
    }

    public class DiskInfo
    {
        public string Name { get; set; }
        public double TotalSize { get; set; }
        public double FreeTotalSpace { get; set; }
        public double UsedSpace { get { return TotalSize - FreeTotalSpace; } }
    }
}
