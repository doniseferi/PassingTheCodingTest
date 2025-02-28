using System.Runtime.CompilerServices;
using LanguageExt;

[assembly: InternalsVisibleTo("PassingTheCodingTestQuestions.Tests")]

namespace PassingTheCodingTestQuestions;

internal class Node
{
    public Node(int value)
    {
        Value = value;
    }

    public int Value { get; }
    public Option<Node> Left { get; private set; }
    public Option<Node> Right { get; private set; }

    private void SetLeft(Node left)
    {
        Left = Option<Node>.Some(left ?? throw new ArgumentNullException(nameof(left)));
    }

    private void SetRight(Node right)
    {
        Right = Option<Node>.Some(right ?? throw new ArgumentNullException(nameof(right)));
    }

    public void Add(int value)
    {
        if (value < Value)
            Left.Match(
                left => left.Add(value),
                () => SetLeft(new Node(value)));
        else
            Right.Match(
                right => right.Add(value),
                () => SetRight(new Node(value)));
    }
}