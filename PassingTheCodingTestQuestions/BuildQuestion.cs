/*
projects: a, b, c, d, e, f
dependencies: (a, d), (f, b), (b, d), (f, a), (d, c) 
Output: f, e, a, b, d, c 
this needs post order traversal, left node, right node, node
*/
public class BuildOrder
{
    private Dictionary<string, BiDirectionalNode> _nodes = new Dictionary<string, BiDirectionalNode>();
    private List<Tuple<string, string>> _dependencies;

    public BuildOrder(
        IEnumerable<Tuple<string, string>> dependencies)
    {
        _dependencies = dependencies.ToList();
    }

    public List<string> GetBuildOrder()
    {
        BuildBiDirectionalNodes();
        var orderedNodes = GetPostOrder(_nodes.First().Value);
        return orderedNodes.Select(x => x.Value).ToList();
    }

    public List<BiDirectionalNode> GetBuildOrder2()
    {
        BuildBiDirectionalNodes();
        var orderedNodes = GetPostOrder(_nodes.First().Value);
        return orderedNodes; 
    }

    private void BuildBiDirectionalNodes()
    {
        foreach (var (project, dependency) in _dependencies)
        {
            var projectNode = GetOrAddNode(project);
            var dependentNode = GetOrAddNode(dependency);
            
            projectNode.AddDependency(dependentNode);
            dependentNode.AddDependent(projectNode);
        }
    }

    private List<BiDirectionalNode> GetPostOrder(BiDirectionalNode node)
    {
        var queue = new Queue<BiDirectionalNode>();
        var stack = new Stack<BiDirectionalNode>();
        stack.Push(node);
        while(stack.TryPeek(out var currentNode))
        {
            foreach (var dependencies in currentNode.Dependencies)
            {
                stack.Push(dependencies);
            }
            
            foreach (var dependent in currentNode.Dependents)
            {
                queue.Enqueue(dependent);
            }

            stack.Push(currentNode);
        }

        while (queue.TryPeek(out var currentNode))
        {
            stack.Push(currentNode);
            queue.Dequeue();
        }

        var orderedNodes = new List<BiDirectionalNode>();
        while (stack.TryPeek(out var currentNode))
        {
            orderedNodes.Add(currentNode);
            stack.Pop();
        }
        return orderedNodes;
    }

    public BiDirectionalNode GetOrAddNode(string node)
    {
         if (_nodes.ContainsKey(node))
            {
                return _nodes[node];
            }
            else 
            {
                _nodes[node] = new BiDirectionalNode(node);
                return _nodes[node];
            }
    }

    public class BiDirectionalNode 
    {
        public BiDirectionalNode(string value) => Value = value;
        public string Value { get; }
        //proxy for left
        public List<BiDirectionalNode> Dependencies { get; } = new List<BiDirectionalNode>();
        //proxy for right
        public List<BiDirectionalNode> Dependents { get; } = new List<BiDirectionalNode>();

        public void AddDependency(BiDirectionalNode node) => Dependencies.Add(node);

        public void AddDependent(BiDirectionalNode node) => Dependents.Add(node);
    }
}