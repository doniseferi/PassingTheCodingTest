namespace PassingTheCodingTestQuestions;

internal static class BstSequenceIterative
{
    public static int[][] GetAllPossibleBstSequences(this Node node)
    {
        if (node == null)
            return Array.Empty<int[]>();

        var left = node.Left;
        var right = node.Right;
        
        return left.Match(
            None: () => 
                right.Match(
                    None: () => new[] { new[] { node.Value } }, 
                    Some: sr => 
                        node
                            .Value
                            .AppendTo(
                                sr.GetAllPossibleBstSequences())),
            Some: sl => right.Match(
                None: () => node
                    .Value
                    .AppendTo(
                        sl.GetAllBstSequences()), 
            Some: sr => node
                .Value
                .AppendTo(
                    Weave(
                        sl.GetAllPossibleBstSequences(),
                        sr.GetAllPossibleBstSequences())))); 
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
        if (leftSequences.Length > 0 && rightSequences.Length == 0)
            return leftSequences;
        
        if (leftSequences.Length == 0 && rightSequences.Length > 0)
            return rightSequences;
        
        var accum = new List<int[]>();
        foreach (var leftSequence in leftSequences)
        {
            foreach (var rightSequence in rightSequences)
            {
                accum.AddRange(
                    WeaveArr(leftSequence, rightSequence));
                
            }
        }

        return accum.ToArray();
    }
    
    public static int[][] WeaveArr(int[] left, int[] right)
    {
        if (left.Length > 0 && right.Length == 0)
            return new[] { left };
        
        if (left.Length == 0 && right.Length > 0)
            return new[] { right };
        
        var accum = new Dictionary<int, List<int[]>>();

        for (var n = left.Length; n != 0; n--)
        {
            var subject = left[n - 1];
            accum[subject] = new List<int[]>();
            subject.GetImmediateRightMember(left)
                .Match(None: () =>
                {
                    for (var i = right.Length(); i != -1; i--)
                    {
                        var injectedIntoOtherArray = right.Inject(subject, i);
                        var leftElements = left.LeftElementsOf(subject);
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

                        var indexOfRightMember = Array.IndexOf(rightSequence, sr);

                        var indexOfCurrentNode = Array.IndexOf(rightSequence, subject);

                        for (var i = indexOfCurrentNode + 1; i < indexOfRightMember; i++)
                        {
                            var newSequence = rightSequence.Except(subject)
                                .Inject(subject, i);

                            if (newSequence.Length > 0)
                                accum[subject].Add(newSequence);
                        }
                    }
                });
        }

        return accum.Values.SelectMany(x => x.ToArray()).ToArray();
    }
}