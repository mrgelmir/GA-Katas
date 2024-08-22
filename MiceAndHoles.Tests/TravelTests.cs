namespace MiceAndHoles.Tests;

public class TravelTests
{
    [Fact]
    public void SingleMouseInHole_MaxSteps_IsZero()
    {
        int[] mice = [0];
        int[] holes = [0];

        int maxSteps = Travel.MaxSteps(mice, holes);

        Assert.Equal(0, maxSteps);
    }

    [Fact]
    public void SingleMouseWithPositiveDistance_MaxSteps_IsDistance()
    {
        const int distance = 5;
        int[] mice = [0];
        int[] holes = [distance];

        int maxSteps = Travel.MaxSteps(mice, holes);

        Assert.Equal(distance, maxSteps);
    }

    [Fact]
    public void SingleMouseWithNegativeDistance_MaxSteps_IsDistance()
    {
        const int distance = 5;
        int[] mice = [distance];
        int[] holes = [0];

        int maxSteps = Travel.MaxSteps(mice, holes);

        Assert.Equal(distance, maxSteps);
    }

    [Fact]
    public void TwoMiceWithMatchingHoles_MaxSteps_IsMaxDistance()
    {
        const int distance = 5;
        int[] mice = [0, 0];
        int[] holes = [0, distance];

        int maxSteps = Travel.MaxSteps(mice, holes);

        Assert.Equal(distance, maxSteps);
    }

    [Fact]
    public void TwoMiceCrossedOrder_MaxSteps_IsZero()
    {
        int[] mice = [0, 10];
        int[] holes = [10, 0];

        int maxSteps = Travel.MaxSteps(mice, holes);

        Assert.Equal(0, maxSteps);
    }

    [Fact]
    public void ThreeMiceRandomOrder_MaxSteps_IsZero()
    {
        int[] mice = [0, 5, 10];
        int[] holes = [5, 0, 10];

        int maxSteps = Travel.MaxSteps(mice, holes);

        Assert.Equal(0, maxSteps);
    }

    [Fact]
    public void MaxSteps_Validate()
    {
        List<(int[] mice, int[] holes, int expected)> inputs = [
            ([1, 4, 9, 15],[10, -5, 0, 16], 6),
            ([1, 5, 10], [7, 3, 4], 2)
        ];

        foreach (var (mice, holes, expected) in inputs)
        {
            int maxSteps = Travel.MaxSteps(mice, holes);

            Assert.Equal(expected, maxSteps);
        }
    }
}