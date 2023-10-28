using LanguageExt;

namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

internal class BasicNode : IBasicNode
{
    public BasicNode(int value) =>
        Value = value;

    public Option<IBasicNode> Left { get; private set; }
    public Option<IBasicNode> Right { get; private set; }
    public int Value { get; }

    public Option<IBasicNode> Find(int value)
    {
        if (Value == value)
            return this;
        return value > Value
            ? Right.Match(
                None: Option<IBasicNode>.None,
                Some: r => r.Find(value))
            : Left.Match(
                None: Option<IBasicNode>.None,
                Some: l => l.Find(value));
    }

    public int Count()
    {
        var leftCount = Left.Map(l => l.Count())
            .IfNone(0);
        var rightCount = Right.Map(r => r.Count())
            .IfNone(0);
        const int countAtCurrentLevel = 1;
        return countAtCurrentLevel + leftCount + rightCount;
    }

    public void DeleteChild(int value)
    {
        if (Value == value)
            throw new InvalidOperationException("Cannot call delete on node");
        
        var isGreaterThan = value > Value;
        
        var child = isGreaterThan
            ? Right
            : Left;

        child.Match(None:()=>{ },
        Some: childNode =>
        {
            if (childNode.Value == value)
            {
                childNode.GetLeftMostNode()
                    .Match(
                        None: () =>
                        {
                            if (isGreaterThan)
                                Right = Option<IBasicNode>.None;
                            else
                                Left = Option<IBasicNode>.None;
                        },
                        Some: l =>
                        {
                            var replacementChild = Option<IBasicNode>.Some(l);
                            if (isGreaterThan)
                                Right = replacementChild;
                            else
                                Left = replacementChild;
                        });
            }
            else
                childNode.DeleteChild(value);
        });
    }
    
    public Option<IBasicNode> GetLeftMostNode() =>
        Left.Match(
            None: () => Option<IBasicNode>.None,
            Some: l => l.Left.Match(
                None: () => Option<IBasicNode>.Some(l), 
                Some: fl => fl.GetLeftMostNode()));

    public void AddChild(int value)
    {
        if (value < Value)
        {
            Left.Match(Some: left => left.AddChild(value),
                None: () => Left = new BasicNode(value));
        }
        else
        {
            Right.Match(Some: right => right.AddChild(value),
                None: () => Right = new BasicNode(value));
        }
    }
}