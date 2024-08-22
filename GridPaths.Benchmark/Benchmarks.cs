using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace GridPaths.Benchmark
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        const int iterations = 100;

        [Benchmark(Baseline = true)]
        public void Grid()
        {
            for (int i = 1; i <= iterations; ++i)
                Travel.GetPathCount_Grid(i, i);
        }

        [Benchmark]
        public void Array()
        {
            for (int i = 1; i <= iterations; ++i)
                Travel.GetPathCount_SingleArray(i, i);
        }

        [Benchmark(Description = "git-amend")]
        public void GitAmend()
        {
            for (int i = 1; i <= iterations; ++i)
                Travel.CountUniquePaths(i, i);
        }
    }
}