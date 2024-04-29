
namespace RunlengthEncoding;

public class Encoder
{
    public string Encode(string input)
    {
        string output = "";

        if (input.Length <= 0)
            return output;

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
                output += counter.ToString() + current;
                counter = 1;
                current = c;
            }
        }

        output += counter.ToString() + current;

        return output;
    }

    public string Decode(string input)
    {
        string output = "";
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
                output += new string(input[i], amount);
                currentNumber = "";
            }
        }
        return output;
    }

}
