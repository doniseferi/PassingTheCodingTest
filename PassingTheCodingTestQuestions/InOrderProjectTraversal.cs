internal class InOrderProjectTraversal
{
    private readonly List<string> _projects;
    private readonly List<(string Project, string Dependent)> _projectDependencies;

    public InOrderProjectTraversal(
        IEnumerable<string> projects,
        IEnumerable<(string Project, string Dependent)> dependencies)
    {
        _projects = projects.ToList();
        _projectDependencies = dependencies.ToList();
    }

    public List<ProjectNode> GetInOrder()
    {
        var nodes = BuildBiDirectionalNodes();
        var visited = new HashSet<ProjectNode>();
        var queue = new Queue<ProjectNode>();
        nodes.ForEach(x => InOrderTraversal(x, queue.Enqueue, visited.Contains, x => { visited.Add(x); }));
        return queue.ToList();

        static void InOrderTraversal(
        ProjectNode node,
        Action<ProjectNode> add,
        Func<ProjectNode, bool> hasVisited,
        Action<ProjectNode> addToVisited)
        {
            if (hasVisited(node))
                return;

            addToVisited(node);
            foreach (var dependency in node.Dependencies)
            {
                if (!hasVisited(dependency))
                    InOrderTraversal(dependency, add, hasVisited, addToVisited);
            }
            add(node);
        }
    }

    private List<ProjectNode> BuildBiDirectionalNodes()
    {
        var nodes = new Dictionary<string, ProjectNode>();

        foreach (var (project, dependency) in _projectDependencies)
        {
            var projectNode = GetOrAddNode(project);
            var dependent = GetOrAddNode(dependency);

            dependent.AddDependency(projectNode);
        }
        foreach (var project in _projects)
        {
            if (!nodes.ContainsKey(project))
            {
                nodes[project] = new ProjectNode(project);
            }
        }

        var projectNodes = nodes.Values.ToList();

        var hasCircularDependency = projectNodes.Any(x => x.ContainsCircularDependency());
        
        return hasCircularDependency
            ? throw new ArgumentException("Circular dependency detected")
            : projectNodes;
        
        
        ProjectNode GetOrAddNode(string value)
        {
            if (nodes.ContainsKey(value))
            {
                return nodes[value];
            }
            else
            {
                nodes[value] = new ProjectNode(value);
                return nodes[value];
            }
        }
    }
}