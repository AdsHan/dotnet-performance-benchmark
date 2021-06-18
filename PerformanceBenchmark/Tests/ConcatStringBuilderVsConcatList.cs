using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Text;

namespace PerformanceBenchmark.Tests
{
    public class ConcatStringBuilderVsConcatList
    {

        // Tamanho das filas
        [Params(1000000)]
        public int Length { get; set; }


        [Benchmark]
        public string ConcatList()
        {
            var list = new List<string>();

            for (int i = 0; i < Length; i++)
            {
                list.Add("Inicio!" + i);
            }
            return list.ToString();
        }

        [Benchmark]
        public string ConcatStringBuilder()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                sb.Append("Inicio!" + i);
            }
            return sb.ToString();
        }

    }
}
