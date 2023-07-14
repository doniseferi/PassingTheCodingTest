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
}