using LanguageExt;

namespace PassingTheCodingTestQuestions;

public class DepthFirstSearch
{
    public static Option<Node> Search(Node node, int value)
    {
        if (node.Value == value)
            return Option<Node>.Some(node);
    
        var stack = new Stack<Node>();
        stack.Push(node);
        while (stack.TryPeek(out var current))
        {
            if (current.Value == value)
                return Option<Node>.Some(current);
            
            current.Right.IfSome(right => stack.Push(right));
            current.Left.IfSome(left => stack.Push(left));
            stack.Pop();
        }
        
        return Option<Node>.None;
    }
}