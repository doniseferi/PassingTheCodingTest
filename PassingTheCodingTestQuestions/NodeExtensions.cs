using LanguageExt;

namespace PassingTheCodingTestQuestions;

internal static class NodeExtensions
{
    public static bool ContainsSubtree(this Node node, Node subtree)
    {
        return node
            .Find(subtree.Value)
            .Match(
                None: ()=> false,
                Some: subtreeRoot => CanWalkTogether(subtree)
                )
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
                .Right
                .Match(
                    None: () => Option<Node>.None, 
                    Some: l => l.Find(value));
    }
}