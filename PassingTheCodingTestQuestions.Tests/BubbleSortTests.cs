using PassingTheCodingTestQuestions.Sort;

namespace TestProject1;

[TestFixture]
public class BubbleSortTests
{
    [Test]
    public void Test_AlreadySortedArray()
    {
        int[] input = { 1, 2, 3, 4, 5 };
        int[] expected = { 1, 2, 3, 4, 5 };
        var result = BubbleSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ReverseSortedArray()
    {
        int[] input = { 5, 4, 3, 2, 1 };
        int[] expected = { 1, 2, 3, 4, 5 };
        var result = BubbleSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_UnsortedArray()
    {
        int[] input = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
        int[] expected = { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 };
        var result = BubbleSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ArrayWithDuplicates()
    {
        int[] input = { 5, 1, 4, 2, 1, 3 };
        int[] expected = { 1, 1, 2, 3, 4, 5 };
        var result = BubbleSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_EmptyArray()
    {
        int[] input = { };
        int[] expected = { };
        var result = BubbleSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_SingleElementArray()
    {
        int[] input = { 1 };
        int[] expected = { 1 };
        var result = BubbleSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AllElementsSame()
    {
        int[] input = { 7, 7, 7, 7, 7 };
        int[] expected = { 7, 7, 7, 7, 7 };
        var result = BubbleSort.Sort(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}