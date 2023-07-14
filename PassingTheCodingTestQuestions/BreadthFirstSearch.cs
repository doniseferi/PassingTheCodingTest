using LanguageExt;

namespace PassingTheCodingTestQuestions;

public class BreadthFirstSearch
{
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