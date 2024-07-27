using BenchmarkDotNet.Attributes;

namespace Palindrome.Benchmark
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        private const string Palindrome = "A man, a plan, a canal, Panama";

        [Benchmark(Baseline = true)]
        public void Cursor()
        {
            Palindrome.IsPalindrome();
        }

        [Benchmark]
        public void Smack()
        {
            StringExtensions.IsPalindrome_smack(Palindrome);
        }

        [Benchmark]
        public void ChatGPT()
        {
            StringExtensions.IsPalindrome_ChatGPT(Palindrome);
        }

        [Benchmark]
        public void ChatGPT2()
        {
            StringExtensions.IsPalindrome_ChatGPT2(Palindrome);
        }
    }
}