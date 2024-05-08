namespace SubarraySumEquals;

public static class SubarraySum
{
    public static List<int> Find(List<int> input, int number)
    {
        if (input.Count <= 0)
            return input;

        if (input[0] == number)
            return input;

        for (int startIndex = 0; startIndex < input.Count; startIndex++)
        {
            int sum = 0;
            for (int i = startIndex; i < input.Count; i++)
            {
                sum += input[i];

                if (sum == number)
                {
                    return input[startIndex..(i + 1)];
                }
                
                if(sum > number)
                    break;
            }
        }

        return [];
    }
}