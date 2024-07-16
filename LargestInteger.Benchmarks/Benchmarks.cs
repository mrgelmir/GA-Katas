using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace LargestInteger.Benchmarks
{
    [MemoryDiagnoser]
    public class LargestInteger
    {
        readonly int[][] inputs = [
            [7, 76],
            [3, 13],
            [10, 7, 76, 415],
            [14, 74, 8, 3, 64, 7]];

        [Benchmark(Baseline = true)]
        public void StringImplementation1()
        {
            for (int i = 0; i < inputs.Length; ++i)
                IntExtensions.StringImplementation1(inputs[i]);
        }

        [Benchmark]
        public void StringImplementation2()
        {
            for (int i = 0; i < inputs.Length; ++i)
                IntExtensions.StringImplementation2(inputs[i]);
        }

        [Benchmark]
        public void ModuloImplementation()
        {
            for (int i = 0; i < inputs.Length; ++i)
                IntExtensions.ModuloImplementation(inputs[i]);
        }

        [Benchmark]
        public void ArrayImplementation()
        {
            for (int i = 0; i < inputs.Length; ++i)
                IntExtensions.ArrayImplementation(inputs[i]);
        }

        [Benchmark]
        public void ArrayImplementation_PrecomputedValues()
        {
            for (int i = 0; i < inputs.Length; ++i)
                IntExtensions.ArrayImplementation_PrecomputedValues(inputs[i]);
        }
    }
}
