namespace PartitionMultiset.Tests;

public class MultisetBitArrayTests : MultisetTests
{
    protected override bool Execute(List<int> input)
    {
        return Multiset.PartitionWithBitArray(input);
    }
}

public class MultisetDPTests : MultisetTests
{
    protected override bool Execute(List<int> input)
    {
        return Multiset.PartitionWithDP(input);
    }
}

public abstract class MultisetTests
{
    protected abstract bool Execute(List<int> input);

    [Fact]
    public void NoEntry_CanPartition_Fails()
    {
        bool result = Execute([]);

        Assert.False(result);
    }
    
    [Fact]
    public void SingleOddEntry_CanPartition_Fails()
    {
        bool result = Execute([1]);

        Assert.False(result);
    }
    
    [Fact]
    public void SingleEvenEntry_CanPartition_Fails()
    {
        bool result = Execute([2]);

        Assert.False(result);
    }

    [Fact]
    public void TwoIdenticalEntries_CanPartition_Succeeds()
    {
        bool result = Execute([1, 1]);

        Assert.True(result);
    }

    [Fact]
    public void TwoDifferentEntries_CanPartition_Fails()
    {
        bool result = Execute([1, 2]);

        Assert.False(result);
    }

    [Fact]
    public void SequentialSum_CanPartition_Succeeds()
    {
        bool result = Execute([1, 1, 2]);

        Assert.True(result);
    }

    [Fact]
    public void ImpossibleSum_CanPartition_Fails()
    {
        bool result = Execute([1, 1, 25]);

        Assert.False(result);
    }

    [Fact]
    public void SplitSum_CanPartition_Succeeds()
    {
        bool result = Execute([1, 2, 1]);

        Assert.True(result);
    }

    [Theory]
    [MemberData(nameof(ValidationData))]
    public void CanPartition_Validation(List<int> input, bool expected)
    {
        bool result = Execute(input);

        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> ValidationData => new List<object[]>
    {
        new object[] { new List<int> { 15, 5, 20, 10, 35, 15, 10 }, true },
        new object[] { new List<int> { 15, 5, 20, 10, 35 }, false },
        new object[] { new List<int> { 1, 5, 11, 5 }, true },
    };
}