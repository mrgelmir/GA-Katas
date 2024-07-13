namespace PartitionMultiset.Tests;

public class MultisetTests
{
    [Fact]
    public void SingleEntry_CanPartition_Fails()
    {
        bool result = Multiset.Partition([]);

        Assert.False(result);
    }

    [Fact]
    public void TwoIdenticalEntries_CanPartition_Succeeds()
    {
        bool result = Multiset.Partition([1, 1]);

        Assert.True(result);
    }

    [Fact]
    public void TwoDifferentEntries_CanPartition_Fails()
    {
        bool result = Multiset.Partition([1, 2]);

        Assert.False(result);
    }

    [Fact]
    public void SequentialSum_CanPartition_Succeeds()
    {
        bool result = Multiset.Partition([1, 1, 2]);

        Assert.True(result);
    }

    [Fact]
    public void ImpossibleSum_CanPartition_Fails()
    {
        bool result = Multiset.Partition([1, 1, 25]);

        Assert.False(result);
    }

    [Fact]
    public void SplitSum_CanPartition_Succeeds()
    {
        bool result = Multiset.Partition([1, 2, 1]);

        Assert.True(result);
    }

    [Theory]
    [MemberData(nameof(ValidationData))]
    public void CanPartition_Validation(List<int> input, bool expected)
    {
        bool result = Multiset.Partition(input);

        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> ValidationData => new List<object[]>
    {
        new object[] { new List<int>{15, 5, 20, 10, 35, 15, 10}, true },
        new object[] { new List<int>{15, 5, 20, 10, 35}, false },
        new object[] { new List<int>{1, 5, 11, 5}, true },
    };
}