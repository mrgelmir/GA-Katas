namespace LargestInteger.Tests;

public abstract class IntExtensionsTests
{
    [Fact]
    public void EmptyArray_ConstructLargest_ReturnsZero()
    {
        int result = Execute([]);

        Assert.Equal(0, result);
    }

    [Fact]
    public void SingleNumber_ConstructLargest_ReturnsThatNumber()
    {
        const int singleNumber = 10;

        int result = Execute([singleNumber]);

        Assert.Equal(singleNumber, result);
    }

    [Fact]
    public void CorrectlyOrderedNumbers_ConstructLargest_ReturnsConcatenated()
    {
        int result = Execute([5, 1]);

        Assert.Equal(51, result);
    }

    [Fact]
    public void ReverseOrderedNumbers_ConstructLargest_ReturnsConcatenated()
    {
        int result = Execute([1, 5]);

        Assert.Equal(51, result);
    }

    [Fact]
    public void SameStartingNumberButDifferentNextOne_ConstructLargest_ShouldOrderCorrectly()
    {
        int result = Execute([7, 76]);

        Assert.Equal(776, result);
    }

    [Fact]
    public void EdgeCaseTODO_ConstructLargest_Works()
    {
        int result = Execute([3, 13]);

        Assert.Equal(313, result);
    }
    

    [Fact]
    public void IntMaxValue_ConstructLargest_Works()
    {
        int result = Execute([int.MaxValue]);

        Assert.Equal(int.MaxValue, result);
    }

    [Fact]
    public void ConstructLargest_Validate()
    {
        int result = Execute([10, 7, 76, 415]);

        Assert.Equal(77641510, result);
    }

    [Fact]
    public void ConstructLargest_Validate_2()
    {
        int result = Execute([14, 74, 8, 3, 64, 7]);

        Assert.Equal(8_7_74_64_3_14, result);
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

public class ArrayImplementation : IntExtensionsTests
{
    protected override int Execute(int[] input) => IntExtensions.ArrayImplementation(input);
}

public class ArrayImplementation_PrecomputedValues : IntExtensionsTests
{
    protected override int Execute(int[] input) => IntExtensions.ArrayImplementation_PrecomputedValues(input);
}
