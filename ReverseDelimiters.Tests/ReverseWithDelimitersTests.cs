namespace ReverseDelimiters.Tests;

public class ReverseWithDelimitersTests
{
    [Fact]
    public void NoDelimiters_Reverse_ShouldBeEqual()
    {
        const string someString = "test/hello";

        string result = someString.ReverseWithDelimiters([]);

        Assert.Equal(someString, result);
    }

    [Fact]
    public void StringNotContainingDelimiters_Reverse_ShouldNotChange()
    {
        const string stringWithoutDelimiters = "test";

        string result = stringWithoutDelimiters.ReverseWithDelimiters('/');

        Assert.Equal(stringWithoutDelimiters, result);
    }

    [Fact]
    public void SingleLetters_Reverse_ShouldSwap()
    {
        const string singleCharacters = "a/b";

        string result = singleCharacters.ReverseWithDelimiters('/');

        Assert.Equal("b/a", result);
    }

    [Fact]
    public void SymmetricalString_Reverse_ShouldNotChange()
    {
        const string symmetricalString = "test/test";

        string result = symmetricalString.ReverseWithDelimiters('/');

        Assert.Equal(symmetricalString, result);
    }

    [Fact]
    public void SingleDelimiter_Reverse_ShouldSwap()
    {
        const string simpleCase = "hello/test";

        string result = simpleCase.ReverseWithDelimiters('/');

        Assert.Equal("test/hello", result);
    }

    [Fact]
    public void ThreeElements_Reverse_ShouldReverse()
    {
        const string threeElements = "foo/bar/baz";

        string result = threeElements.ReverseWithDelimiters('/');

        Assert.Equal("baz/bar/foo", result);
    }

    [Fact]
    public void EmptySpot_Reverse_ShouldStayEmpty()
    {
        const string doubleDelimiter = "foo//bar";

        string result = doubleDelimiter.ReverseWithDelimiters('/');

        Assert.Equal("bar//foo", result);
    }

    [Fact]
    public void EndWithDelimiter_Reverse_ShouldNotSwap()
    {
        const string endsWithDelimiter = "foo/";

        string result = endsWithDelimiter.ReverseWithDelimiters('/');

        Assert.Equal(endsWithDelimiter, result);
    }

    [Fact]
    public void DifferentDelimiters_Reverse_Works()
    {
        const string differentDelimiters = "foo/bar:baz";

        string result = differentDelimiters.ReverseWithDelimiters('/', ':');

        Assert.Equal("baz/bar:foo", result);
    }

    [Theory]
    [InlineData("hello/world:here", "here/world:hello")]
    [InlineData("hello/world:here/", "here/world:hello/")]
    [InlineData("hello//world:here", "here//world:hello")]
    public void Reverse_Valdation(string input, string expected)
    {
        string result = input.ReverseWithDelimiters('/', ':');

        Assert.Equal(expected, result);
    }
}