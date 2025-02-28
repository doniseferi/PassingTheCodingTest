using PassingTheCodingTestQuestions;
using PassingTheCodingTestQuestions.InPlaceReversalLinkedList;

namespace TestProject1;

[TestFixture]
public class LinkedListAdditionTests
{
    private static ListNode<int> CreateLinkedList(List<int> digits)
    {
        if (digits is null || digits.Count == 0)
            return new(0);
        
        var head = new ListNode<int>(digits[0]);
        ListNode<int> tail = null;
        for (var i = 1; i < digits.Count; i++)
        {
            if (tail == null)
            {
                tail = new ListNode<int>(digits[i]);
                head.Next = tail;
            }
            else
            {
                var node = new ListNode<int>(digits[i]);
                tail.Next = node;
                tail = tail.Next;
            }
        }
        return head;
    }

    private List<int> LinkedListToList(ListNode<int> node)
    {
        var result = new List<int>();
        while (node != null)
        {
            result.Add(node.Value);
            node = node.Next;
        }

        return result;
    }

    [Test]
    public void AddTwoNumbers_ReverseOrder_ShouldReturnCorrectSum()
    {
        var l1 = CreateLinkedList(new List<int> { 7, 1, 6 }); // 617
        var l2 = CreateLinkedList(new List<int> { 5, 9, 2 }); // 295

        var result = AddTwoNumbersLinkedLists.AddTwoNumbers(l1, l2, Direction.Reverse);

        var expected = new List<int> { 2, 1, 9 }; // 912
        Assert.AreEqual(expected, LinkedListToList(result));
    }

    [Test]
    public void AddTwoNumbers_ForwardOrder_ShouldReturnCorrectSum()
    {
        var l1 = CreateLinkedList(new List<int> { 6, 1, 7 }); // 617
        var l2 = CreateLinkedList(new List<int> { 2, 9, 5 }); // 295

        var result = AddTwoNumbersLinkedLists.AddTwoNumbers(l1, l2, Direction.Forward);

        var expected = new List<int> { 9, 1, 2 }; // 912
        Assert.AreEqual(expected, LinkedListToList(result));
    }

    [Test]
    public void AddTwoNumbers_ReverseOrder_WithCarryOver_ShouldReturnCorrectSum()
    {
        var l1 = CreateLinkedList(new List<int> { 9, 9, 9 }); // 999
        var l2 = CreateLinkedList(new List<int> { 1 }); // 1

        var result = AddTwoNumbersLinkedLists.AddTwoNumbers(l1, l2, Direction.Reverse);

        var expected = new List<int> { 0, 0, 0, 1 }; // 1000
        Assert.AreEqual(expected, LinkedListToList(result));
    }

    [Test]
    public void AddTwoNumbers_ForwardOrder_WithCarryOver_ShouldReturnCorrectSum()
    {
        var l1 = CreateLinkedList(new List<int> { 9, 9, 9 }); // 999
        var l2 = CreateLinkedList(new List<int> { 1 }); // 1

        var result = AddTwoNumbersLinkedLists.AddTwoNumbers(l1, l2, Direction.Forward);

        var expected = new List<int> { 1, 0, 0, 0 }; // 1000
        Assert.AreEqual(expected, LinkedListToList(result));
    }

    [Test]
    public void AddTwoNumbers_ReverseOrder_OneListEmpty_ShouldReturnOtherList()
    {
        var l1 = CreateLinkedList(new List<int>()); // Empty
        var l2 = CreateLinkedList(new List<int> { 5, 9, 2 }); // 295

        var result = AddTwoNumbersLinkedLists.AddTwoNumbers(l1, l2, Direction.Reverse);

        var expected = new List<int> { 5, 9, 2 };
        Assert.AreEqual(expected, LinkedListToList(result));
    }

    [Test]
    public void AddTwoNumbers_ForwardOrder_OneListEmpty_ShouldReturnOtherList()
    {
        var l1 = CreateLinkedList(new List<int>());
        var l2 = CreateLinkedList(new List<int> { 2, 9, 5 });

        var result = AddTwoNumbersLinkedLists.AddTwoNumbers(l1, l2, Direction.Forward);

        var expected = new List<int> { 2, 9, 5 };
        Assert.AreEqual(expected, LinkedListToList(result));
    }
    
    [Test]
    public void AddTwoSimpleNumbers_ForwardOrder_ShouldReturnCorrectSum()
    {
        var l1 = CreateLinkedList(new List<int> { 6 });
        var l2 = CreateLinkedList(new List<int> { 9 });

        var result = AddTwoNumbersLinkedLists.AddTwoNumbers(l1, l2, Direction.Forward);

        var expected = new List<int> { 1, 5 };
        Assert.AreEqual(expected, LinkedListToList(result));
    }
    
    [Test]
    public void AddTwoSimpleNumbers_ReverseOrder_ShouldReturnCorrectSum()
    {
        var l1 = CreateLinkedList(new List<int> { 6 });
        var l2 = CreateLinkedList(new List<int> { 9 });

        var result = AddTwoNumbersLinkedLists.AddTwoNumbers(l1, l2, Direction.Reverse);

        var expected = new List<int> { 5, 1 };
        Assert.AreEqual(expected, LinkedListToList(result));
    }
}