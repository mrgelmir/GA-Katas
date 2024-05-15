namespace RotateList.Tests;

public class RotateListTests
{
    [Fact]
    public void ZeroRotations_Rotate_ShouldNotChangeList()
    {
        List<int> expected = [0, 1, 2, 3, 4, 5, 6];
        List<int> result = [0, 1, 2, 3, 4, 5, 6];

        RotateList.Rotate(result, 0);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void OneRotation_Rotate_EndShouldBeFirst()
    {
        List<int> result = [0, 1, 2, 3, 4, 5, 6];
        int tail = result[^1];

        RotateList.Rotate(result, 1);

        Assert.Equal(tail, result[0]);
    }

    [Fact]
    public void FullLengthRotation_Rotate_ShouldEqualInput()
    {
        List<int> expected = [0, 1, 2, 3, 4, 5, 6];
        List<int> result = [0, 1, 2, 3, 4, 5, 6];

        RotateList.Rotate(result, result.Count);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void OneNegativeRotation_Rotate_FirstShouldBeLast()
    {
        List<int> result = [0, 1, 2, 3, 4, 5, 6];
        int start = result[0];

        RotateList.Rotate(result, -1);

        Assert.Equal(start, result[^1]);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Rotate_Validate(List<int> expected, List<int> input, int rotations)
    {
        RotateList.Rotate(input, rotations);

        Assert.Equal(expected, input);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new List<int> { 6, 0, 1, 2, 3, 4, 5 }, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 1 };
        yield return new object[] { new List<int> { 4, 5, 6, 0, 1, 2, 3 }, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 3 };
        yield return new object[] { new List<int> { 0, 1, 2, 3, 4, 5, 6 }, new List<int> { 4, 5, 6, 0, 1, 2, 3 }, -3 };
    }
}