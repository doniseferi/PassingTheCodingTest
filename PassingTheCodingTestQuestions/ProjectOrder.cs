/*
projects: a, b, c, d, e, f
dependencies: (a, d), (f, b), (b, d), (f, a), (d, c) 
Output: f, e, a, b, d, c 
this needs post order traversal, left node, right node, current node
*/
public class ProjectOrder
{
    private List<string> _projects;
    private List<Tuple<string, string>> _dependencies;

    public ProjectOrder(
        IEnumerable<string> projects,
        IEnumerable<Tuple<string, string>> dependencies)
    {
        _projects = projects.ToList();
        _dependencies = dependencies.ToList();
    }

    public List<ProjectNode> GetPostOrder()
    {
        var nodes = BuildBiDirectionalNodes();
        var visited = new HashSet<ProjectNode>();
        var queue = new Queue<ProjectNode>();
        PostOrder(nodes[0], queue.Enqueue, visited.Contains, (node) => { visited.Add(node); });
        return nodes.ToList();

        void PostOrder(
        ProjectNode node,
        Action<ProjectNode> add,
        Func<ProjectNode, bool> hasVisited,
        Action<ProjectNode> addToVisited)
        {
            //all left nodes
            //all right nodes
            //current node
        }
    }

    private List<ProjectNode> BuildBiDirectionalNodes()
    {
        var nodes = new Dictionary<string, ProjectNode>();

        foreach (var (project, dependency) in _dependencies)
        {
            var projectNode = GetOrAddNode(project);
            var dependentNode = GetOrAddNode(dependency);

            projectNode.AddDependency(dependentNode);
            dependentNode.AddDependent(projectNode);
        }
        foreach (var project in _projects)
        {
            if (!nodes.ContainsKey(project))
            {
                nodes[project] = new ProjectNode(project);
            }
        }

        return nodes.Values.ToList();

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