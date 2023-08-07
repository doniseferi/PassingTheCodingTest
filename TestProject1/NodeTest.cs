using System.Diagnostics;
using Newtonsoft.Json;
using PassingTheCodingTestQuestions;

namespace TestProject1;

public class NodeTest
{
    [Test]
    public void BreadthFirstSearch()
    {
        /*
               5
             /   \
            3     7
           / \   / \
          2   4 6   8
        */
        var values = new[] { 5, 3, 7, 2, 4, 6, 8 };
        var invalidValues = new[] { 1, 9, 0, 10 };
        var node = new Node(values[0]);
        node.Add(values[1]);
        node.Add(values[2]);
        node.Add(values[3]);
        node.Add(values[4]);
        node.Add(values[5]);
        node.Add(values[6]);

        values.Map(searchedValue => PassingTheCodingTestQuestions.BreadthFirstSearch.Search(node, searchedValue))
            .Iter((x, n) =>
            {
                var expectedValue = values[x];
                Assert.IsTrue(n.IsSome);
                n.Match(
                    Some: y => Assert.AreEqual(y.Value, expectedValue),
                    None: () => Assert.Fail());
            });

        invalidValues.Map(x => PassingTheCodingTestQuestions.BreadthFirstSearch.Search(node, x))
            .Iter(x => Assert.IsTrue(x.IsNone));
    }

    [Test]
    public void ProjectBuildInOrderTraversal()
    {
        /*
a <-- d <-- c   e
|     |
v     v
f <-- b
         */
        var projects = new[] { "a", "b", "c", "d", "e", "f" };

        var projectsAndDependencies = new List<(string Project, string DependentProject)>
        {
            ("a", "d"),
            ("f", "b"),
            ("b", "d"),
            ("f", "a"),
            ("d", "c")
        };

        var sut = new InOrderProjectTraversal(projects, projectsAndDependencies);

        var inOrderNodes = sut.GetInOrder();
        var result = string.Join(",", inOrderNodes.Select(x => x.Value));
        Assert.That(HasCharacterBeforeOthers(result, 'f', new[] { 'a', 'b' }));
        Assert.That(HasCharacterBeforeOthers(result, 'b', new[] { 'd' }));
        Assert.That(HasCharacterBeforeOthers(result, 'd', new[] { 'c' }));
        Assert.That(HasCharacterBeforeOthers(result, 'a', new[] { 'd', 'c' }));
        Assert.That(HasCharacterBeforeOthers(result, 'c', new char[] { }));
    }

    [Test]
    public void ProjectBuildInOrderTraversalCircularDependency()
    {
        var projects = new[] { "a", "b", "c", "d", "e", "f" };

        var projectsAndDependencies = new List<(string Project, string DependentProject)>
        {
            ("a", "d"),
            ("f", "b"),
            ("b", "d"),
            ("f", "a"),
            ("d", "a")
        };

        var sut = new InOrderProjectTraversal(projects, projectsAndDependencies);

        Assert.Throws<ArgumentException>(() => sut.GetInOrder());
    }

    private static bool HasCharacterBeforeOthers(string str, char targetChar, char[] otherChars)
    {
        var indexOfTarget = str.IndexOf(targetChar);
        if (indexOfTarget == -1) return false;

        foreach (var ch in otherChars)
        {
            var indexOfCh = str.IndexOf(ch);
            if (indexOfCh != -1 && indexOfTarget > indexOfCh) return false;
        }

        return true;
    }
}