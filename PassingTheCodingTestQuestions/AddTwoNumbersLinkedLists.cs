using PassingTheCodingTestQuestions.InPlaceReversalLinkedList;

namespace PassingTheCodingTestQuestions;

public enum Direction
{
    Forward,
    Reverse
}

public class AddTwoNumbersLinkedLists
{
    public static ListNode<int> AddTwoNumbers(ListNode<int> first, ListNode<int> second, Direction direction)
    {
        var firstCount = Count(first);
        var secondCount = Count(second);
        if (firstCount < secondCount)
            first = Pad(first, secondCount - firstCount, direction);
        else if (secondCount < firstCount)
            second = Pad(second, firstCount - secondCount, direction);

        if (direction == Direction.Forward)
        {
            first = first.Reverse();
            second = second.Reverse();
        }

        var result = Add(first, second, 0);

        if (direction == Direction.Forward)
        {
            return result.Reverse();
        }

        return result;
    }


    private static ListNode<int> Add(ListNode<int> first, ListNode<int> second, int carry)
    {
        var firstCurrent = first;
        var secondCurrent = second;
        var node = new ListNode<int>(0);
        var sum = carry + firstCurrent.Value + secondCurrent.Value;
        var value = sum % 10;
        var remainder = sum > 9 ? 1 : 0;
        node.Value = value;
        if (firstCurrent.Next is not null)
        {
            var next = Add(firstCurrent.Next, secondCurrent.Next, remainder);
            node.Next = next;
        }
        else if (remainder > 0)
        {
            var next = new ListNode<int>(remainder);
            node.Next = next;
        }

        return node;
    }


    private static ListNode<int> Pad(ListNode<int> node, int size, Direction direction)
    {
        if (size == 0)
            return node;


        if (direction == Direction.Forward)
        {
            var paddedNode = new ListNode<int>(0, node);
            return Pad(paddedNode, size - 1, direction);
        }
        else
        {
            var current = node;
            while (current.Next is not null)
            {
                current = current.Next;
            }

            for (var i = 0; i < size; i++)
            {
                current.Next = new ListNode<int>(0);
                current = current.Next;
            }

            return node;
        }
    }

    private static int Count(ListNode<int> node)
    {
        var count = 0;
        var current = node;
        while (current != null)
        {
            count++;
            current = current.Next;
        }

        return count;
    }
}