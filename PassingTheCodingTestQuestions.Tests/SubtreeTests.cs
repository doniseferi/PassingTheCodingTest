using PassingTheCodingTestQuestions;

namespace TestProject1;

[TestFixture]
public class SubtreeTests
{
    [Test]
    public void Test_ContainsSubtree_SimplePositiveCase()
    {
        // Arrange
        var T1 = new Node(10);
        T1.Add(5);
        T1.Add(15);

        var T2 = new Node(5);

        // Act
        var result = T1.ContainsSubtree(T2);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Test_ContainsSubtree_ComplexPositiveCase()
    {
        // Arrange
        var T1 = new Node(10);
        T1.Add(6);
        T1.Add(15);
        T1.Add(3);
        T1.Add(8);
        T1.Add(5);
        T1.Add(9);
        T1.Add(7);
        T1.Add(1);
        T1.Add(13);
        T1.Add(11);
        T1.Add(14);
        T1.Add(20);
        T1.Add(18);
        T1.Add(22);

        var T2 = new Node(15);
        T2.Add(13);
        T2.Add(20);
        T2.Add(18);

        // Act
        var result = T1.ContainsSubtree(T2);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Test_ContainsSubtree_NegativeCase()
    {
        // Arrange
        var T1 = new Node(10);
        T1.Add(5);
        T1.Add(15);

        var T2 = new Node(20);

        // Act
        var result = T1.ContainsSubtree(T2);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void Test_ContainsSubtree_NullTrees()
    {
        // Arrange
        Node T1 = null;
        Node T2 = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => T1.ContainsSubtree(T2));
    }

    [Test]
    public void Test_ContainsSubtree_IdenticalTrees()
    {
        // Arrange
        var T1 = new Node(10);
        T1.Add(5);
        T1.Add(15);

        var T2 = new Node(10);
        T2.Add(5);
        T2.Add(15);

        // Act
        var result = T1.ContainsSubtree(T2);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Test_ContainsSubtree_T2LargerThanT1()
    {
        // Arrange
        var T1 = new Node(10);

        var T2 = new Node(10);
        T2.Add(5);
        T2.Add(15);

        // Act
        var result = T1.ContainsSubtree(T2);

        // Assert
        Assert.IsFalse(result);
    }
}