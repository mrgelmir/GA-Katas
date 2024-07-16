using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace LargestInteger.Benchmarks
{
    [MemoryDiagnoser]
    public class LargestInteger
    {
        readonly int[] input = [10, 7, 76, 415];

        [Benchmark(Baseline = true)]
        public void StringImplementation1()
        {
            IntExtensions.StringImplementation1(input);
        }

        [Benchmark]
        public void StringImplementation2()
        {
            IntExtensions.StringImplementation2(input);
        }

        [Benchmark(Baseline = true)]
        public void ModuloImplementation()
        {
            IntExtensions.ModuloImplementation(input);
        }
    }
}
