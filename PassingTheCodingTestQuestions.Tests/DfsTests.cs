using PassingTheCodingTestQuestions;

namespace TestProject1;

[TestFixture]
public class DfsTests
{
    private Node _root;

    [SetUp]
    public void SetUp()
    {
        // Initialize the root node
        _root = new Node(4);

        // Manually add nodes to create a balanced BST
        _root.Add(2);
        _root.Add(6);
        _root.Add(1);
        _root.Add(3);
        _root.Add(5);
        _root.Add(7);

        // Ensure the tree structure is as expected:
        //         4
        //       /   \
        //      2     6
        //     / \   / \
        //    1   3 5   7
    }

    [Test]
    public void Test_FindExistingValue()
    {
        var result = DepthFirstSearch.Search_(_root, 5);
        Assert.That(result.Value, Is.EqualTo(5));
    }

    [Test]
    public void Test_FindRootValue()
    {
        var result = DepthFirstSearch.Search_(_root, 4);
        Assert.That(result.Value, Is.EqualTo(4));
    }

    [Test]
    public void Test_ValueNotFound()
    {
        Assert.Throws<KeyNotFoundException>(() => DepthFirstSearch.Search_(_root, 10));
    }

    [Test]
    public void Test_FindLeftmostValue()
    {
        var result = DepthFirstSearch.Search_(_root, 1);
        Assert.That(result.Value, Is.EqualTo(1));
    }

    [Test]
    public void Test_FindRightmostValue()
    {
        var result = DepthFirstSearch.Search_(_root, 7);
        Assert.That(result.Value, Is.EqualTo(7));
    }

    [Test]
    public void Test_FindInSingleNodeTree()
    {
        var singleNode = new Node(1);
        var result = DepthFirstSearch.Search_(singleNode, 1);
        Assert.That(result.Value, Is.EqualTo(1));
    }

    [Test]
    public void Test_ValueNotFoundInSingleNodeTree()
    {
        var singleNode = new Node(1);
        Assert.Throws<KeyNotFoundException>(() => DepthFirstSearch.Search_(singleNode, 2));
    }
}
