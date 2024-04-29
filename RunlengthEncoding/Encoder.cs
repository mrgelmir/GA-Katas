
using System.Text;

namespace RunlengthEncoding;

public class Encoder
{
    public string Encode(string input)
    {
        StringBuilder output = new();

        if (input.Length <= 0)
            return "";

        int counter = 0;
        char current = input[0];

        for (int i = 0; i < input.Length; ++i)
        {
            char c = input[i];

            if (c == current)
            {
                ++counter;
            }
            else
            {
                output.Append(counter);
                output.Append(current);
                counter = 1;
                current = c;
            }
        }

        output.Append(counter.ToString());
        output.Append(current);

        return output.ToString();
    }

    public string Decode(string input)
    {
        StringBuilder output = new();
        string currentNumber = "";

        for (int i = 0; i < input.Length; ++i)
        {
            char c = input[i];

            if (char.IsDigit(c))
            {
                currentNumber += c;
            }
            else
            {
                int amount = int.Parse(currentNumber);
                output.Append(input[i], amount);
                currentNumber = "";
            }
        }

        return output.ToString();
    }

}
