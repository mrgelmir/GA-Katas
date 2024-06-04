namespace PointInsidePolygon.Tests;

public class LinesTests
{
    [Fact]
    public void HigherPoint_HorizontalIntersection_Fails()
    {
        Point upper = (0, 1);
        Point lower = (0, 0);
        const double higherPoint = 2;

        bool intersects = Lines.HorizontalIntersect(upper, lower, higherPoint, out _);

        Assert.False(intersects);
    }

    [Fact]
    public void LowerPoint_HorizontalIntersection_Fails()
    {
        Point upper = (0, 1);
        Point lower = (0, 0);
        const double lowerPoint = -1;

        bool intersects = Lines.HorizontalIntersect(upper, lower, lowerPoint, out _);

        Assert.False(intersects);
    }

    [Fact]
    public void HorizontalLine_HorizontalIntersection_Fails()
    {
        Point left = (0, 0);
        Point right = (1, 0);
        const double matchingHeight = 0;

        bool intersects = Lines.HorizontalIntersect(left, right, matchingHeight, out _);

        Assert.False(intersects);
    }

    [Fact]
    public void CenteredOnVerticalLine_HorizontalIntersection_Succeeds()
    {
        Point upper = (0, 1);
        Point lower = (0, 0);
        const double centerPoint = .5;

        bool intersects = Lines.HorizontalIntersect(upper, lower, centerPoint, out _);

        Assert.True(intersects);
    }

    [Fact]
    public void CenteredOnVerticalLine_HorizontalIntersection_ReturnsCenter()
    {
        const int xPos = 0;
        const double centerPoint = .5;
        Point top = (xPos, 1);
        Point bottom = (xPos, 0);

        _ = Lines.HorizontalIntersect(top, bottom, centerPoint, out Point intersection);

        Assert.Equal((0, centerPoint), intersection);
    }

    [Fact]
    public void ValidY_HorizontalIntersection_ReturnsCorrectHeight()
    {
        Point p1 = (0, 0);
        Point p2 = (1, 1);
        const double center = .5;

        Lines.HorizontalIntersect(p1, p2, center, out Point intersection);

        Assert.Equal(center, intersection.Y);
    }

    [Fact]
    public void Diagonal_HorizontalIntersection_ReturnsCenter()
    {
        Point p1 = (0, 0);
        Point p2 = (1, 1);
        double xCenter = (p1.X + p2.X) / 2;
        double yCenter = (p1.Y + p2.Y) / 2;

        Lines.HorizontalIntersect(p1, p2, yCenter, out Point intersection);

        Assert.Equal((xCenter, yCenter), intersection);
    }

}
