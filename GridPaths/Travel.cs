namespace GridPaths;

public static class Travel
{
    public static int GetPathCount(int gridWidth, int gridHeight)
    {
        if (gridWidth == 1 || gridHeight == 1)
        {
            return 1;
        }

        int[,] grid = new int[gridWidth, gridHeight];

        grid[gridWidth - 1, gridHeight - 1] = 1;

        for (int x = gridWidth - 1; x >= 0; --x)
        {
            for (int y = gridHeight - 1; y >= 0; --y)
            {
                // Skip final position
                if (x == gridWidth - 1 && y == gridHeight - 1)
                    continue;

                int bottomPossibilities = 0;
                if (y + 1 < gridHeight)
                {
                    bottomPossibilities = grid[x, y + 1];
                }
                int rightPossibilites = 0;
                if (x + 1 < gridWidth)
                {
                    rightPossibilites = grid[x + 1, y];
                }

                int possibilities = bottomPossibilities + rightPossibilites;
                grid[x, y] = possibilities;
            }
        }


        return grid[0, 0];
    }
}
