using LanguageExt;
using Newtonsoft.Json;
using PassingTheCodingTestQuestions.Extensions;
using PassingTheCodingTestQuestions.RandomNodeQuestion;

namespace TestProject1;

using NUnit.Framework;

[TestFixture]
public class BstRandomTests
{
    private IRandomAndBasicBst _randomAndBasicBst;

    [SetUp]
    public void SetUp()
    {
        var root = new BasicNode(100);
        root.AddChild(
            50);
        root.AddChild(25);
        root.AddChild(10);
        root.AddChild(30);
        root.AddChild(75);
        root.AddChild(66);
        root.AddChild(89);
        root.AddChild(200);
        root.AddChild(150);
        root.AddChild(125);
        root.AddChild(177);
        root.AddChild(300);
        _randomAndBasicBst = new RandomAndBasicBst(root);
    }

    [Test]
    public void Find_NodeWithMatchingValue_ReturnsNode()
    {
        // Arrange
        int existingValue = 75;
        var result = _randomAndBasicBst.Find(existingValue);

        // Assert
        Assert.IsTrue(result.IsSome);
    }

    [Test]
    public void Find_NodeWithNonExistentValue_ReturnsNone()
    {
        // Act
        var result = _randomAndBasicBst.Find(99);

        // Assert
        Assert.IsTrue(result.IsNone);
    }

    [Test]
    [TestCase(100, 13)]
    [TestCase(50, 7)]
    [TestCase(25, 3)]
    [TestCase(10, 1)]
    [TestCase(30, 1)]
    [TestCase(75, 3)]
    [TestCase(66, 1)]
    [TestCase(89, 1)]
    [TestCase(200, 5)]
    [TestCase(150, 3)]
    [TestCase(125, 1)]
    [TestCase(177, 1)]
    [TestCase(300, 1)]
    public void TestNodeWithValueCount(int value, int expectedCount)
    {
        _randomAndBasicBst.Find(value).Match(
            None: () => Assert.Fail(),
            Some: node =>
            {
                var actualCount = node.Count();
                Assert.That(actualCount, Is.EqualTo(expectedCount));
            });
    }

    [Test]
    public void Delete_NodeExists_NodeDeleted()
    {
        IRandomAndBasicBst bst = new RandomAndBasicBst(
            new BasicNode(10));
        bst.Insert(5);
        bst.Insert(15);

        bst.Delete(5);

        // Assert 
        Assert.That(bst.Find(5), Is.EqualTo(Option<IBasicNode>.None));
    }


    [Test]
    public void Delete_NodeHasOneChild_ChildReplacesDeletedNodeWithLeftNode()
    {
        IRandomAndBasicBst bst = new RandomAndBasicBst(new BasicNode(10));
        var childValue = 5;
        bst.Insert(childValue);

        // Act
        bst.Delete(10);

        bst.Root.Match(None: () => Assert.Fail(),
            Some: r => Assert.That(r.Value, Is.EqualTo(childValue)));
    }

    [Test]
    public void Delete_NodeHasOneChild_ChildReplacesDeletedNodeWithRightNode()
    {
        IRandomAndBasicBst bst = new RandomAndBasicBst(new BasicNode(10));
        var childValue = 15;
        bst.Insert(childValue);

        // Act
        bst.Delete(10);

        bst.Root.Match(None: () => Assert.Fail(),
            Some: r => Assert.That(r.Value, Is.EqualTo(childValue)));
    }

    [Test]
    public void Delete_NodeWithTwoChildren_ReturnsInOrderSuccessor()
    {
        var bst = CreateBstWithTestData();
        var n2 = JsonConvert.SerializeObject(bst);

        bst.Delete(21);
        var n = JsonConvert.SerializeObject(bst);
        Assert.That(bst.Find(21), Is.EqualTo(Option<IBasicNode>.None));

        var root = bst.Root.UnpackUnsafely();
        var inorderSuccessor = root.Left.UnpackUnsafely();
        Assert.That(inorderSuccessor.Value, Is.EqualTo(24));
    }
    
    [Test]
    public void Delete_NodeWithInOrderSuccessor_AndInOrderSuccessorHasChildren_CorrectlyUpdatesInOrderSuccessorWithChild()
    {
        var bst = CreateBstWithTestData();

        bst.Delete(21);
        Assert.That(bst.Find(21), Is.EqualTo(Option<IBasicNode>.None));

        var root = bst.Root.UnpackUnsafely();
        var inorderSuccessor = root.Left.UnpackUnsafely();
        Assert.That(inorderSuccessor.Value, Is.EqualTo(24));

        var twentySeven = bst.Find(27).UnpackUnsafely();
        var leftChildOfTwentySeven = twentySeven.Left.UnpackUnsafely();
        Assert.That(leftChildOfTwentySeven.Value, Is.EqualTo(26));
    }
    
    [Test]
    [TestCase(50, 75)]
    [TestCase(21, 24)]
    [TestCase(10, 20)]
    [TestCase(24, 26)]
    [TestCase(30, 33)]
    [TestCase(27, 29)]
    public void GetNextInOrderSuccessor_ReturnsCorrectSuccessor(int startingNode, int expectedSuccessor)
    {
        var bst = CreateBstWithTestData();
        var node = bst.Find(startingNode).UnpackUnsafely();
        var successor = node
            .GetNextInOrderSuccessor()
            .UnpackUnsafely();

        Assert.That(successor.Value, Is.EqualTo(expectedSuccessor));
    }

    [Test]
    public void GetNextInOrderSuccessor_WithNoChildren_ReturnsNone()
    {
        var bst = CreateBstWithTestData();
        var node = bst.Find(75).UnpackUnsafely();
        var successor = node.GetNextInOrderSuccessor();

        Assert.That(successor, Is.EqualTo(Option<IBasicNode>.None));
    }

    private RandomAndBasicBst CreateBstWithTestData()
    {
        var root = new BasicNode(50);
        root.AddChild(21);
        root.AddChild(10);
        root.AddChild(5);
        root.AddChild(20);
        root.AddChild(27);
        root.AddChild(30);
        root.AddChild(33);
        root.AddChild(75);
        root.AddChild(29);
        root.AddChild(24);
        root.AddChild(26);
        return new RandomAndBasicBst(root);
    }
}