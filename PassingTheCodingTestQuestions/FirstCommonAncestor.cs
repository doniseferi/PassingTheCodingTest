using LanguageExt;

namespace PassingTheCodingTestQuestions;

internal static class FirstCommonAncestor
{
    public static Option<Node> GetFistCommonAncestor(this Option<Node> root, Node a, Node b)
    {
        return root.Match(None: () => Option<Node>.None, Some: node =>
        {
            var foundInLeftSubtree = ContainsAny(node.Left, a, b);
            var foundInRightSubtree = ContainsAny(node.Right, a, b);

            if (foundInLeftSubtree && foundInRightSubtree)
                return node;

            if (foundInLeftSubtree && !foundInRightSubtree)
                return GetFistCommonAncestor(node.Left, a, b);
            if (!foundInLeftSubtree && foundInRightSubtree)
                return GetFistCommonAncestor(node.Right, a, b);

            return Option<Node>.None;
        });
    }

    public static bool ContainsAny(this Option<Node> node, Node a, Node b)
    {
        return node.Match(None: () => false, Some: root =>
        {
            if (a.Value == root.Value || b.Value == root.Value)
                return true;

            var foundInLeftSubtree = false;
            var foundInRightSubtree = false;

            root.Left.Match(l => foundInLeftSubtree = ContainsAny(l, a, b), () => { });

            if (foundInLeftSubtree)
                return foundInLeftSubtree;

            root.Right.Match(r => foundInRightSubtree = ContainsAny(r, a, b), () => { });

            return foundInRightSubtree;
        });
    }
}