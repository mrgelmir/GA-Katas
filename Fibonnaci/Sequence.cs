namespace Fibonnaci;

public class Sequence
{
    public static int FibonacciRecursive(int input)
    {
        if (input == 0)
            return 0;

        if (input == 1)
            return 1;

        return FibonacciRecursive(input - 2) + FibonacciRecursive(input - 1);
    }

    public static int FibonacciLinear(int input)
    {
        if (input == 0)
            return 0;

        int previous = 1;
        int current = 0;

        for (int i = 1; i <= input; ++i)
        {
            int temp = previous + current;
            previous = current;
            current = temp;
        }
        
        return current;
    }
}
