using BenchmarkDotNet.Running;
using PerformanceBenchmark.Tests;
using System;

namespace PerformanceBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<MathPowVsCodePow>();
            //var summary = BenchmarkRunner.Run<ForForeachOnArrayListIenumerable>();
            // var summary = BenchmarkRunner.Run<SingleVsFirst>();
            var summary = BenchmarkRunner.Run<ConcatStringBuilderVsConcatList>();

            Console.Read();
        }
    }
}
