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


        StringBuilder sb = new();
        for (int i = 0; i < strings.Count; ++i)
        {
            sb.Append(strings[i]);
        }

        string bleh = sb.ToString();
        return int.Parse(bleh);
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


        StringBuilder sb = new();
        for (int i = 0; i < strings.Count; ++i)
        {
            sb.Append(strings[i]);
        }

        return int.Parse(sb.ToString());
    }

    public static int ModuloImplementation(int[] input)
    {
        if (input.Length <= 0)
            return 0;

        List<int> strings = [.. input];
        List<byte> aDigits = [];
        List<byte> bDigits = [];

        strings.Sort((a, b) =>
        {
            aDigits.Clear();
            bDigits.Clear();

            while (a > 0)
            {
                aDigits.Insert(0, (byte)(a % 10));
                a /= 10;
            }

            while (b > 0)
            {
                bDigits.Insert(0, (byte)(b % 10));
                b /= 10;
            }

            int maxIndex = int.Min(aDigits.Count, bDigits.Count);
            for (int i = 0; i < maxIndex; ++i)
            {
                int comparison = -aDigits[i].CompareTo(bDigits[i]);
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

    public static int ArrayImplementation(int[] input)
    {
        // start with a reversed array of all info
        // [5, 10]
        // => [0,1,2(length),5,1(length)]
        List<byte> bytes = [];

        // These are the indices of the input entries.
        // They point to the size byte
        List<int> orderedIndices = new(input.Length);
        orderedIndices.AddRange(new int[input.Length]);

        int maxLength = 0;
        for (int i = 0; i < input.Length; ++i)
        {
            byte length = 0;
            int number = input[i];

            while (number > 0)
            {
                byte digit = (byte)(number % 10);

                bytes.Add(digit);

                ++length;
                number /= 10;
            }

            bytes.Add(length);
            orderedIndices[i] = bytes.Count - 1;
            maxLength = int.Max(maxLength, length);
        }

        // Now we order the indices
        orderedIndices.Sort((a, b) =>
        {
            return Value(b) - Value(a);

            // Calculate a sorting value
            // TODO: pre-calculate this value later for easier usage
            // This does need the 
            int Value(int startIndex)
            {
                byte lenght = bytes[startIndex];
                int multiplier = int.Max(1, (maxLength - 1) * 10);
                int value = 0;

                for (byte i = 0; i < lenght; ++i)
                {
                    value += multiplier * bytes[startIndex - 1 - i];
                    multiplier /= 10;
                }

                while (multiplier >= 1)
                {
                    value += 9 * multiplier;
                    multiplier /= 10;
                }

                return value;
            }
        });

        int result = 0;

        for (int ii = 0; ii < orderedIndices.Count; ++ii)
        {
            var index = orderedIndices[ii];
            byte lenght = bytes[index];
            for (byte i = 0; i < lenght; ++i)
            {
                result *= 10;
                result += bytes[index - 1 - i];
            }
        }

        return result;
    }

    public static int ArrayImplementation_PrecomputedValues(int[] input)
    {
        // start with a reversed array of all info
        // [5, 10]
        // => [0,1,2(length),5,1(length)]
        List<byte> bytes = [];

        // These are the indices of the input entries.
        // They point to the size byte
        List<(int index, int value)> orderedIndices = new(input.Length);
        orderedIndices.AddRange(new (int, int)[input.Length]);

        int maxLength = 0;
        for (int i = 0; i < input.Length; ++i)
        {
            byte length = 0;
            int number = input[i];

            while (number > 0)
            {
                byte digit = (byte)(number % 10);

                bytes.Add(digit);

                ++length;
                number /= 10;
            }

            bytes.Add(length);
            orderedIndices[i] = (bytes.Count - 1, 0);
            maxLength = int.Max(maxLength, length);
        }

        // We can only calculate values once maxLength is known
        for (int i = 0; i < orderedIndices.Count; ++i)
        {
            (int index, _) = orderedIndices[i];
            orderedIndices[i] = (index, Value(index));
        }

        // Now we order the indices
        orderedIndices.Sort((a, b) =>
        {
            return b.value - a.value;
        });

        int result = 0;

        for (int ii = 0; ii < orderedIndices.Count; ++ii)
        {
            (int index, _) = orderedIndices[ii];
            byte lenght = bytes[index];
            for (byte i = 0; i < lenght; ++i)
            {
                result *= 10;
                result += bytes[index - 1 - i];
            }
        }

        return result;

        int Value(int startIndex)
        {
            byte lenght = bytes[startIndex];
            int multiplier = int.Max(1, (maxLength - 1) * 10);
            int value = 0;

            for (byte i = 0; i < lenght; ++i)
            {
                value += multiplier * bytes[startIndex - 1 - i];
                multiplier /= 10;
            }

            // Count all remaining digits as nine
            while (multiplier >= 1)
            {
                value += 9 * multiplier;
                multiplier /= 10;
            }

            return value;
        }
    }
}
