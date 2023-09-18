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

    public static int[] InjectToLeftOf(this int[] source, int targetValue, int valueToInject)
    {
        if (source.Length() == 0)
            throw new ArgumentException();

        var accum = new int[source.Length() + 1];
        var indexToInjectValue = GetIndexOfTargetValue();
        
        if (indexToInjectValue == 0)
            return Array.Empty<int>();

        for (var i = 0; i < source.Length; i++)
        {
            if (i < indexToInjectValue)
            {
                accum[i] = source[i];
            }
            else if (i == indexToInjectValue)
            {
                accum[i] = valueToInject;
                accum[i + 1] = source[i];
            }
            else
            {
                accum[i + 1] = source[i];
            }
        }

        return accum;

        int GetIndexOfTargetValue()
        {
            for (var i = 0; i < source.Length(); i++)
            {
                if (source[i] == targetValue)
                {
                    return i;
                }
            }
            
            throw new ArgumentException();
        }
    }

    public static int[] LeftElementsOf(this int[] arr, int subject)
    {
        if (arr.Length() == 0)
            return arr;

        var accum = new List<int>();
        foreach (var item in arr)
        {
            if (item == subject)
                return accum.ToArray();
            
            accum.Add(item);
        }

        throw new ArgumentException($"{subject} is not in the array.");
    }

    public static int[] Except(this int[] arr, int value)
    {
        if (arr.Length == 0)
            return arr;

        var accum = new List<int>();
        foreach (var item in arr)
        {
            if (item != value)
                accum.Add(item);
        }

        return accum.ToArray();
    }
}