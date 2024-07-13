using System.Collections;

namespace PartitionMultiset;

public static class Multiset
{
    public static bool PartitionWithDP(IList<int> input)
    {
        int sum = input.Sum();
        if (sum == 0 || sum % 2 != 0)
            return false;

        int targetSum = sum / 2;
        BitArray solutions = new(targetSum + 1)
        {
            [0] = true
        };

        foreach (int number in input)
        {
            for (int i = targetSum; i >= number; i--)
            {
                solutions[i] = solutions[i] || solutions[i - number];
            }
        }


        return solutions[targetSum];
    }

    public static bool PartitionWithBitArray(IList<int> input)
    {
        if (input.Count <= 1)
            return false;

        foreach (BitArray bitArray in GetPermutations(input.Count))
        {
            int sum1 = input
                .Where((_, index) => bitArray[index])
                .Sum();
            int sum2 = input
                .Where((_, index) => !bitArray[index])
                .Sum();

            if (sum1 == sum2)
                return true;
        }

        return false;
    }

    private static IEnumerable<BitArray> GetPermutations(int count)
    {
        for (int i = 0; i < 1 << count; i++)
        {
            byte[] bytes = BitConverter.GetBytes(i);
            yield return new BitArray(bytes);
        }
    }
}