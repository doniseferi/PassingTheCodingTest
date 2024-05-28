using PassingTheCodingTestQuestions.MergeSort;

namespace TestProject1;

[TestFixture]
public class MergeSortTests
{
    [Test]
    public void Test_SortedArray()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        int[] expected = { 1, 2, 3, 4, 5 };

        MergeSort.Sort(array);

        Assert.AreEqual(expected, array);
    }

    [Test]
    public void Test_ReverseSortedArray()
    {
        int[] array = { 5, 4, 3, 2, 1 };
        int[] expected = { 1, 2, 3, 4, 5 };

        MergeSort.Sort(array);

        Assert.AreEqual(expected, array);
    }

    [Test]
    public void Test_UnsortedArray()
    {
        int[] array = { 12, 11, 13, 5, 6, 7 };
        int[] expected = { 5, 6, 7, 11, 12, 13 };

        MergeSort.Sort(array);

        Assert.AreEqual(expected, array);
    }

    [Test]
    public void Test_ArrayWithDuplicates()
    {
        int[] array = { 4, 2, 2, 8, 3, 3, 1 };
        int[] expected = { 1, 2, 2, 3, 3, 4, 8 };

        MergeSort.Sort(array);

        Assert.AreEqual(expected, array);
    }

    [Test]
    public void Test_SingleElementArray()
    {
        int[] array = { 1 };
        int[] expected = { 1 };

        MergeSort.Sort(array);

        Assert.AreEqual(expected, array);
    }

    [Test]
    public void Test_EmptyArray()
    {
        int[] array = { };
        int[] expected = { };

        MergeSort.Sort(array);

        Assert.AreEqual(expected, array);
    }
}
