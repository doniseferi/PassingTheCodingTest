using LanguageExt;

namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

internal class RandomAndBasicBst : IRandomAndBasicBst
{
    private static Action NoOp = () => {};
    private Option<IBasicNode> _root;

    public RandomAndBasicBst(IBasicNode root) =>
        _root = Option<IBasicNode>.Some(root);

    public Option<IBasicNode> Root =>
        _root;

    public IBasicNode GetRandomNode() => _root.IfNone(() => throw new ArgumentNullException());

    public Option<IBasicNode> Find(int value) =>
        _root.Match(None: () => Option<IBasicNode>.None,
            Some: root => root.Find(value));

    public void Insert(int value) =>
        _root.Match(None: NoOp,
            Some: root => root.AddChild(value));

    public void Delete(int value)
    {
        var node = _root;
        node.Match(None: NoOp,
            Some: root =>
            {
                if (root.Value == value)
                {
                    root.Left.Match(
                        None: () => root.Right.Match(
                            None: () => _root = Option<IBasicNode>.None,
                            Some: r => _root = Option<IBasicNode>.Some(r)),
                        Some: l =>
                        {
                            var leftMostChild = l;
                            var hasSmallerChildren = l.Left;
                            while (hasSmallerChildren.IsSome)
                            {
                                hasSmallerChildren.Map(x => leftMostChild = x);
                                hasSmallerChildren = hasSmallerChildren.Map(x => x.Left)
                                    .IfNone(() => hasSmallerChildren = Option<IBasicNode>.None);
                            }
                            root.UpdateNode(leftMostChild.Value);
                            
                        });
                }
                else
                {
                    root.DeleteChild(value);
                }
            });
    }
}