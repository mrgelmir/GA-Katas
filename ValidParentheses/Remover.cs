
namespace ValidParentheses;

public static class Remover
{
    public static int Count(string input)
    {
        int currentDepth = 0;
        int missedClose = 0;

        for (int i = 0; i < input.Length; ++i)
        {
            if (input[i] == '(')
            {
                ++currentDepth;
            }

            if (input[i] == ')' && --currentDepth < 0)
            {
                ++missedClose;
                currentDepth = 0;
            }

        }

        return currentDepth + missedClose;
    }
}
