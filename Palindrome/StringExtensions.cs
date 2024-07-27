using System.Text.RegularExpressions;

namespace Palindrome;

public static class StringExtensions
{
    public static bool IsPalindrome(this string input)
    {
        int frontCursor = -1;
        int backCursor = input.Length;

        do
        {
            do
            {
                frontCursor++;
            } while (frontCursor < input.Length && !char.IsLetter(input[frontCursor]));

            do
            {
                backCursor--;
            } while (backCursor > 0 && !char.IsLetter(input[backCursor]));


            if (!char.ToUpper(input[frontCursor]).Equals(char.ToUpper(input[backCursor])))
            {
                return false;
            }
        } while (frontCursor < backCursor);

        return true;
    }

    #region solution by smack for benchmark comparison

    private static string Sanitize(string input) => Regex.Replace(input, "[^a-zA-Z0-9]", "");
    private static bool IsOdd(int number) => number % 2 != 0;

    public static bool IsPalindrome_smack(string input)
    {
        var sanitized = Sanitize(input).ToLower();
        var splitIndex = sanitized.Length / 2;
        var left = sanitized.Substring(0, IsOdd(splitIndex) ? splitIndex : splitIndex + 1);
        var right = new string(sanitized.Substring(splitIndex).Reverse().ToArray());
        return left == right;
    }

    #endregion

    #region ChatGPT

    public static bool IsPalindrome_ChatGPT(string input)
    {
        // Remove non-letter characters and convert to lowercase
        string cleanedInput = Regex.Replace(input, "[^a-zA-Z]", "").ToLower();

        // Check if the cleaned string is a palindrome
        int left = 0;
        int right = cleanedInput.Length - 1;

        while (left < right)
        {
            if (cleanedInput[left] != cleanedInput[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    public static bool IsPalindrome_ChatGPT2(string input)
    {
        int left = 0;
        int right = input.Length - 1;

        while (left < right)
        {
            // Move left pointer to the next letter character
            while (left < right && !char.IsLetter(input[left]))
            {
                left++;
            }

            // Move right pointer to the previous letter character
            while (left < right && !char.IsLetter(input[right]))
            {
                right--;
            }

            // Compare the characters
            if (char.ToLower(input[left]) != char.ToLower(input[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    #endregion
}