using ValidParentheses;

namespace ValidParentheses.Tests;

public class RemoverTests
{
    [Fact]
    public void EmptyString_Count_ReturnsZero()
    {
        int count = Remover.Count("");

        Assert.Equal(0, count);
    }

    [Fact]
    public void SingleBrace_Count_ReturnsOne()
    {
        int count = Remover.Count("(");

        Assert.Equal(1, count);
    }

    [Fact]
    public void MatchedPair_Count_ReturnsZero()
    {
        int count = Remover.Count("()");

        Assert.Equal(0, count);
    }

    [Fact]
    public void UnmatchedPair_Count_ReturnsTwo()
    {
        int count = Remover.Count(")(");

        Assert.Equal(2, count);
    }

    [Theory]
    [InlineData("()())()", 1)]
    [InlineData(")(", 2)]
    [InlineData("((()))", 0)]
    [InlineData("(()()))", 1)]
    [InlineData("((())()", 1)]
    public void Count_Validate(string input, int expected)
    {
        int count = Remover.Count(input);

        Assert.Equal(expected, count);
    }

}