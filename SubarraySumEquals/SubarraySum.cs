namespace SubarraySumEquals;

public static class SubarraySum
{
    public static List<int> Find(List<int> input, int number)
    {
        if (input.Count <= 0)
            return input;

        if (input[0] == number)
            return input;

        if (input.Count == 1)
            return [];

        int start = 0;
        int end = 0;
        int sum = input[start];
        
        while (end < input.Count-1)
        {
            end += 1;
            sum += input[end];

            while (sum > number && start <= end)
            {
                sum -= input[start];
                ++start;
            }

            if (sum == number)
            {
                return input[start..(end + 1)];
            }
        }

        return [];
    }
}