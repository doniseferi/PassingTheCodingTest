using LanguageExt;

namespace PassingTheCodingTestQuestions;

internal static class NodeExtensions
{
    public static bool ContainsSubtree(this Node node, Node subtree)
    {
        if (node == null)
            throw new ArgumentNullException(nameof(node));

        if (subtree == null)
            throw new ArgumentNullException(nameof(subtree));
        
        return node
            .Find(subtree.Value)
            .Match(
                None: () => false,
                Some: subtreeRoot => CanWalkTogether(subtree, subtreeRoot)
            );
    }

    private static bool CanWalkTogether(Node subtree, Node b)
    {
        if (subtree.Value != b.Value)
            return false;

        var allLefts = subtree
            .Left
            .Match(
                None: () => true,
                Some: s =>
                b.Left.Match(None: () => false,
                    Some: r => CanWalkTogether(s, r)));

        if (!allLefts)
            return false;
        
        var allRights = subtree
            .Right
            .Match(
                None: () => true,
                Some: s =>
                    b.Right.Match(None: () => false,
                        Some: r => CanWalkTogether(s, r)));

        return allRights;

    }

    private static Option<Node> Find(this Node node, int value)
    {
        if (value == node.Value)
            return Option<Node>.Some(node);

        return value > node.Value
            ? node
                .Right
                .Match(
                    None: () => Option<Node>.None, 
                    Some: r => r.Find(value))
        :
             node
                .Left
                .Match(
                    None: () => Option<Node>.None, 
                    Some: l => l.Find(value));
    }
}