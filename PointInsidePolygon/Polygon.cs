
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

            if (IsHorizontalLineIntersecting(p1, p2, point.Y, out _))
            {
                ++intersections;
            }
        }


        return intersections % 2 == 0;
    }

    private static bool IsHorizontalLineIntersecting(Point p1, Point p2, double horizontalY, out Point intersectionPoint)
    {
        intersectionPoint = (0, 0);

        // Check if horizontalY is within the y-range of the line
        if ((horizontalY < Math.Min(p1.Y, p2.Y)) || (horizontalY > Math.Max(p1.Y, p2.Y)))
        {
            return false;
        }

        // Calculate the slope and y-intercept of the line
        double deltaY = p2.Y - p1.Y;
        double deltaX = p2.X - p1.X;

        if (deltaX == 0)
        {
            // The line is vertical, no intersection with horizontal line
            return false;
        }

        double slope = deltaY / deltaX;
        double yIntercept = p1.Y - slope * p1.X;

        // Calculate the x-coordinate of the intersection point
        double intersectionX = (horizontalY - yIntercept) / slope;

        // Check if intersectionX is within the x-range of the line
        if (intersectionX < Math.Min(p1.X, p2.X) || intersectionX > Math.Max(p1.X, p2.X))
        {
            return false;
        }

        // Set the intersection point
        intersectionPoint = new Point(intersectionX, horizontalY);
        return true;
    }


}

public record Point(double X, double Y)
{
    public static implicit operator Point((double x, double y) p) => new(p.x, p.y);
}
