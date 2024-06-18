namespace PassingTheCodingTestQuestions.Sort;

public class BubbleSort
{
    public static int[] Sort(int[] arr)
    {
        for (var swap = 0; swap < arr.Length; swap++)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] <= arr[i + 1]) continue;
                
                var temp = arr[i + 1];
                arr[i + 1] = arr[i];
                arr[i] = temp;
            }
        }

        return arr;
    }
}