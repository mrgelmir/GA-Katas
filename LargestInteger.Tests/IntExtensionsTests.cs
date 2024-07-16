namespace LargestInteger.Tests;

public abstract class IntExtensionsTests
{
    [Fact]
    public void EmptyArray_ConstructLargest_ReturnsZero()
    {
        int result = IntExtensions.ConstructLargestInt([]);

        Assert.Equal(0, result);
    }

    [Fact]
    public void SingleNumber_ConstructLargest_ReturnsThatNumber()
    {
        const int singleNumber = 10;

        int result = IntExtensions.ConstructLargestInt([singleNumber]);

        Assert.Equal(singleNumber, result);
    }

    [Fact]
    public void CorrectlyOrderedNumbers_ConstructLargest_ReturnsConcatenated()
    {
        int result = IntExtensions.ConstructLargestInt([5, 1]);

        Assert.Equal(51, result);
    }

    [Fact]
    public void ReverseOrderedNumbers_ConstructLargest_ReturnsConcatenated()
    {
        int result = IntExtensions.ConstructLargestInt([1, 5]);

        Assert.Equal(51, result);
    }

    [Fact]
    public void SameStartingNumberButDifferentNextOne_ConstructLargest_ShouldOrderCorrectly()
    {
        int result = IntExtensions.ConstructLargestInt([7, 76]);

        Assert.Equal(776, result);
    }

    [Fact]
    public void ConstructLargest_Validate()
    {
        int result = IntExtensions.ConstructLargestInt([10, 7, 76, 415]);

        Assert.Equal(77641510, result);
    }

    protected abstract int Execute(int[] input);
}

public class StringImplementation1 : IntExtensionsTests
{
    protected override int Execute(int[] input) => IntExtensions.StringImplementation1(input);
}

public class StringImplementation2 : IntExtensionsTests
{
    protected override int Execute(int[] input) => IntExtensions.StringImplementation2(input);
}

public class ModuloImplementation : IntExtensionsTests
{
    protected override int Execute(int[] input) => IntExtensions.ModuloImplementation(input);
}
