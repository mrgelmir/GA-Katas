namespace GridPaths.Tests;

public abstract class TravelTests
{
    [Fact]
    public void SingleEntry_GetPathCount_ReturnsOne()
    {
        int pathCount = GetPathCount(1, 1);

        Assert.Equal(1, pathCount);
    }

    [Fact]
    public void SingleRow_GetPathCount_ReturnsOne()
    {
        int pathCount = GetPathCount(100, 1);

        Assert.Equal(1, pathCount);
    }

    [Fact]
    public void SingleColumn_GetPathCount_ReturnsOne()
    {
        int pathCount = GetPathCount(1, 100);

        Assert.Equal(1, pathCount);
    }

    [Fact]
    public void TwoByTwoGrid_GetPathCount_ReturnsTwo()
    {
        int pathCount = GetPathCount(2, 2);

        Assert.Equal(2, pathCount);
    }

    [Theory]
    [InlineData(5, 5, 70)]
    [InlineData(10, 5, 715)]
    [InlineData(5, 10, 715)]
    public void GetPathCount_Validate(int gridWidth, int gridHeight, int expected)
    {
        int pathCount = GetPathCount(gridWidth, gridHeight);

        Assert.Equal(expected, pathCount);
    }

    protected abstract int GetPathCount(int gridWidth, int gridHeight);
}

public class GridTests : TravelTests
{
    protected override int GetPathCount(int gridWidth, int gridHeight)
    {
        return Travel.GetPathCount_Grid(gridWidth, gridHeight);
    }
}


public class ArrayTests:TravelTests
{
    protected override int GetPathCount(int gridWidth, int gridHeight)
    {
        return Travel.GetPathCount_SingleArray(gridWidth, gridHeight);
    }
}