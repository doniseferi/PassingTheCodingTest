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
        /*projects: a, b, c, d, e, f
dependencies: (a, d), (f, b), (b, d), (f, a), (d, c) 
Output: f, e, a, b, d, c */
        var sut = new ProjectOrder(new[] { "a", "b", "c", "d", "e", "f" },new List<Tuple<string, string>>
        {
            new Tuple<string, string>("a", "d"),
            new Tuple<string, string>("f", "b"),
            new Tuple<string, string>("b", "d"),
            new Tuple<string, string>("f", "a"),
            new Tuple<string, string>("d", "c")
        });

        var result = string.Join(", ", sut.GetPostOrder().Select(x => x.Value));
        Assert.That(result, Is.EqualTo("f, e, a, b, d, c");
    }
}