using PassingTheCodingTestQuestions;

namespace TestProject1;

[TestFixture]
public class WeaveTests
{
    [Test]
    public void Weave_BothArraysEmpty_ReturnsEmptyJaggedArray()
    {
        var left = new int[0];
        var right = new int[0];

        int[][] result = BstSequenceIterative.WeaveArr(left, right);

        Assert.AreEqual(0, result.Length);
    }

    [Test]
    public void Weave_OnlyLeftArrayProvided_ReturnsSingleSequence()
    {
        int[] left = { 1, 2, 3 };
        var right = new int[0];

        int[][] result = BstSequenceIterative.WeaveArr(left, right);

        Assert.AreEqual(1, result.Length);
        CollectionAssert.AreEqual(left, result[0]);
    }

    [Test]
    public void Weave_OnlyRightArrayProvided_ReturnsSingleSequence()
    {
        var left = new int[0];
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

        int[][] expectedSequences =
        {
            new[] { 1, 2, 3, 4 },
            new[] { 1, 3, 2, 4 },
            new[] { 1, 3, 4, 2 },
            new[] { 3, 1, 2, 4 },
            new[] { 3, 1, 4, 2 },
            new[] { 3, 4, 1, 2 }
        };

        Assert.AreEqual(expectedSequences.Length, result.Length);
        foreach (var sequence in expectedSequences) Assert.IsTrue(result.Any(r => r.SequenceEqual(sequence)));
    }

    [Test]
    public void AnCounter()
    {
        var nums = new[] { 1, 2, 2, 2, 3, 3, 4 };
        var res = FindKthMostFrequent(nums, 2);
        Assert.AreEqual(new[] { 2, 3 }, res);
    }

    public static int[] FindKthMostFrequent(int[] nums, int k)
    {
        // Step 1: Count frequencies using a dictionary
        var counter = new Dictionary<int, int>();
        foreach (var num in nums)
            if (counter.ContainsKey(num))
                counter[num]++;
            else
                counter[num] = 1;

        var freq = new int[nums.Length + 1];
        foreach (var (value, count) in counter) freq[count] = value;

        var c = 0;
        //for i length, i != 0; i--
        //
        var accum = new int[k];
        for (var i = 0; i != k; i++) accum[i] = 0;
        for (var i = freq.Length - 1; i != 0; i--)
        {
            if (freq[i] == 0)
                continue;
            if (c == k)
                return accum;
            accum[c] = freq[i];
            c++;
        }

        return accum;
    }
}