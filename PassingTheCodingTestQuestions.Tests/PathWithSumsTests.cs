using PassingTheCodingTestQuestions;
using PassingTheCodingTestQuestions.PathWithSums;

namespace TestProject1;

[TestFixture]
public class PathWithSumsTests
{
    [Test]
    public void TestEmptyTree()
    {
        var root = new Node(0);
        var result = PathWithSumsAlgorithm.GetPathWithSums(root,
            5);
        Assert.AreEqual(0,
            result.Count);
    }

    [Test]
    public void TestSingleNodeTree()
    {
        var root = new Node(5);
        var result = PathWithSumsAlgorithm.GetPathWithSums(root,
            5);
        Assert.AreEqual(1,
            result.Count);
        Assert.AreEqual(0,
            PathWithSumsAlgorithm.GetPathWithSums(root,
                    10)
                .Count);
        Assert.AreEqual(0,
            PathWithSumsAlgorithm.GetPathWithSums(root,
                    1)
                .Count);
    }

    [Test]
    public void TestMultiplePathsToSameSum()
    {
        var root = CreateTreeForMultiplePaths();
        var targetSum = 22; // This should be the sum that multiple paths in your tree add up to
        var result = PathWithSumsAlgorithm.GetPathWithSums(root, targetSum);
        Assert.AreEqual(2, result.Count); // Expecting 2 paths that add up to the target sum
    }

    private Node CreateTreeForMultiplePaths()
    {
        var root = new Node(10);
        root.Add(5); // Left child of root
        root.Add(12); // Right child of root

        // Adding children to the left child of the root
        root.Left.IfSome(left =>
        {
            left.Add(4); // Left child of left node
            left.Add(3); // Right child of left node
        });

        // Adding children to the right child of the root
        root.Right.IfSome(right =>
        {
            right.Add(7); // Right child of right node
        });

        return root;
    }

    [Test]
    public void TestOnlyLeftSubtree()
    {
        var root = CreateTestTree();
        Assert.AreEqual(2,
            PathWithSumsAlgorithm.GetPathWithSums(root,
                    15)
                .Count);
    }

    [Test]
    public void TestOnlyRightSubtree()
    {
        var root = CreateTestTree();
        Assert.AreEqual(1,
            PathWithSumsAlgorithm.GetPathWithSums(root,
                    25)
                .Count);
    }

    [Test]
    public void TestNegativeNumbers()
    {
        var root = CreateTestTreeWithNegatives();
        Assert.AreEqual(1,
            PathWithSumsAlgorithm.GetPathWithSums(root,
                    -5)
                .Count);
    }

    [Test]
    public void TestPathNotStartingOrEndingAtRootLeaf()
    {
        var root = CreateTestTree();
        Assert.AreEqual(1,
            PathWithSumsAlgorithm.GetPathWithSums(root.Right.IfNone(() => throw new ArgumentNullException()),
                    15)
                .Count);
    }

    [Test]
    public void TestLargeTree()
    {
        var root = CreateLargeTestTree();
        Assert.AreEqual(2,
            PathWithSumsAlgorithm.GetPathWithSums(root,
                    100)
                .Count);
    }

    [Test]
    public void TestPathSumGreaterThanAnyNodeValue()
    {
        var root = CreateTestTree();
        Assert.AreEqual(0,
            PathWithSumsAlgorithm.GetPathWithSums(root,
                    50)
                .Count);
    }

    private Node CreateTestTree()
    {
        var root = new Node(10);
        root.Add(5);
        root.Add(15);
        var n = root.ToIntArray();
        return root;
    }

    private Node CreateTestTreeWithNegatives()
    {
        var root = new Node(-10);
        root.Add(-15);
        root.Add(-5);
        return root;
    }

    private Node CreateLargeTestTree()
    {
        var root = new Node(50);
        for (var i = 1;
             i <= 100;
             i++)
            root.Add(i);

        return root;
    }
}