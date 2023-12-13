using LanguageExt;
using PassingTheCodingTestQuestions.Extensions;

namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

internal class BasicNode : IBasicNode
{
    public BasicNode(int value) =>
        Value = value;

    public Option<IBasicNode> Left { get; private set; }
    public Option<IBasicNode> Right { get; private set; }
    public int Value { get; private set; }

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

    public void UpdateNode(int successor)
    {
        this.Value = successor;
    }

    public void UpdateNode(IMutableNode successor)
    {
        throw new NotImplementedException();
    }

    public void DeleteChild(int value)
    {
        if (Value == value)
            throw new InvalidOperationException("Cannot call delete on node");
        
        var isCurrentNodeSmaller = value > Value;
        
        var child = isCurrentNodeSmaller
            ? Right
            : Left;

        child.Match(None:()=>{ },
        Some: childNode =>
        {
            if (childNode.Value == value)
            {
                childNode.GetNextInOrderSuccessor()
                    .Match(
                        None: () =>
                        {
                            if (isCurrentNodeSmaller)
                                Right = Option<IBasicNode>.None;
                            else
                                Left = Option<IBasicNode>.None;
                        },
                        Some: inOrderSuccessor => 
                        { 
                            //if in order successor has children 1 child, update the reference to point to that child
                            //if it has 2, update it to be the right child
                            var inOrderSuccessorValue = inOrderSuccessor.Value;
                            childNode.DeleteChild(inOrderSuccessor.Value);
                            childNode.UpdateNode(inOrderSuccessorValue);
                        });
            }
            else
                childNode.DeleteChild(value);
        });
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

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

    public Option<IBasicNode> GetNextInOrderSuccessor() =>
        Right.Match(
            None: () => Left.Match(
                Some: r => Option<IBasicNode>.Some(r),
                None: () => Option<IBasicNode>.None),
            Some: r =>
            {
                return r.Left.Match(
                    None: () => Option<IBasicNode>.Some(r),
                    Some: l =>
                    {
                        var current = l;
                        var mut = Option<IBasicNode>.Some(l);
                        while (mut.IsSome)
                        {
                            current = mut.UnpackUnsafely();
                            mut = current.Left;
                        }

                        return Option<IBasicNode>.Some(current);
                    });
            });
}