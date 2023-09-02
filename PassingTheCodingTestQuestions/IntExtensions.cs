using LanguageExt;

namespace PassingTheCodingTestQuestions;

public static class IntExtensions
{
    public static Option<int> GetImmediateRightMember(this int value, int[] arr)
    {
        if (arr.Length == 0)
            return Option<int>.None;

        for (var i = 0; i < arr.Length - 1; i++)
        {
            var matched = arr[i] == value;
            if (matched)
                return Option<int>.Some(arr[i + 1]);
        }

        return Option<int>.None;
    }
    
    public static int[] Inject(this int[] arr, int value, int index)
    {
        if (index > arr.Length || index < 0)
            throw new IndexOutOfRangeException();

        var accum = new int[arr.Length + 1];

        for (var i = 0; i < arr.Length; i++)
        {
            if (i > index)
            {
                accum[i + 1] = arr[i];
            }
            else if (i < index)
            {
                accum[i] = arr[i];
            }
            else if (i == index && arr.Length > 0)
            {
                accum[i + 1] = arr[i];
            }
        }

        accum[index] = value;
        
        return accum;
    }
}