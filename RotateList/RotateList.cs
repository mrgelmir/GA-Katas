
namespace RotateList;

public class RotateList
{
    public static void Rotate(List<int> list, int rotations)
    {
        if (rotations == 0)
            return;

        if (rotations < 0)
        {
           rotations = list.Count + rotations;
        }

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
}
