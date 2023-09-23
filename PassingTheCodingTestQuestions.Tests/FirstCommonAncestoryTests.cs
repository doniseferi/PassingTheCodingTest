using LanguageExt;
using PassingTheCodingTestQuestions;

namespace TestProject1;

[TestFixture]
public class FirstCommonAncestoryTests
{
    private Option<Node> _root;

    [SetUp]
    public void Setup()
    {
        /*
    5
   / \
  3   7
 / \ / \
2  4 6  8
         */
        _root = new Node(5);
        _root.Iter(x => x.Add(3));
        _root.Iter(x => x.Add(7));
        _root.Iter(x => x.Add(2));
        _root.Iter(x => x.Add(4));
        _root.Iter(x => x.Add(6));
        _root.Iter(x => x.Add(8));
    }
    
    [Test]
    public void FindCommonAncestor_ReturnsCorrectAncestor_ForNodesAtDifferentLevelsSubtree()
    {
        var commonAncestor = _root.GetFistCommonAncestor(new Node(4), new Node(7));

        // The common ancestor of 2 and 4 should be 3.
        Assert.IsTrue(commonAncestor.IsSome);
        commonAncestor.Match(Some: x => Assert.That(x.Value, Is.EqualTo(5)), None: () => Assert.Fail());
    }

    [Test]
    public void FindCommonAncestor_ReturnsCorrectAncestor_ForLeftSubtree()
    {
        var commonAncestor = _root.GetFistCommonAncestor(new Node(2), new Node(4));

        // The common ancestor of 2 and 4 should be 3.
        Assert.IsTrue(commonAncestor.IsSome);
        commonAncestor.Match(Some: x => Assert.That(x.Value, Is.EqualTo(3)), None: () => Assert.Fail());
    }

    [Test]
    public void FindCommonAncestor_ReturnsCorrectAncestor_ForRightSubtree()
    {
        var commonAncestor = _root.GetFistCommonAncestor(new Node(6), new Node(8));

        // The common ancestor of 6 and 8 should be 7.
        commonAncestor.Match(Some: x => Assert.That(x.Value, Is.EqualTo(7)), None: () => Assert.Fail());
    }

    [Test]
    public void FindCommonAncestor_ReturnsCorrectAncestor_ForNodesOnDifferentSides()
    {
        var commonAncestor = _root.GetFistCommonAncestor(new Node(4), new Node(6));
        
        // The common ancestor of 4 and 6 should be 5.
        commonAncestor.Match(Some: x => Assert.That(x.Value, Is.EqualTo(5)), None: () => Assert.Fail());
    }

    [Test]
    public void FindCommonAncestor_ReturnsRoot_ForValuesOnOppositeSidesOfRoot()
    {
        var commonAncestor = _root.GetFistCommonAncestor(new Node(2), new Node(8));

        // The common ancestor of 2 and 8 should be the root (5).
        commonAncestor.Match(Some: x => Assert.That(x.Value, Is.EqualTo(5)), None: () => Assert.Fail());
    }

    [Test]
    public void FindCommonAncestor_ReturnsNull_WhenOneValueIsAbsent()
    {
        var commonAncestor = _root.GetFistCommonAncestor(new Node(2), new Node(10));

        // Since 10 doesn't exist in the tree, the common ancestor should be null.
        Assert.True(commonAncestor.IsNone);
    }

    [Test]
    public void FindCommonAncestor_ReturnsNull_WhenBothValuesAreAbsent()
    {
        var commonAncestor = _root.GetFistCommonAncestor(new Node(10), new Node(11));

        // Since both 10 and 11 don't exist in the tree, the common ancestor should be null.
        Assert.True(commonAncestor.IsNone);
    }
}
