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
}