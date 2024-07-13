using System.Collections;

namespace PartitionMultiset;

public static class Multiset
{
    public static bool Partition(List<int> input)
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