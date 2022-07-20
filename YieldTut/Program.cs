using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
namespace YieldTut
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProcessPeople();
           
            var summary = BenchmarkRunner.Run<YieldBenchmarks>();
        

        }
    }
}
