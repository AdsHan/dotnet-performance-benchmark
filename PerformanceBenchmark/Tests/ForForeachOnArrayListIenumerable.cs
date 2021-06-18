using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceBenchmark.Tests
{
    public class ForForeachOnArrayListIenumerable
    {
        public Random Random;

        // Tamanho das filas
        [Params(1000)]
        public int Length { get; set; }

        // Filas para teste
        public int[] Array;
        public IEnumerable<int> Enumerable;
        public List<int> List;

        [GlobalSetup]
        public void Setup()
        {
            Random = new Random();

            // Cria as filas
            Array = new int[Length];
            List = new List<int>();
            Enumerable = List;

            // Popula as filas
            for (int i = 0; i < Length; i++)
            {
                var number = Random.Next(0, 100);
                Array[i] = number;
                List.Add(number);
            }

        }

        [Benchmark]
        public void ForOnArray()
        {
            var sum = 0;
            for (int i = 0; i < Length; i++)
            {
                sum += Array[i];
            }
        }

        [Benchmark]
        public void ForeachOnArray()
        {
            var sum = 0;
            foreach (var number in Array)
            {
                sum += number;
            }
        }

        [Benchmark]
        public void ForOnList()
        {
            var sum = 0;
            for (int i = 0; i < Length; i++)
            {
                sum += List[i];
            }
        }

        [Benchmark]
        public void ForeachOnList()
        {
            var sum = 0;
            foreach (var number in List)
            {
                sum += number;
            }
        }

        [Benchmark]
        public void ForOnEnumerable()
        {
            var sum = 0;
            for (int i = 0; i < Length; i++)
            {
                sum += Enumerable.Skip(i).First();
                //sum += Enumerable.ElementAt[i];
            }
        }

        [Benchmark]
        public void ForeachOnEnumerable()
        {
            var sum = 0;
            foreach (var number in Enumerable)
            {
                sum += number;
            }
        }


    }
}
