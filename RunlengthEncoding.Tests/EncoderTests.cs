namespace RunlengthEncoding.Tests;

public class EncoderTests
{
    [Fact]
    public void EmptyString_Encode_ShouldReturnEmpty()
    {
        Encoder encoder = new();

        string result = encoder.Encode("");

        Assert.Equal("", result);
    }

    [Fact]
    public void SingleCharacter_Encode_ShouldReturn1Character()
    {
        Encoder encoder = new();

        string result = encoder.Encode("A");

        Assert.Equal("1A", result);
    }

    [Fact]
    public void DoubleCharacter_Encode_ShouldReturn2Character()
    {
        Encoder encoder = new();

        string result = encoder.Encode("AA");

        Assert.Equal("2A", result);
    }

    [Fact]
    public void TwoCharacters_Encode_ShouldReturnPair()
    {
        Encoder encoder = new();

        string result = encoder.Encode("AB");

        Assert.Equal("1A1B", result);
    }

    [Fact]
    public void TenCharacters_Encode_ShouldWork()
    {
        Encoder encoder = new();

        string result = encoder.Encode(new string('A', 10));

        Assert.Equal("10A", result);
    }

    [Theory]
    [InlineData("AAAABBBCCDAA", "4A3B2C1D2A")]
    public void Encode_Validation(string input, string expected)
    {
        Encoder encoder = new();

        string result = encoder.Encode(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void EmptyString_Decode_ShouldReturnEmpty()
    {
        Encoder encoder = new();

        string result = encoder.Decode("");

        Assert.Equal("", result);
    }

    [Fact]
    public void OneCharacter_Decode_ShouldReturnOneCharacter()
    {
        Encoder encoder = new();

        string result = encoder.Decode("1A");

        Assert.Equal("A", result);
    }

    [Fact]
    public void TwoCharacters_Decode_ShouldReturnDouble()
    {
        Encoder encoder = new();

        string result = encoder.Decode("2A");

        Assert.Equal("AA", result);
    }

    [Fact]
    public void TenCharacters_Decode_ShouldReturnTenCharacters()
    {
        Encoder encoder = new();

        string result = encoder.Decode("10A");

        Assert.Equal(new string('A', 10), result);
    }

    [Theory]
    [InlineData("4A3B2C1D2A", "AAAABBBCCDAA")]
    public void Decode_Validate(string input, string expected)
    {
        Encoder encoder = new();

        string result = encoder.Decode(input);

        Assert.Equal(expected, result);
    }
}