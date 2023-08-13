using System.Diagnostics;
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
            new List<int> { 1 }
        };

        Assert.AreEqual(expectedSequences, node.GetAllBSTSequences());
    }

    [Test]
    public void Test_BST_Sequences_3_Node_Tree()
    {
        var node = new Node(2);
        node.Add(1);
        node.Add(3);

        var expectedSequences = new List<List<int>>
        {
            new List<int> { 2, 1, 3 },
            new List<int> { 2, 3, 1 }
        };

        var n = node.ConverstAllBSTSequencesToString();

        CollectionAssert.AreEquivalent(expectedSequences, node.GetAllBSTSequences());
    }

    [Test]
    public void Test_BST_Sequences_3_Node_Right_Skewed_Tree()
    {
        var node = new Node(1);
        node.Add(2);
        node.Add(3);

        var expectedSequences = new List<List<int>>
        {
            new List<int> { 1, 2, 3 }
        };

        CollectionAssert.AreEquivalent(expectedSequences, node.GetAllBSTSequences());
    }

    [Test]
    public void Test_BST_Sequences_3_Node_Left_Skewed_Tree()
    {
        var node = new Node(3);
        node.Add(2);
        node.Add(1);

        var expectedSequences = new List<List<int>>
        {
            new List<int> { 3, 2, 1 }
        };

        CollectionAssert.AreEquivalent(expectedSequences, node.GetAllBSTSequences());
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
            new List<int> { 2, 1, 3, 4 },
            new List<int> { 2, 3, 1, 4 },
            new List<int> { 2, 3, 4, 1 }
        };

        var act = node.ConverstAllBSTSequencesToString();
        
        CollectionAssert.AreEquivalent(expectedSequences, node.GetAllBSTSequences());
    }

    [Test]
    public void Test_BST_Sequences_Empty_Tree()
    {
        Node node = null;

        Assert.Throws<ArgumentNullException>(() => node.GetAllBSTSequences());
    }
}
