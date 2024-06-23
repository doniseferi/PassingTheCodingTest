namespace PassingTheCodingTestQuestions.Sort;

public static class QuickSort
{
    public static int[] Sort(int[] arr)
    {
        if (arr.Length <= 1)
            return arr;

        const int startingIndex = 0;
        var lastIndex = arr.Length - 1;
        Sort(arr, startingIndex, lastIndex);
        return arr;
    }

    private static void Sort(int[] arr, int startingIndex, int lastIndex)
    {
        if (startingIndex >= lastIndex || startingIndex < 0)
            return;

        var partition = Partition(arr, startingIndex, lastIndex);
        Sort(arr, startingIndex, partition - 1);
        Sort(arr, partition + 1, lastIndex);
    }

    public static int Partition(int[] arr, int startingIndex, int lastIndex)
    {
        var pivot = arr[lastIndex];
        var smallestIndex = startingIndex - 1;
        for (var i = startingIndex; i < lastIndex; i++)
        {
            if (arr[i] > pivot)
                continue;

            smallestIndex++;
            var _temp = arr[smallestIndex];
            arr[smallestIndex] = arr[i];
            arr[i] = _temp;
        }

        //swap last index (the pivot) for the smallestIndex (the calculated partition
        //everything to the left of the partitioned index is less than the value in
        //the partitioned value and everything to the right is greater than the value in the smallestIndex (partition) index)
        var temp = arr[lastIndex];
        arr[lastIndex] = arr[smallestIndex + 1];
        arr[smallestIndex + 1] = temp;
        return smallestIndex + 1;
    }
}