namespace ReverseInteger.Tests;

public class IntExtensionsTests
{
    [Fact]
    public void SingleDigit_Reverse_ShouldReturnInput()
    {
        const int singleDigit = 5;

        int result = singleDigit.Reverse();

        Assert.Equal(singleDigit, result);
    }

    [Fact]
    public void Zero_Reverse_ShouldReturnZero()
    {
        const int zero = 0;

        int result = zero.Reverse();
        
        Assert.Equal(zero, result);
    }

    [Fact]
    public void TwoDigits_Reverse_ShouldSwapPlaces()
    {
        const int twoDigits = 12;

        int result = twoDigits.Reverse();

        Assert.Multiple(
            () => Assert.Equal(twoDigits.ToString()[0], result.ToString()[1]),
            () => Assert.Equal(twoDigits.ToString()[1], result.ToString()[0])
        );
    }

    [Fact]
    public void NegativeSingleNumber_Reverse_ShouldReturnInput()
    {
        const int negativeNumber = -5;

        int result = negativeNumber.Reverse();

        Assert.Equal(negativeNumber, result);
    }

    [Fact]
    public void NegativeNumber_Reverse_ShouldRemainNegative()
    {
        const int someNegativeNumber = -1234;

        int result = someNegativeNumber.Reverse();

        Assert.True(result < 0);
    }

    [Fact]
    public void NegativeTwoDigits_Reverse_ShouldSwapPlace()
    {
        const int negativeTwoDigits = -12;

        int result = negativeTwoDigits.Reverse();

        Assert.Multiple(
            () => Assert.Equal(negativeTwoDigits.ToString()[1], result.ToString()[2]),
            () => Assert.Equal(negativeTwoDigits.ToString()[2], result.ToString()[1])
        );
    }

    [Fact]
    public void TrailingZero_Reverse_ShouldDisappear()
    {
        const int trailingZero = 30;

        int result = trailingZero.Reverse();

        Assert.Single(result.ToString());
    }

    [Fact]
    public void PositiveOverflow_Reverse_ShouldReturnZero()
    {
        const int reverseOverflow = 1563841472;

        int result = reverseOverflow.Reverse();
        
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void NegativeOverflow_Reverse_ShouldReturnZero()
    {
        const int reverseOverflow = -1563841472;

        int result = reverseOverflow.Reverse();
        
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData(123, 321)]
    [InlineData(120, 21)]
    public void Reverse_Validate(int input, int expected)
    {
        int result = input.Reverse();
        
        Assert.Equal(expected, result);
    }
}