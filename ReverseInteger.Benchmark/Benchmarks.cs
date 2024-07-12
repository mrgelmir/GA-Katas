using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace ReverseInteger.Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class Benchmarks
    {
        [Params(/* 1, 10, 100, 1000, */ 10000, 147483647)]
        public int Value { get; set; }

        [Benchmark]
        public void CheckedModulo()
        {
            int result = IntExtensions.CheckedModulo(Value);
        }

        [Benchmark(Baseline = true)]
        public void StringRecurse()
        {
            int result = IntExtensions.StringReverse(Value);
        }
    }
}
