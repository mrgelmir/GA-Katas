namespace SubarraySumEquals.Tests;

public class SubarraySumTests
{
    [Fact]
    public void EmptyInput_Find_ShouldReturnEmptyResult()
    {
        const int anyNumber = 10;

        List<int> result = SubarraySum.Find([], anyNumber);

        Assert.Empty(result);
    }

    [Fact]
    public void SingleMatchingInput_Find_ShouldReturnSingleOutput()
    {
        const int number = 5;

        List<int> result = SubarraySum.Find([number], number);

        Assert.Single(result);
        Assert.Equal(number, result[0]);
    }

    [Fact]
    public void SingleNonMatchingInput_Find_ShouldReturnEmptyResult()
    {
        const int number = 5;
        const int otherNumber = 3;

        List<int> result = SubarraySum.Find([otherNumber], number);

        Assert.Empty(result);
    }

    [Fact]
    public void DoubleMatchingInput_Find_ShouldReturnCollection()
    {
        const int number = 5;
        List<int> array = [2, 3];

        List<int> result = SubarraySum.Find(array, number);

        Assert.Equal(result, array);
    }

    [Fact]
    public void StartingMatchingInput_Find_ShouldReturnCorrectSlice()
    {
        const int number = 5;
        List<int> matchingArray = [2, 3];
        const int randomNumber = 12;

        List<int> result = SubarraySum.Find(
            matchingArray.Append(randomNumber).ToList(),
            number);

        Assert.Equal(matchingArray, result);
    }

    [Fact]
    public void TrailingMatchingInput_Find_ShouldReturnCorrectSlice()
    {
        const int number = 5;
        List<int> matchingArray = [2, 3];
        const int randomNumber = 12;

        List<int> result = SubarraySum.Find(
            matchingArray.Prepend(randomNumber).ToList(),
            number);

        Assert.Equal(matchingArray, result);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Find_Validation(int number, List<int> source, List<int> expected)
    {
        List<int> result = SubarraySum.Find(source, number);

        Assert.Equal(expected, result);
    }


    public static IEnumerable<object[]> TestData()
    {
        yield return [9, new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 2, 3, 4 }];
        yield return [8, new List<int> { 1, 1, 1, 1, 8 }, new List<int> { 8 }];
        yield return [8, new List<int> { 1, 1, 1, 1 }, new List<int>()];
    }
}