using System.Diagnostics;
using Newtonsoft.Json;
using PassingTheCodingTestQuestions;

namespace TestProject1;

public class NodeTest
{
    [Test]
    public void Test1()
    {
        var node = new Node(5);
        node.Add(3);
        node.Add(7);
        node.Add(2);
        node.Add(4);
        node.Add(6);
        node.Add(8);
        var res = JsonConvert.SerializeObject(BreadthFirstSearch.Search(node, 4));
        Debug.WriteLine(res);
    }

    [Test]
    public void Test2()
    {
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