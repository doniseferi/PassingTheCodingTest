namespace PassingTheCodingTestQuestions.PathWithSums;

internal static class PathWithSumsAlgorithm
{
    public static int[] ToIntArray(this Node node)
    {
        var accum = new List<int>();
        var queue = new Queue<Node>();
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            accum.Add(current.Value);
            current.Left.IfSome(x => queue.Enqueue(x));
            current.Right.IfSome(x => queue.Enqueue(x));
        }

        return accum.ToArray();
    }

    public static List<int[]> GetPathWithSums(Node node, int value)
    {
        var paths = new List<int[]>();

        GetPathWithSums(node, new List<int>());

        return paths;

        void GetPathWithSums(Node node, List<int> parents)
        {
            if (node == null)
                return;

            var newParents = parents == null || parents.Count == 0
                ? new List<int> { node.Value }
                : parents.Concat(new[] { node.Value });

            if (node.Value == value)
                paths.Add(new[] { node.Value });

            if (newParents.Sum() == value && newParents.Count() > 1)
                paths.Add(newParents.ToArray());

            node.Left.IfSome(x =>
            {
                GetPathWithSums(x, newParents.ToList());
                GetPathWithSums(x, new List<int>());
            });
            node.Right.IfSome(x =>
            {
                GetPathWithSums(x, newParents.ToList());
                GetPathWithSums(x, new List<int>());
            });
        }
    }
}