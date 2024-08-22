
namespace MiceAndHoles;

public static class Travel
{
    public static int MaxSteps(int[] mice, int[] holes)
    {
        int maxSteps = int.MaxValue;

        foreach (IEnumerable<int> micePermutation in GetPermutations(mice, mice.Length))
        {
            int localMax = 0;
            var b = micePermutation.GetEnumerator();

            for (int i = 0; i < mice.Length; ++i)
            {
                b.MoveNext();
                localMax = Math.Max(localMax, Math.Abs(holes[i] - b.Current));
            }

            maxSteps = Math.Min(maxSteps, localMax);
        }

        return maxSteps;
    }

    private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
    {
        if (length == 1) return list.Select(t => new T[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(
                t => list,
                (t1, t2) => t1.Concat([t2]));
    }
}
