namespace GridPaths.Tests;

public class TravelTests
{
    [Fact]
    public void SingleEntry_GetPathCount_ReturnsOne()
    {
        int pathCount = Travel.GetPathCount(1, 1);

        Assert.Equal(1, pathCount);
    }

    [Fact]
    public void SingleRow_GetPathCount_ReturnsOne()
    {
        int pathCount = Travel.GetPathCount(100, 1);

        Assert.Equal(1, pathCount);
    }

    [Fact]
    public void SingleColumn_GetPathCount_ReturnsOne()
    {
        int pathCount = Travel.GetPathCount(1, 100);

        Assert.Equal(1, pathCount);
    }

    [Fact]
    public void TwoByTwoGrid_GetPathCount_ReturnsTwo()
    {
        int pathCount = Travel.GetPathCount(2, 2);

        Assert.Equal(2, pathCount);
    }

    [Theory]
    [InlineData(5, 5, 70)]
    public void GetPathCount_Validate(int gridWidth, int gridHeight, int expected)
    {
        int pathCount = Travel.GetPathCount(gridWidth, gridHeight);

        Assert.Equal(expected, pathCount);
    }
}