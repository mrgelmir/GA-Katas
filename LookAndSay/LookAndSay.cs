using System.Text;

namespace LookAndSay;

public class LookAndSay
{
    public static string SequenceAt(int iteration)
    {
        string current = "1";

        for (int i = 1; i < iteration; ++i)
        {
            current = Next(current);
        }

        return current;
    }

    public static string Next(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        StringBuilder sb = new();

        char current = input[0];
        int count = 1;
        for (int i = 1; i < input.Length; ++i)
        {
            if (current != input[i])
            {
                sb.Append(count);
                sb.Append(current);

                count = 1;
                current = input[i];
            }
            else
            {
                ++count;
            }
        }

        sb.Append(count);
        sb.Append(current);

        return sb.ToString();
    }
}
