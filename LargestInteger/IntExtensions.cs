namespace LargestInteger;

public static class IntExtensions
{
    public static int ConstructLargestInt(int[] input)
    {
        return StringImplementation1(input);
    }

    public static int StringImplementation1(int[] input)
    {
        if (input.Length <= 0)
            return 0;

        var strings = input.Select(i => i.ToString()).ToList();
        strings.Sort(SpecificSort);

        return int.Parse(strings.Aggregate("", (a, element) => a += element));
    }

    private static int SpecificSort(string a, string b)
    {
        if (a.Length == b.Length)
            return -string.Compare(a, b);

        int maxIndex = int.Min(a.Length, b.Length);

        for (int i = 0; i < maxIndex; ++i)
        {
            int comparison = b[i] - a[i];
            if (comparison == 0)
                continue;

            return comparison;
        }

        return a.Length - b.Length;
    }
}
