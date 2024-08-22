namespace GridPaths;

public static class Travel
{
    public static int GetPathCount_Grid(int gridWidth, int gridHeight)
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

    public static int GetPathCount_SingleArray(int gridWidth, int gridHeight)
    {
        // Always have the height be the smallest value to get the shortest list
        if (gridWidth < gridHeight)
        {
            (gridHeight, gridWidth) = (gridWidth, gridHeight);
        }


        int[] grid = new int[gridHeight];
        for (int i = 0; i < gridHeight; ++i)
        {
            grid[i] = 0;
        }

        grid[gridHeight - 1] = 1;


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
                    bottomPossibilities = grid[y + 1];
                }

                int rightPossibilites = grid[y];

                int possibilities = bottomPossibilities + rightPossibilites;
                grid[y] = possibilities;
            }
        }

        return grid[0];
    }
}
