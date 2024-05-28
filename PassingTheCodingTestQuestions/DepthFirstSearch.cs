using LanguageExt;

namespace PassingTheCodingTestQuestions;

internal class DepthFirstSearch
{
    public static Node Search_(Node node, int value)
    {
        var stack = new Stack<Node>();
        stack.Push(node);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            if (current.Value == value)
                return current;

            current.Right.IfSome(right => stack.Push(right));
            current.Left.IfSome(left => stack.Push(left));
        }

        throw new KeyNotFoundException();
    }
    
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