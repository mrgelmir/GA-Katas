using Fibonnaci;

namespace Fibonacci.Tests;

public class SequenceTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    public void FibonacciRecursive_Validation(int input, int expected)
    {
        Assert.Equal(expected, Sequence.FibonacciRecursive(input));
    }

     [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    public void FibonacciLinear_Validation(int input, int expected)
    {
        Assert.Equal(expected, Sequence.FibonacciLinear(input));
    }
}