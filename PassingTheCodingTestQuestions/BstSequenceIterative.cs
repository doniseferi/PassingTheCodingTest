namespace PassingTheCodingTestQuestions;

internal static class BstSequenceIterative
{


    public static int[][] Weave(int[] x, int[] y)
    {
        var accum = new List<int[]>();
        for (var n = x.Length; n != 0; n--)
        {
            var c = x[n - 1];
            var r = c.GetImmediateRightMember(x);
            r.Match(None: () =>
            {
                for (var i = y.Length(); i != -1; i--)
                {
                    var injectedIntoOtherArray = y.Inject(c, i);
                    accum.Add(injectedIntoOtherArray);
                }
            }, Some: sr =>
            {

            });
        }

        return accum.ToArray();
    }
        
}