using LanguageExt;
using PassingTheCodingTestQuestions.Extensions;

namespace PassingTheCodingTestQuestions;

internal class BreadthFirstSearch
{
    public static Node Search_(Node root, int value)
    {
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current.Value == value)
                return current;

            current.Left.IfSome(left => queue.Enqueue(left));
            current.Right.IfSome(right => queue.Enqueue(right));
        }

        throw new KeyNotFoundException();
    }
    
    public static Option<Node> Search(Node node, int value)
    {
        if (node.Value == value)
            return Option<Node>.Some(node);
    
        var queue = new Queue<Node>();
        queue.Enqueue(node);
        while (queue.TryPeek(out var current))
        {
            if (current.Value == value)
                return Option<Node>.Some(current);
            
            queue.Dequeue();
            current.Left.IfSome(left => queue.Enqueue(left));
            current.Right.IfSome(right => queue.Enqueue(right));
        }
        
        return Option<Node>.None;
    }
}