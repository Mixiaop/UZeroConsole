﻿using System.Reflection;
using U.UPrimes;

namespace UZeroConsole.Client
{
    public class UZeroConsoleClientUPrime : U.UPrimes.UPrime
    {
        public override void Initialize()
        {
            Engine.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
