using BenchmarkDotNet.Attributes;
using System;

namespace PerformanceBenchmark.Tests
{
    public class MathPowVsCodePow
    {
        [Params(1000)]
        public double Number { get; set; }

        [Benchmark]
        public double NumberCodePow()
        {
            return this.Number * this.Number;
        }

        [Benchmark]
        public double NumberMathPow()
        {
            return Math.Pow(this.Number, 2);
        }
    }
}
