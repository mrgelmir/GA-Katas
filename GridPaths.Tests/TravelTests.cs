using FluentAssertions;

namespace GridPaths.Tests;

public abstract class TravelTests
{
    [Fact]
    public void SingleEntry_GetPathCount_ReturnsOne()
    {
        int pathCount = GetPathCount(1, 1);

        pathCount.Should().Be(1);
    }

    [Fact]
    public void SingleRow_GetPathCount_ReturnsOne()
    {
        int pathCount = GetPathCount(100, 1);

        pathCount.Should().Be(1);
    }

    [Fact]
    public void SingleColumn_GetPathCount_ReturnsOne()
    {
        int pathCount = GetPathCount(1, 100);

        pathCount.Should().Be(1);
    }

    [Fact]
    public void TwoByTwoGrid_GetPathCount_ReturnsTwo()
    {
        int pathCount = GetPathCount(2, 2);

        pathCount.Should().Be(2);
    }

    [Theory]
    [InlineData(5, 5, 70)]
    [InlineData(10, 5, 715)]
    [InlineData(5, 10, 715)]
    public void GetPathCount_Validate(int gridWidth, int gridHeight, int expected)
    {
        int pathCount = GetPathCount(gridWidth, gridHeight);

        pathCount.Should().Be(expected);
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

public class ArrayTests : TravelTests
{
    protected override int GetPathCount(int gridWidth, int gridHeight)
    {
        return Travel.GetPathCount_SingleArray(gridWidth, gridHeight);
    }
}

public class GitAmend : TravelTests
{
    protected override int GetPathCount(int gridWidth, int gridHeight)
    {
        return (int)Travel.CountUniquePaths(gridWidth, gridHeight);
    }
}