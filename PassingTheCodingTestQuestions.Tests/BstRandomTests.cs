using LanguageExt;
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
        IRandomAndBasicBst bst = new RandomAndBasicBst(new BasicNode(10));
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
    public void Delete_NodeWithInOrderSuccessor_CorrectlyUpdatesTree()
    {
        // Arrange: Setting up the initial tree structure
        var root = new BasicNode(50);
        root.AddChild(25);
        root.AddChild(10);
        root.AddChild(5);
        root.AddChild(20);
        root.AddChild(35);
        root.AddChild(27);
        root.AddChild(30);
        var inOrderSuccessorOf27 = 29;
        root.AddChild(inOrderSuccessorOf27);
        root.AddChild(33);
        root.AddChild(75);
        var bst = new RandomAndBasicBst(root);

        // Act: Deleting node 27
        bst.Delete(27);

        // Assert: Check the resulting tree structure
        var rootAfterDeletion = bst.Root.IfNoneUnsafe(() => null);
        Assert.IsNotNull(rootAfterDeletion);
        Assert.AreEqual(50, rootAfterDeletion.Value);

        var leftChildOfRoot = rootAfterDeletion.Left.IfNoneUnsafe(() => null);
        Assert.IsNotNull(leftChildOfRoot);
        Assert.AreEqual(25, leftChildOfRoot.Value);

        var leftChildOf25 = leftChildOfRoot.Left.IfNoneUnsafe(() => null);
        Assert.IsNotNull(leftChildOf25);
        Assert.AreEqual(10, leftChildOf25.Value);

        var leftChildOf10 = leftChildOf25.Left.IfNoneUnsafe(() => null);
        Assert.IsNotNull(leftChildOf10);
        Assert.AreEqual(5, leftChildOf10.Value);

        var rightChildOf10 = leftChildOf25.Right.IfNoneUnsafe(() => null);
        Assert.IsNotNull(rightChildOf10);
        Assert.AreEqual(20, rightChildOf10.Value);

        var rightChildOf25 = leftChildOfRoot.Right.IfNoneUnsafe(() => null);
        Assert.IsNotNull(rightChildOf25);
        Assert.AreEqual(35, rightChildOf25.Value);

        var leftChildOf35 = rightChildOf25.Left.IfNoneUnsafe(() => null);
        Assert.IsNotNull(leftChildOf35);
        Assert.AreEqual(30, leftChildOf35.Value);

        var leftChildOf30 = leftChildOf35.Left.IfNoneUnsafe(() => null);
        Assert.IsNotNull(leftChildOf30);
        Assert.AreEqual(29, leftChildOf30.Value);

        var rightChildOf30 = leftChildOf35.Right.IfNoneUnsafe(() => null);
        Assert.IsNotNull(rightChildOf30);
        Assert.AreEqual(33, rightChildOf30.Value);

        var rightChildOfRoot = rootAfterDeletion.Right.IfNoneUnsafe(() => null);
        Assert.IsNotNull(rightChildOfRoot);
        Assert.AreEqual(75, rightChildOfRoot.Value);

    }
}