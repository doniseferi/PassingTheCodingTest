using PassingTheCodingTestQuestions.Sort;

namespace TestProject1;

[TestFixture]
public class QuickSortTests
{
    [Test]
    public void Test_AlreadySortedArray()
    {
        int[] input = { 1, 2, 3, 4, 5 };
        int[] expected = { 1, 2, 3, 4, 5 };
        var result = QuickSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ReverseSortedArray()
    {
        int[] input = { 5, 4, 3, 2, 1 };
        int[] expected = { 1, 2, 3, 4, 5 };
        var result = QuickSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_UnsortedArray()
    {
        int[] input = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
        int[] expected = { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 };
        var result = QuickSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ArrayWithDuplicates()
    {
        int[] input = { 5, 1, 4, 2, 1, 3 };
        int[] expected = { 1, 1, 2, 3, 4, 5 };
        var result = QuickSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_EmptyArray()
    {
        int[] input = { };
        int[] expected = { };
        var result = QuickSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_SingleElementArray()
    {
        int[] input = { 1 };
        int[] expected = { 1 };
        var result = QuickSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AllElementsSame()
    {
        int[] input = { 7, 7, 7, 7, 7 };
        int[] expected = { 7, 7, 7, 7, 7 };
        var result = QuickSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Partition_SimpleArray_ReturnsCorrectIndexAndPartitionsArray()
    {
        int[] array = { 10, 80, 30, 90, 40, 50, 70 };
        int expectedPartitionIndex = 4;
        int[] expectedArray = { 10, 30, 40, 50, 70, 90, 80 };

        int partitionIndex = QuickSort.Partition(array, 0, array.Length - 1);

        Assert.AreEqual(expectedPartitionIndex, partitionIndex);
        Assert.AreEqual(expectedArray, array);
    }

    [Test]
    public void Partition_ArrayWithAllElementsSame_ReturnsCorrectIndexAndPartitionsArray()
    {
        int[] array = { 5, 5, 5, 5, 5 };
        int expectedPartitionIndex = array.Length - 1;
        int[] expectedArray = { 5, 5, 5, 5, 5 };

        int partitionIndex = QuickSort.Partition(array, 0, array.Length - 1);

        Assert.AreEqual(expectedPartitionIndex, partitionIndex);
        Assert.AreEqual(expectedArray, array);
    }

    [Test]
    public void Partition_ArrayWithNegativeNumbers_ReturnsCorrectIndexAndPartitionsArray()
    {
        int[] array = { -3, -1, -7, -5, -2, -6, -4 };
        int expectedPartitionIndex = 3;
    
        int partitionIndex = QuickSort.Partition(array, 0, array.Length - 1);
    
        var left = array[0..expectedPartitionIndex];
        var right = array.Skip(expectedPartitionIndex + 1).ToArray();
    
        Assert.That(expectedPartitionIndex, Is.EqualTo(partitionIndex));
        Assert.That(left, Is.EquivalentTo(new[] { -7, -6, -5 }));
        Assert.That(right, Is.EquivalentTo(new[] { -1, -2, -3 }));
    }

    [Test]
    public void Partition_ArrayWithSingleElement_ReturnsCorrectIndexAndPartitionsArray()
    {
        int[] array = { 1 };
        int expectedPartitionIndex = 0;
        int[] expectedArray = { 1 };

        int partitionIndex = QuickSort.Partition(array, 0, array.Length - 1);

        Assert.AreEqual(expectedPartitionIndex, partitionIndex);
        Assert.AreEqual(expectedArray, array);
    }

    [Test]
    public void Partition_ArrayWithTwoElements_ReturnsCorrectIndexAndPartitionsArray()
    {
        int[] array = { 2, 1 };
        int expectedPartitionIndex = 0;
        int[] expectedArray = { 1, 2 };

        int partitionIndex = QuickSort.Partition(array, 0, array.Length - 1);

        Assert.AreEqual(expectedPartitionIndex, partitionIndex);
        Assert.AreEqual(expectedArray, array);
    }
}
