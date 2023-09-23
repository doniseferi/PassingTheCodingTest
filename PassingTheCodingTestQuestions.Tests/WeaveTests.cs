using PassingTheCodingTestQuestions;

namespace TestProject1;

[TestFixture]
public class WeaveTests
{
    [Test]
    public void Weave_BothArraysEmpty_ReturnsEmptyJaggedArray()
    {
        int[] left = new int[0];
        int[] right = new int[0];

        int[][] result = BstSequenceIterative.WeaveArr(left, right);

        Assert.AreEqual(0, result.Length);
    }

    [Test]
    public void Weave_OnlyLeftArrayProvided_ReturnsSingleSequence()
    {
        int[] left = { 1, 2, 3 };
        int[] right = new int[0];

        int[][] result = BstSequenceIterative.WeaveArr(left, right);

        Assert.AreEqual(1, result.Length);
        CollectionAssert.AreEqual(left, result[0]);
    }

    [Test]
    public void Weave_OnlyRightArrayProvided_ReturnsSingleSequence()
    {
        int[] left = new int[0];
        int[] right = { 4, 5, 6 };

        int[][] result = BstSequenceIterative.WeaveArr(left, right);

        Assert.AreEqual(1, result.Length);
        CollectionAssert.AreEqual(right, result[0]);
    }

    [Test]
    public void Weave_BothArraysProvided_ReturnsAllWeavedSequences()
    {
        int[] left = { 1, 2 };
        int[] right = { 3, 4 };

        int[][] result = BstSequenceIterative.WeaveArr(left, right);

        int[][] expectedSequences = {
            new[] {1, 2, 3, 4},
            new[] {1, 3, 2, 4},
            new[] {1, 3, 4, 2},
            new[] {3, 1, 2, 4},
            new[] {3, 1, 4, 2},
            new[] {3, 4, 1, 2} 
        };

        Assert.AreEqual(expectedSequences.Length, result.Length);
        foreach (int[] sequence in expectedSequences)
        {
            Assert.IsTrue(result.Any(r => Enumerable.SequenceEqual(r, sequence)));
        }
    }
}