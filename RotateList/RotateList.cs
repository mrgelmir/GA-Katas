
namespace RotateList;

public class RotateList
{
    public static void Rotate(List<int> list, int rotations)
    {
        if (rotations == 0)
            return;

        rotations = SanitiseRotations(list.Count, rotations);

        for (int rotation = 0; rotation < rotations; ++rotation)
        {
            int start = list[0];

            for (int i = 0; i < list.Count - 1; ++i)
            {
                list[i] = list[i + 1];
            }

            list[^1] = start;
        }
    }

    private static int SanitiseRotations(int lenght, int rotations)
    {
        rotations %= lenght;

        if (rotations < 0)
        {
            rotations = lenght + rotations;
        }

        return rotations;
    }
}
