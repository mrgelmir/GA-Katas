using System.Text;

namespace ReverseDelimiters;

public static class StringReverseExtensions
{
    public static string ReverseWithDelimiters(this string input, params char[] delimiters)
    {
        if (delimiters.Length <= 0)
            return input;

        string[] reversedParts = input
            .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            .Reverse()
            .ToArray();

        const char token = '@';

        string tokenString = CreateTokenString(input, delimiters, token);

        return ReplaceTokens(tokenString, reversedParts, token);
    }

    private static string CreateTokenString(string input, char[] delimiters, char token)
    {
        StringBuilder tokenBuilder = new();
        int currentLength = 0;
        for (int i = 0; i < input.Length; ++i)
        {
            if (delimiters.Contains(input[i]))
            {
                if (currentLength > 0)
                    tokenBuilder.Append(token);

                tokenBuilder.Append(input[i]);

                currentLength = 0;
            }
            else
            {
                ++currentLength;
            }
        }
        if (currentLength > 0)
            tokenBuilder.Append(token);

        return tokenBuilder.ToString();
    }

    private static string ReplaceTokens(string tokenString, string[] reversedParts, char token)
    {
        StringBuilder resultBuilder = new();
        int partIndex = -1;

        for (int i = 0; i < tokenString.Length; ++i)
        {
            if (tokenString[i] == token)
            {
                resultBuilder.Append(reversedParts[++partIndex]);
            }
            else
            {
                resultBuilder.Append(tokenString[i]);
            }
        }

        return resultBuilder.ToString();
    }
}
