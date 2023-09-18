namespace PassingTheCodingTestQuestions;

public class SequenceEqualityComparer : IEqualityComparer<int[]>
{
    public bool Equals(int[] x, int[] y)
    {
        return Enumerable.SequenceEqual(x, y);
    }

    public int GetHashCode(int[] obj)
    {
        // This is a simple method to get a hash code. Depending on the size of sequences 
        // and the specific data, there might be more efficient ways.
        return obj.Sum().GetHashCode();
    }
}

internal static class BstSequenceIterative
{
    public static int[][] GetAllPossibleBstSequences(this Node node)
    {
        if (node == null)
            return Array.Empty<int[]>();

        var left = node.Left;
        var right = node.Right;
        return left.Match(None: () =>
        {
            return right.Match(None: () =>
            {
                return new int[][] { new[] { node.Value } };
            }, Some: sr =>
            {
                return node
                    .Value
                    .AppendTo(
                        sr.GetAllPossibleBstSequences().Distinct().ToArray()).Distinct().ToArray();
            });
        }, Some: sl =>
        {
            return right.Match(None: () =>
            {
                return node
                    .Value
                    .AppendTo(sl.GetAllBstSequences().Distinct().ToArray()).Distinct().ToArray();
            }, Some: sr =>
            {
                return node
                    .Value
                    .AppendTo(
                        Weave(
                            sl.GetAllPossibleBstSequences().Distinct().ToArray(),
                            sr.GetAllPossibleBstSequences().Distinct().ToArray())).Distinct().ToArray();
            });
        });
    }

    private static int[][] AppendTo(this int value, int[][] sequences)
    {
        var accum = new List<int[]>();
        foreach (var sequence in sequences)
        {
            accum
                .Add(
                    sequence
                        .Inject(value, 0));
        }

        return accum.ToArray();
    }

    private static int[][] Weave(int[][] leftSequences, int[][] rightSequences)
    {
        var accum = new List<int[]>();
        foreach (var leftSequence in leftSequences)
        {
            foreach (var rightSequence in rightSequences)
            {
                accum.AddRange(
                    WeaveArr(leftSequence, rightSequence).Distinct().ToArray()
                        .Concat(
                            WeaveArr(rightSequence, leftSequence).Distinct().ToArray()));
            }
        }

        return accum.Distinct().ToArray();
    }
    
    public static int[][] WeaveArr(int[] x, int[] y)
    {
        var accum = new Dictionary<int, List<int[]>>();
        for (var n = x.Length; n != 0; n--)
        {
            var subject = x[n - 1];
            accum[subject] = new List<int[]>();
            var r = subject.GetImmediateRightMember(x);
            r.Match(None: () =>
            {
                for (var i = y.Length(); i != -1; i--)
                {
                    var injectedIntoOtherArray = y.Inject(subject, i);
                    var leftElements = x.LeftElementsOf(subject);
                    var weavedElements = leftElements.Concat(injectedIntoOtherArray).ToArray();
                    accum[subject].Add(weavedElements);
                }
            }, Some: sr =>
            {
                var immediateRightMembersSequences = accum.ContainsKey(sr)
                    ? accum[sr]
                    : throw new KeyNotFoundException($"{sr}");

                foreach (var rightSequence in immediateRightMembersSequences)
                {
                    var candidate = rightSequence.
                        Except(subject)
                        .InjectToLeftOf(sr, subject);
                    
                    if (candidate.Length > 0)
                        accum[subject].Add(candidate);
                }
            });
        }

        var result = accum.Values.SelectMany(x => x.ToArray()).Distinct().ToArray();
        return result;
    }
        
}