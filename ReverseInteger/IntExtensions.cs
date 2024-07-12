namespace ReverseInteger;

public static class IntExtensions
{
    public static int Reverse(this int input)
    {
        return CheckedModulo(input);
        // return StringReverse(input);
    }

    public static int CheckedModulo(int input)
    {
        int sign = Math.Sign(input);
        input = Math.Abs(input);

        int output = 0;
        while (input > 0)
        {
            int current = input % 10;
            input /= 10;
            
            try
            {
                checked
                {
                    output *= 10;
                    output += current;
                }
            }
            catch (OverflowException)
            {
                return 0;
            }
        }
        
        return output * sign;
    }

    public static int StringReverse(int input)
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