namespace PassingTheCodingTestQuestions;

internal static class BSTSequences
{
    public static string ConverstAllBSTSequencesToString(this Node node) => string.Join('\n', node.GetAllBSTSequences().Select(x => string.Join(',', x)));
    
    public static List<List<int>> GetAllBSTSequences(this Node node)
    {
        
    }

    private static int[][] Stitch(IEnumerable<int> a, IEnumerable<int> b)
    {
        var combined = Join(a, b);
        var accum = new Dictionary<int[], int>();
        var accumIndex = 0;
        for (var i = 0; i < combined.Length; i++)
        {
            var copyToManipulate = Copy(combined);
            for (var n = 0; n < copyToManipulate.Length(); n++)
            {
                var swapFrom = copyToManipulate[i];
                var swapTo = copyToManipulate[n];
                copyToManipulate[i] = swapTo;
                copyToManipulate[n] = swapFrom;

                accum.TryAdd(copyToManipulate, n);
            }
        }

        var stitched = new int[][]{};
        var index = 0;
        foreach (var key in accum.Keys)
        {
            stitched[index] = key;
            index++;
        }

        return stitched;
    }

    private static int[] Copy(int[] a)
    {
        var copy = new int[a.Length()];
        for (var i = 0; i < a.Length(); i++)
        {
            copy[i] = a[i];
        }

        return copy;
    }
    
    private static int[] Join(IEnumerable<int> a, IEnumerable<int> b)
    {
        var joined = new int[a.Length() + b.Length()];
        var currentIndex = 0;
        foreach (var item in a)
        {
            joined[currentIndex] = item;
            currentIndex++;
        }

        foreach (var item in b)
        {
            joined[currentIndex] = item;
            currentIndex++;
        }

        return joined;
    }
    
}