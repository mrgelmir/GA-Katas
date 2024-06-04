
namespace PointInsidePolygon;

public class Polygon
{
    private readonly Point[] points;
    private readonly Point min;
    private readonly Point max;

    public Polygon(params Point[] points)
    {
        this.points = points;

        min = new(points.MinBy(p => p.X).X, points.MinBy(p => p.Y).Y);
        max = new(points.MaxBy(p => p.X).X, points.MaxBy(p => p.Y).Y);
    }

    public bool IsInside(Point point)
    {
        bool isInBounds = point.X > min.X && point.X < max.X && point.Y > min.Y && point.Y < max.Y;
        if (!isInBounds)
            return false;

        int intersections = 0;

        for (int i = 0; i < points.Length; ++i)
        {
            Point p1 = points[i];
            Point p2 = points[(i + 1) % points.Length];

            if (Lines.HorizontalIntersect(p1, p2, point.Y, out Point intersection))
            {
                if (intersection.X > point.X)
                    ++intersections;
            }
        }


        return intersections % 2 != 0;
    }
}

public record Point(double X, double Y)
{
    public static implicit operator Point((double x, double y) p) => new(p.x, p.y);
}