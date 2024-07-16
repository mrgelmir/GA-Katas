using System.Text;

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

        List<string> strings = input.Select(i => i.ToString()).ToList();
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

    public static int StringImplementation2(int[] input)
    {
        if (input.Length <= 0)
            return 0;

        List<string> strings = input.Select(i => i.ToString()).ToList();
        strings.Sort((a, b) =>
        {
            string order1 = a + b;
            string order2 = b + a;
            return order2.CompareTo(order1);
        });

        return int.Parse(strings.Aggregate("", (a, element) => a += element));
    }

    public static int ModuloImplementation(int[] input)
    {
        if (input.Length <= 0)
            return 0;

        List<int> strings = [.. input];
        List<int> aDigits = [];
        List<int> bDigits = [];

        strings.Sort((a, b) =>
        {
            aDigits.Clear();
            bDigits.Clear();

            while (a > 0)
            {
                aDigits.Insert(0, a % 10);
                a /= 10;
            }

            while (b > 0)
            {
                bDigits.Insert(0, b % 10);
                b /= 10;
            }

            int maxIndex = int.Min(aDigits.Count, bDigits.Count);
            for (int i = 0; i < maxIndex; ++i)
            {
                int comparison = aDigits[i].CompareTo(bDigits[i]);
                if (comparison != 0)
                    return comparison;
            }


            return aDigits.Count - bDigits.Count;
        });

        StringBuilder sb = new();
        for (int i = 0; i < strings.Count; ++i)
        {
            sb.Append(strings[i]);
        }

        return int.Parse(sb.ToString());
    }
}
