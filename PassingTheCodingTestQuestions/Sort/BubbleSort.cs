namespace PassingTheCodingTestQuestions.Sort;

public class BubbleSort
{
    public static int[] Sort(int[] arr)
    {
        if (arr.Length == 1)
            return arr;

        for (var swap = 0; swap < arr.Length; swap++)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var temp = arr[i];
                if (arr[i] > arr[i + 1])
                {
                    temp = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        return arr;
    }
}