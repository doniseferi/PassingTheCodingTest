namespace PassingTheCodingTestQuestions.MergeSort;

public class MergeSort
{
    public static int[] Sort(int[] arr)
    {
        MergeSortRecursive(arr, 0, arr.Length - 1);
        return arr;
    }

    private static void Merge(int[] array, int leftIndex, int middleIndex, int rightIndex)
    {
        var leftSubArrayLength = middleIndex - leftIndex + 1;
        var rightSubArrayLength = rightIndex - middleIndex;

        var leftSubArray = new int[leftSubArrayLength];
        var rightSubArray = new int[rightSubArrayLength];

        for (var i = 0; i < leftSubArrayLength; i++) leftSubArray[i] = array[leftIndex + i];

        for (var i = 0; i < rightSubArrayLength; i++) rightSubArray[i] = array[middleIndex + 1 + i];
        var leftSubArrayIndex = 0;
        var rightSubArrayIndex = 0;
        var mergedArrayIndex = leftIndex;

        while (leftSubArrayIndex < leftSubArrayLength && rightSubArrayIndex < rightSubArrayLength)
        {
            if (leftSubArray[leftSubArrayIndex] <= rightSubArray[rightSubArrayIndex])
            {
                array[mergedArrayIndex] = leftSubArray[leftSubArrayIndex];
                leftSubArrayIndex++;
            }
            else
            {
                array[mergedArrayIndex] = rightSubArray[rightSubArrayIndex];
                rightSubArrayIndex++;
            }

            mergedArrayIndex++;
        }

        while (leftSubArrayIndex < leftSubArrayLength)
        {
            array[mergedArrayIndex] = leftSubArray[leftSubArrayIndex];
            leftSubArrayIndex++;
            mergedArrayIndex++;
        }

        while (rightSubArrayIndex < rightSubArrayLength)
        {
            array[mergedArrayIndex] = rightSubArray[rightSubArrayIndex];
            rightSubArrayIndex++;
            mergedArrayIndex++;
        }
    }

    private static void MergeSortRecursive(int[] array, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex) return;
        var middleIndex = (leftIndex + rightIndex) / 2;

        MergeSortRecursive(array, leftIndex, middleIndex);
        MergeSortRecursive(array, middleIndex + 1, rightIndex);

        Merge(array, leftIndex, middleIndex, rightIndex);
    }
}