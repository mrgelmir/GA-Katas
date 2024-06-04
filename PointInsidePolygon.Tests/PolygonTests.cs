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

    [Theory]
    [InlineData(2.7, 3.8, true)]
    [InlineData(3.75, 2.66, false)]
    [InlineData(3.5, 5, false)]
    public void Triangle_IsInside_Validation(double x, double y, bool expected)
    {
        Polygon triangle = new((2, 2), (6, 5), (2, 5));
        Point point = new(x, y);

        bool result = triangle.IsInside(point);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 1, false)] // Corner
    [InlineData(3.6, 2, true)]
    [InlineData(3.4, 4.5, true)]
    // [InlineData(4, 3, true)] // Inline with corners => edge gets counted double
    [InlineData(1.5, 4, false)]
    public void Polygon_IsInside_Validation(double x, double y, bool expected)
    {
        Polygon polygon = new Polygon((1, 1), (3, 3), (1, 6), (4, 6), (6, 3), (4, 1));
        Point point = new(x, y);

        bool result = polygon.IsInside(point);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(7, 5, false)] // On border
    [InlineData(7.7, 2.6, false)]
    [InlineData(3.2, 4.6, true)]
    [InlineData(2.22, 6.73, false)]
    // [InlineData(.5, 6, false)] // Inline with a corner => edge gets counted double
    public void IrregularPolygon_IsInside_Validation(double x, double y, bool expected)
    {
        Polygon polygon = new((0, 0), (2, 3), (1, 6), (5, 7), (8, 4), (7, 2), (4, 0));
        Point point = new(x, y);

        bool result = polygon.IsInside(point);

        Assert.Equal(expected, result);
    }

    // TODO:
    // - edge and border cases (point collisions) (see commented out validations above)
}