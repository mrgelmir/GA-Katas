namespace ConditionalReturn.Tests;

public abstract class UnconditionalTests
{
    [Fact]
    public void SameNumbers_ReturnsThatNumber()
    {
        const int sameNumber = 100;
        const int anyValue = 1;

        int result = Execute(sameNumber, sameNumber, anyValue);

        Assert.Equal(sameNumber, result);
    }

    [Fact]
    public void WhenOne_ReturnsFirstNumber()
    {
        const int firstNumber = 100;
        const int otherNumber = 10;
        const int one = 1;

        int result = Execute(firstNumber, otherNumber, one);

        Assert.Equal(firstNumber, result);
    }

    [Fact]
    public void WhenZero_ReturnsSecondtNumber()
    {
        const int otherNumber = 10;
        const int secondNumber = 100;
        const int zero = 0;

        int result = Execute(otherNumber, secondNumber, zero);

        Assert.Equal(secondNumber, result);
    }

    protected abstract int Execute(int x, int y, int b);
}

public class MultiplicationTests : UnconditionalTests
{
    protected override int Execute(int x, int y, int b)
    {
        return Unconditional.Multiplication(x, y, b);
    }
}

public class BitwiseTests : UnconditionalTests
{
    protected override int Execute(int x, int y, int b)
    {
        return Unconditional.Bitwise(x, y, b);
    }
}
