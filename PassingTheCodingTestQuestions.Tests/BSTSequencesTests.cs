using PassingTheCodingTestQuestions;

namespace TestProject1;

[TestFixture]
public class BSTSequencesTests
{
    [Test]
    public void Test_BST_Sequences_1_Node_Tree()
    {
        var node = new Node(1);

        var expectedSequences = new List<List<int>>
        {
            new() { 1 }
        };

        var result = node.GetAllBstSequences();
        Assert.AreEqual(expectedSequences, result);
        var resultIterative = node.GetAllPossibleBstSequences();
        CollectionAssert.AreEquivalent(expectedSequences, resultIterative);
    }

    [Test]
    public void Test_BST_Sequences_3_Node_Tree()
    {
        var node = new Node(2);
        node.Add(1);
        node.Add(3);

        var expectedSequences = new List<List<int>>
        {
            new() { 2, 1, 3 },
            new() { 2, 3, 1 }
        };

        var result = node.GetAllBstSequences();
        CollectionAssert.AreEquivalent(expectedSequences, result);

        var resultIterative = node.GetAllPossibleBstSequences();
        CollectionAssert.AreEquivalent(expectedSequences, resultIterative);
    }

    [Test]
    public void Test_BST_Sequences_3_Node_Right_Skewed_Tree()
    {
        var node = new Node(1);
        node.Add(2);
        node.Add(3);

        var expectedSequences = new List<List<int>>
        {
            new() { 1, 2, 3 }
        };

        var result = node.GetAllBstSequences();
        CollectionAssert.AreEquivalent(expectedSequences, result);
        var resultIterative = node.GetAllPossibleBstSequences();
        CollectionAssert.AreEquivalent(expectedSequences, resultIterative);
    }

    [Test]
    public void Test_BST_Sequences_3_Node_Left_Skewed_Tree()
    {
        var node = new Node(3);
        node.Add(2);
        node.Add(1);

        var expectedSequences = new List<List<int>>
        {
            new() { 3, 2, 1 }
        };

        var result = node.GetAllBstSequences();
        CollectionAssert.AreEquivalent(expectedSequences, result);
        var resultIterative = node.GetAllPossibleBstSequences();
        CollectionAssert.AreEquivalent(expectedSequences, resultIterative);
    }

    [Test]
    public void Test_BST_Sequences_4_Node_Complex_Tree()
    {
        var node = new Node(2);
        node.Add(1);
        node.Add(3);
        node.Add(4);

        var expectedSequences = new List<List<int>>
        {
            new() { 2, 1, 3, 4 },
            new() { 2, 3, 1, 4 },
            new() { 2, 3, 4, 1 }
        };

        var result
            = node.GetAllBstSequences();
        CollectionAssert.AreEquivalent(expectedSequences, result);
    }

/*
         5
       /   \
    3       7
   / \     / \
 1   4    6   9
*/
    [Test]
    public void Test_BST_Sequence_7_Node_Balanced_Complex_Tree()
    {
        var node = new Node(5);
        node.Add(3);
        node.Add(7);
        node.Add(1);
        node.Add(4);
        node.Add(6);
        node.Add(9);

        var expectedSequences = new[]
        {
            new[] { 5, 3, 1, 4, 7, 6, 9 },
            new[] { 5, 3, 1, 7, 4, 6, 9 },
            new[] { 5, 3, 1, 7, 6, 4, 9 },
            new[] { 5, 3, 1, 7, 6, 9, 4 },
            new[] { 5, 3, 7, 1, 4, 6, 9 },
            new[] { 5, 3, 7, 1, 6, 4, 9 },
            new[] { 5, 3, 7, 1, 6, 9, 4 },
            new[] { 5, 3, 7, 6, 1, 4, 9 },
            new[] { 5, 3, 7, 6, 1, 9, 4 },
            new[] { 5, 3, 7, 6, 9, 1, 4 },
            new[] { 5, 7, 3, 1, 4, 6, 9 },
            new[] { 5, 7, 3, 1, 6, 4, 9 },
            new[] { 5, 7, 3, 1, 6, 9, 4 },
            new[] { 5, 7, 3, 6, 1, 4, 9 },
            new[] { 5, 7, 3, 6, 1, 9, 4 },
            new[] { 5, 7, 3, 6, 9, 1, 4 },
            new[] { 5, 7, 6, 3, 1, 4, 9 },
            new[] { 5, 7, 6, 3, 1, 9, 4 },
            new[] { 5, 7, 6, 3, 9, 1, 4 },
            new[] { 5, 7, 6, 9, 3, 1, 4 },
            new[] { 5, 3, 4, 1, 7, 6, 9 },
            new[] { 5, 3, 4, 7, 1, 6, 9 },
            new[] { 5, 3, 4, 7, 6, 1, 9 },
            new[] { 5, 3, 4, 7, 6, 9, 1 },
            new[] { 5, 3, 7, 4, 1, 6, 9 },
            new[] { 5, 3, 7, 4, 6, 1, 9 },
            new[] { 5, 3, 7, 4, 6, 9, 1 },
            new[] { 5, 3, 7, 6, 4, 1, 9 },
            new[] { 5, 3, 7, 6, 4, 9, 1 },
            new[] { 5, 3, 7, 6, 9, 4, 1 },
            new[] { 5, 7, 3, 4, 1, 6, 9 },
            new[] { 5, 7, 3, 4, 6, 1, 9 },
            new[] { 5, 7, 3, 4, 6, 9, 1 },
            new[] { 5, 7, 3, 6, 4, 1, 9 },
            new[] { 5, 7, 3, 6, 4, 9, 1 },
            new[] { 5, 7, 3, 6, 9, 4, 1 },
            new[] { 5, 7, 6, 3, 4, 1, 9 },
            new[] { 5, 7, 6, 3, 4, 9, 1 },
            new[] { 5, 7, 6, 3, 9, 4, 1 },
            new[] { 5, 7, 6, 9, 3, 4, 1 },
            new[] { 5, 3, 1, 4, 7, 9, 6 },
            new[] { 5, 3, 1, 7, 4, 9, 6 },
            new[] { 5, 3, 1, 7, 9, 4, 6 },
            new[] { 5, 3, 1, 7, 9, 6, 4 },
            new[] { 5, 3, 7, 1, 4, 9, 6 },
            new[] { 5, 3, 7, 1, 9, 4, 6 },
            new[] { 5, 3, 7, 1, 9, 6, 4 },
            new[] { 5, 3, 7, 9, 1, 4, 6 },
            new[] { 5, 3, 7, 9, 1, 6, 4 },
            new[] { 5, 3, 7, 9, 6, 1, 4 },
            new[] { 5, 7, 3, 1, 4, 9, 6 },
            new[] { 5, 7, 3, 1, 9, 4, 6 },
            new[] { 5, 7, 3, 1, 9, 6, 4 },
            new[] { 5, 7, 3, 9, 1, 4, 6 },
            new[] { 5, 7, 3, 9, 1, 6, 4 },
            new[] { 5, 7, 3, 9, 6, 1, 4 },
            new[] { 5, 7, 9, 3, 1, 4, 6 },
            new[] { 5, 7, 9, 3, 1, 6, 4 },
            new[] { 5, 7, 9, 3, 6, 1, 4 },
            new[] { 5, 7, 9, 6, 3, 1, 4 },
            new[] { 5, 3, 4, 1, 7, 9, 6 },
            new[] { 5, 3, 4, 7, 1, 9, 6 },
            new[] { 5, 3, 4, 7, 9, 1, 6 },
            new[] { 5, 3, 4, 7, 9, 6, 1 },
            new[] { 5, 3, 7, 4, 1, 9, 6 },
            new[] { 5, 3, 7, 4, 9, 1, 6 },
            new[] { 5, 3, 7, 4, 9, 6, 1 },
            new[] { 5, 3, 7, 9, 4, 1, 6 },
            new[] { 5, 3, 7, 9, 4, 6, 1 },
            new[] { 5, 3, 7, 9, 6, 4, 1 },
            new[] { 5, 7, 3, 4, 1, 9, 6 },
            new[] { 5, 7, 3, 4, 9, 1, 6 },
            new[] { 5, 7, 3, 4, 9, 6, 1 },
            new[] { 5, 7, 3, 9, 4, 1, 6 },
            new[] { 5, 7, 3, 9, 4, 6, 1 },
            new[] { 5, 7, 3, 9, 6, 4, 1 },
            new[] { 5, 7, 9, 3, 4, 1, 6 },
            new[] { 5, 7, 9, 3, 4, 6, 1 },
            new[] { 5, 7, 9, 3, 6, 4, 1 },
            new[] { 5, 7, 9, 6, 3, 4, 1 }
        };

        var result = node.GetAllBstSequences();
        CollectionAssert.AreEquivalent(expectedSequences, result);
        var resultIterative = node.GetAllPossibleBstSequences();
        CollectionAssert.AreEquivalent(expectedSequences, resultIterative);
    }
}