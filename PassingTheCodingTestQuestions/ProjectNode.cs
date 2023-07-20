public class ProjectNode
{
    public ProjectNode(string value) => Value = value;
    public string Value { get; }
    //proxy for left
    public List<ProjectNode> Dependencies { get; } = new List<ProjectNode>();
    //proxy for right
    public List<ProjectNode> Dependents { get; } = new List<ProjectNode>();

    public void AddDependency(ProjectNode node) => Dependencies.Add(node);

    public void AddDependent(ProjectNode node) => Dependents.Add(node);
}
