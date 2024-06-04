namespace MatrixWordSearch;

public class CharacterMatrix
{
    private readonly char[,] chars;

    public CharacterMatrix(char[][] chars)
    {
        if (chars.Length <= 0)
        {
            this.chars = new char[0, 0];
            return;
        }

        this.chars = new char[chars.Length, chars[0].Length];

        for (int row = 0; row < this.chars.GetLength(0); ++row)
        {
            for (int col = 0; col < this.chars.GetLength(1); ++col)
            {
                this.chars[row, col] = chars[row][col];
            }
        }
    }

    public bool Find(string input)
    {
        if (chars.Length <= 0)
            return false;

        int inputIndex;

        for (int row = 0; row < chars.GetLength(0); ++row)
        {
            LineReset();

            for (int col = 0; col < chars.GetLength(1); ++col)
            {
                if (CheckPosition(col, row))
                    return true;
            }
        }

        for (int col = 0; col < chars.GetLength(1); ++col)
        {
            LineReset();

            for (int row = 0; row < chars.GetLength(0); ++row)
            {
                if (CheckPosition(col, row))
                    return true;
            }
        }

        void LineReset() { inputIndex = 0; }
        bool CheckPosition(int col, int row)
        {
            char current = chars[row, col];

            // Reset index if not matching in sequence
            if (current != input[inputIndex])
            {
                inputIndex = 0;

                // skip next steps if not current
                if (current != input[inputIndex])
                {
                    return false;
                }
            }

            if (inputIndex + 1 == input.Length)
                return true;

            ++inputIndex;
            return false;
        }

        return false;
    }
}
