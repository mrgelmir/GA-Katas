namespace ConditionalReturn;

public static class Unconditional
{
    public static int Multiplication(int x, int y, int b)
    {
        return b * x + (1 - b) * y;
    }

    public static int Bitwise(int x, int y, int b)
    {
        int mask = b * int.MaxValue;
        return (x & mask) | (y & ~mask);
    }
}
