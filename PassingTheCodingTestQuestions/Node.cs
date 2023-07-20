using LanguageExt;

namespace PassingTheCodingTestQuestions;

public class Node
{
    public Node(int value) => Value = value;

    public void SetLeft(Node left) =>
        Left = Option<Node>.Some(left ?? throw new ArgumentNullException(nameof(left)));

    public void SetRight(Node right) =>
        Right = Option<Node>.Some(right ?? throw new ArgumentNullException(nameof(right)));
    
    public int Value { get; }
    public Option<Node> Left { get; private set; }
    public Option<Node> Right { get; private set; }
    
    public void Add(int value)
    {
        if (value < Value)
        {
            Left.Match(
                Some: left => left.Add(value),
                None: () => SetLeft(new Node(value)));
        }
        else
        {
            Right.Match(
                Some: right => right.Add(value),
                None: () => SetRight(new Node(value)));
        }
    }
}