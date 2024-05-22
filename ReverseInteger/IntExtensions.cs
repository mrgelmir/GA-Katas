namespace ReverseInteger;

public static class IntExtensions
{
    public static int Reverse(this int input)
    {
        bool negative = input < 0;

        input = Math.Abs(input);
        string s = input.ToString();

        try
        {
            int reverse = int.Parse(new string(s.Reverse().ToArray()));

            return negative ? -reverse : reverse;
        }
        catch (OverflowException)
        {
            return 0;
        }
    }
}