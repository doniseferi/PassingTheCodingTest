using LanguageExt;

namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

internal class RandomAndBasicBst : IRandomAndBasicBst
{
    private Option<IBasicNode> _root;

    public RandomAndBasicBst(IBasicNode root) =>
        _root = Option<IBasicNode>.Some(root);

    public Option<IBasicNode> Root =>
        _root;

    public Option<IBasicNode> Find(int value) =>
        _root.Match(None: () => Option<IBasicNode>.None,
            Some: root => root.Find(value));

    public void Insert(int value) =>
        _root.Match(None: () => { },
            Some: root => root.AddChild(value));

    public void Delete(int value)
    {
        _root.Match(None: () => { },
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
                            var pointer = l;
                            var nextPoint = l.Left;
                            while (nextPoint.IsSome)
                            {
                                nextPoint.Map(x => pointer = x);
                                nextPoint = nextPoint.Map(x => x.Left)
                                    .IfNone(() => nextPoint = Option<IBasicNode>.None);
                            }
                            _root = Option<IBasicNode>.Some(pointer);
                        });
                }
                else
                    root.DeleteChild(value);
            });
    }
}