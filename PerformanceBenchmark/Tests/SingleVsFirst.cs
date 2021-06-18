using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceBenchmark.Tests
{
    public class SingleVsFirst
    {
        public Random Random;

        public int Length = 10000;

        public List<string> List;
        public List<string> Targets => new List<string> { "StartTarget", "MiddleTarget", "EndTarget" };


        [ParamsSource(nameof(Targets))]
        public string Target { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            Random = new Random();

            List = new List<string>();
            // Popula a fila
            for (int i = 0; i < Length; i++)
            {
                var number = Random.Next(0, 100);
                List.Add(number.ToString());
            }

            // Insere um alvo no inicio, meio e fim
            List.Insert(0, Targets[0]);
            List.Insert(Length / 2, Targets[1]);
            List.Insert(List.Count - 1, Targets[2]);
        }

        [Benchmark]
        public string Single() => List.SingleOrDefault(x => x == Target);

        [Benchmark]
        public string First() => List.FirstOrDefault(x => x == Target);

        [Benchmark]
        public string WhereAndFirst() => List.Where(x => x == Target).First();

    }
}
