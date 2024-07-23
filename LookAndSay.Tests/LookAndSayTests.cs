namespace LookAndSay.Tests;

public class LookAndSayTests
{
    [Fact]
    public void EmptyInput_Next_ReturnsEmpty()
    {
        string result = LookAndSay.Next("");

        Assert.Equal("", result);
    }

    [Theory]
    [InlineData('1')]
    [InlineData('2')]

    public void SingleInput_Next_ReturnsOneFollowedByInput(char input)
    {
        string result = LookAndSay.Next(new string(input, 1));

        Assert.Equal($"1{input}", result);
    }

    [Theory]
    [InlineData('1', 2)]
    [InlineData('2', 5)]
    public void MultipleInput_Next_ReturnsCountFollowedByInput(char input, int count)
    {
        string result = LookAndSay.Next(new string(input, count));

        Assert.Equal($"{count}{input}", result);
    }

    [Fact]
    public void DifferentSingleIputs_Next_ReturnsOneForEach()
    {
        string input = "12";

        string result = LookAndSay.Next(input);

        Assert.Equal("1112", result);
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "11")]
    [InlineData(3, "21")]
    [InlineData(4, "1211")]
    [InlineData(5, "111221")]
    public void SequenceAt_Validate(int index, string expected)
    {
        string result = LookAndSay.SequenceAt(index);

        Assert.Equal(expected, result);
    }
}