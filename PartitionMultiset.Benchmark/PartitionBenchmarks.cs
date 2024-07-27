using System;
using System.Collections.Generic;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace PartitionMultiset.Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class PartitionBenchmarks
    {
        
        public static IEnumerable<List<int>> ValuesForInput() =>
        [
            [15, 5, 20, 10, 35, 15, 10],
            [15, 5, 20, 10, 35],
            [1, 5, 11, 5]
        ];

        [ParamsSource(nameof(ValuesForInput))]
        public List<int> Input;

        [Benchmark(Baseline = true)]
        public void BitArray()
        {
            Multiset.PartitionWithBitArray(Input);
        }

        [Benchmark]
        public void DynamicProgramming()
        {
            Multiset.PartitionWithDP(Input);
        }
    }
}