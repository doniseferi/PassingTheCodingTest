namespace PassingTheCodingTestQuestions.InPlaceReversalLinkedList;
    public class ListNode<T>
    {
        public T Value { get; set; }
        public ListNode<T> Next { get; set; }

        public ListNode(T value, ListNode<T> next = null)
        {
            Value = value;
            Next = next;
        }
        
        public static ListNode<T> InPlaceLinkedListReversal<T>(ListNode<T> head)
        {
            ListNode<T> prev = null;
            ListNode<T> current = head;
            ListNode<T> next = null;
            while (current != null)
            {
                next = current.Next;   // store next node
                current.Next = prev;   // reverse current node's pointer
                prev = current;        // move pointers one position ahead
                current = next;
            }

            return prev;
        }
    }