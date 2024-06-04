using PassingTheCodingTestQuestions.InPlaceReversalLinkedList;

namespace TestProject1;

[TestFixture]
public class LinkedListReversalTests
{
    [Test]
    public void TestReversalOfEmptyList()
    {
        ListNode<int> head = null;
        var reversedList = ListNode<int>.InPlaceLinkedListReversal(head);
        Assert.IsNull(reversedList);
    }

    [Test]
    public void TestReversalOfSingleElementList()
    {
        var head = new ListNode<int>(1);
        var reversedList = ListNode<int>.InPlaceLinkedListReversal(head);
        Assert.AreEqual(1, reversedList.Value);
        Assert.IsNull(reversedList.Next);
    }

    [Test]
    public void TestReversalOfMultipleElementList()
    {
        var head = new ListNode<int>(1, new ListNode<int>(2, new ListNode<int>(3, new ListNode<int>(4))));
        var reversedList = ListNode<int>.InPlaceLinkedListReversal(head);

        Assert.AreEqual(4, reversedList.Value);
        Assert.AreEqual(3, reversedList.Next.Value);
        Assert.AreEqual(2, reversedList.Next.Next.Value);
        Assert.AreEqual(1, reversedList.Next.Next.Next.Value);
        Assert.IsNull(reversedList.Next.Next.Next.Next);
    }

    [Test]
    public void TestReversalOfListWithThreeElements()
    {
        var head = new ListNode<int>(1, new ListNode<int>(2, new ListNode<int>(3)));
        var reversedList = ListNode<int>.InPlaceLinkedListReversal(head);

        Assert.AreEqual(3, reversedList.Value);
        Assert.AreEqual(2, reversedList.Next.Value);
        Assert.AreEqual(1, reversedList.Next.Next.Value);
        Assert.IsNull(reversedList.Next.Next);
    }

    [Test]
    public void TestReversalOfListWithDuplicateElements()
    {
        var head = new ListNode<int>(1, new ListNode<int>(2, new ListNode<int>(2, new ListNode<int>(1))));
        var reversedList = ListNode<int>.InPlaceLinkedListReversal(head);

        Assert.AreEqual(1, reversedList.Value);
        Assert.AreEqual(2, reversedList.Next.Value);
        Assert.AreEqual(2, reversedList.Next.Next.Value);
        Assert.AreEqual(1, reversedList.Next.Next.Next.Value);
        Assert.IsNull(reversedList.Next.Next.Next.Next);
    }
}