namespace Palindrome.Tests;

public abstract class StringExtensionTests
{
    [Fact]
    public void SingleLetter_IsPalindrome()
    {
        Assert.True("A".IsPalindrome());
    }

    [Fact]
    public void TwoDifferentLetters_AreNoPalindrome()
    {
        Assert.False("AB".IsPalindrome());
    }

    [Fact]
    public void TwoIdenticalLetters_AreAPalindrome()
    {
        Assert.True("AA".IsPalindrome());
    }

    [Fact]
    public void DifferentCaseLetters_AreValid()
    {
        Assert.True("Aa".IsPalindrome());
    }

    [Fact]
    public void WhiteSpace_IsIgnored()
    {
        Assert.True("ABB A".IsPalindrome());
    }

    [Fact]
    public void LeadingWhitespace_IsIgnored()
    {
        Assert.True(" AA".IsPalindrome());
    }

    [Fact]
    public void TrailingWhitespace_IsIgnored()
    {
        Assert.True("AA ".IsPalindrome());
    }

    [Theory]
    [InlineData("AA.")]
    [InlineData("AA#")]
    [InlineData("AA$")]
    public void SpecialCharacters_AreIgnored(string input)
    {
        Assert.True(input.IsPalindrome());
    }

    [Theory]
    [InlineData("A man, a plan, a canal, Panama", true)]
    [InlineData("No 'x' in Nixon", true)]
    [InlineData("Hello, World!", false)]
    public void Validation(string input, bool expected)
    {
        Assert.Equal(expected, input.IsPalindrome());
    }

    protected abstract bool Execute(string input);
}

public class CursorTests : StringExtensionTests
{
    protected override bool Execute(string input) => input.IsPalindrome();
}

public class SmackTests : StringExtensionTests
{
    protected override bool Execute(string input) => StringExtensions.IsPalindrome_smack(input);
}

public class ChatGPTTests : StringExtensionTests
{
    protected override bool Execute(string input) => StringExtensions.IsPalindrome_ChatGPT(input);
}

public class ChatGPT2Tests : StringExtensionTests
{
    protected override bool Execute(string input) => StringExtensions.IsPalindrome_ChatGPT2(input);
}