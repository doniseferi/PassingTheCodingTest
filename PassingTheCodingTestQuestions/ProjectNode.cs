internal class ProjectNode
{
    public ProjectNode(string value) => _ = !string.IsNullOrWhiteSpace(value)
        ? Value = value
        : throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));

    public string Value { get; }

    public List<ProjectNode> Dependencies { get; } = new List<ProjectNode>();

    public void AddDependency(ProjectNode node) => Dependencies.Add(node ?? throw new ArgumentNullException(nameof(node)));
}