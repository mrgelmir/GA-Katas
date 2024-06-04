
namespace PointInsidePolygon;

public static class Lines
{
    public static bool HorizontalIntersect(Point p1, Point p2, double horizontalY, out Point intersectionPoint)
    {
        intersectionPoint = (0, 0);

        // Check if horizontalY is within the y-range of the line
        double minY = Math.Min(p1.Y, p2.Y);
        double maxY = Math.Max(p1.Y, p2.Y);
        if (horizontalY < minY || horizontalY > maxY)
            return false;


        double deltaY = p2.Y - p1.Y;
        double deltaX = p2.X - p1.X;

        if (deltaX == 0)
        {
            // Vertical line
            intersectionPoint = (p1.X, horizontalY);
            return true;
        }

        double slope = deltaX == 0 ? 0 : deltaY / deltaX;

        if (slope == 0)
        {
            // Horizontal line
            return false;
        }

        double yIntercept = p1.Y - slope * p1.X;
        double intersectionX = (horizontalY - yIntercept) / slope;

        // I don't see a need for this right now
        // // Check if intersectionX is within the x-range of the line
        // if (intersectionX < Math.Min(p1.X, p2.X) || intersectionX > Math.Max(p1.X, p2.X))
        // {
        //     return false;
        // }

        // // Set the intersection point
        intersectionPoint = new Point(intersectionX, horizontalY);
        return true;
    }
}