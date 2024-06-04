namespace PointInsidePolygon.Tests;

using PointInsidePolygon;

public class PolygonTests
{
    [Fact]
    public void CenterPoint_Inside_IsTrue()
    {
        Polygon polygon = new((0, 0), (1, 0), (1, 1), (0, 1));
        Point center = (.5, .5);

        bool result = polygon.IsInside(center);

        Assert.True(result);
    }

    [Theory]
    [MemberData(nameof(OutsideBoundingBoxData))]
    public void PointOutsideBoundingBox_IsInside_IsFalse(Point outside)
    {
        Polygon polygon = new((0, 0), (0, 1), (1, 1), (1, 0));

        bool result = polygon.IsInside(outside);

        Assert.False(result);
    }

    public static IEnumerable<object[]> OutsideBoundingBoxData()
    {
        yield return new object[] { new Point(-1, .5) };
        yield return new object[] { new Point(2, .5) };
        yield return new object[] { new Point(.5, -1) };
        yield return new object[] { new Point(.5, 2) };
    }

    [Fact]
    public void PointInBoundingBoxButOutsideTriangle_IsInside_IsFalse()
    {
        Polygon polygon = new((0, 0), (0, 1), (1, 0));
        Point outside = (.75, .75);

        bool result = polygon.IsInside(outside);

        Assert.False(result);
    }

    [Fact]
    public void PointOnVertex_IsInside_IsFalse()
    {
        Point sharedVertex = (0, 0);
        Polygon polygon = new(sharedVertex, (0, 1), (1, 0));

        bool result = polygon.IsInside(sharedVertex);

        Assert.False(result);
    }

    [Fact]
    public void PointOnVerticalEdge_IsInside_IsFalse()
    {
        Point edgePoint = (0, .5);
        Polygon polygon = new((0, 0), (0, 1), (1, 0));

        bool result = polygon.IsInside(edgePoint);

        Assert.False(result);
    }

    [Fact]
    public void PointOnHorizontalEdge_IsInside_IsFalse()
    {
        Point edgePoint = (.5, 0);
        Polygon polygon = new((0, 0), (0, 1), (1, 0));

        bool result = polygon.IsInside(edgePoint);

        Assert.False(result);
    }

    // TODO:
    // - validation with more difficult shapes
    // - edge and border cases (point collisions)
}