namespace PassingTheCodingTestQuestions;

internal static class BSTSequences
{
    public static int[][] GetAllBstSequences(this Node node)
    {
        if (node == null)
            return Array.Empty<int[]>();

        var left = node.Left;
        var right = node.Right;
        return left.Match(None: () =>
        {
            return right.Match(
                None: () => { return new int[][] { new[] { node.Value } }; },
                Some: r =>
                {
                    var rSeq = r.GetAllBstSequences();
                    var seq = Prepend(node, rSeq);
                    return seq;
                });
        }, Some: l =>
        {
            return right.Match(None: () =>
            {
                var lSeq = l.GetAllBstSequences();
                var prependedSeq = Prepend(node, lSeq);
                return prependedSeq;
            }, Some: r =>
            {
                var lSeq = l.GetAllBstSequences();
                var rSeq = r.GetAllBstSequences();
                var lrSeq = Stitch(lSeq, rSeq);
                var prependedSeq = Prepend(node, lrSeq);
                return prependedSeq;
            });
        });
    }

    private static int[][] Prepend(Node node, int[][] sequences)
    {
        if (node == null)
            return sequences;

        var accum = new int[sequences.Length][];
        for (var i = 0; i < sequences.Length; i++)
        {
            var sequence = sequences[i];
            var prependedSeq = Inject(0, node.Value, sequence);
            accum[i] = prependedSeq;
        }

        return accum;
    }

    private static int[][] Stitch(int[][] A, int[][] B)
    {
        var accum = new HashSet<int[]>();
        foreach (var item in A)
        {
            foreach (var i in item)
            {
                foreach (var n in B)
                {
                    var sequence = Stitch(i, n);
                    foreach (var x in sequence)
                    {
                        accum.Add(x);
                    }
                }
            }
        }

        var resAccum = new int[accum.Count][];
        var counter = 0;
        foreach (var sequence in accum)
        {
            resAccum[counter] = sequence;
            counter++;
        }

        return resAccum;
    }

    private static int[][] Stitch(int value, int[][] values)
    {
        var accum = new HashSet<int[]>();
        foreach (var item in values)
        {
            var sequences = Stitch(value, item);
            foreach (var sequence in sequences)
            {
                accum.Add(sequence);
            }
        }

        var resAccum = new int[accum.Count][];
        var counter = 0;
        foreach (var seq in accum)
        {
            resAccum[counter] = seq;
        }

        return resAccum;
    }

    private static int[][] Stitch(int value, int[] values)
    {
        if (values.Length == 0)
            return new int[][] { new[] { value } };

        var accum = new HashSet<int[]>();
        for (var i = 0; i != values.Length + 1; i++)
        {
            var seq = Inject(i, value, values);
            accum.Add(seq);
        }

        var resAccum = new int[accum.Count][];
        var counter = 0;
        foreach (var seq in accum)
        {
            resAccum[counter] = seq;
            counter++;
        }

        return resAccum;
    }

    private static int[] Inject(int index, int value, int[] values)
    {
        if (index < 0 || index > values.Length + 1)
            throw new IndexOutOfRangeException();

        if (values.Length == 0)
        {
            return new int[] { value };
        }

        var injectedLength = values.Length + 1;
        var accum = new int[injectedLength];
        for (var i = 0; i != values.Length; i++)
        {
            if (i < index)
                accum[i] = values[i];
            else if (i > index)
                accum[i + 1] = values[i];
            else
            {
                accum[index] = value;
                accum[index + 1] = values[i];
            }
        }

        if (index == values.Length)
            accum[values.Length] = value;

        return accum;
    }

    private static int[] Append(int value, int[] values)
    {
        if (values.Length == 0)
            return new[] { value };

        return Inject(values.Length, value, values);
    }
}