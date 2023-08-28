using System.Collections.Specialized;
using System.Net.NetworkInformation;
using LanguageExt.ClassInstances.Const;

namespace PassingTheCodingTestQuestions;

internal static class BstSequences
{
    public static int[][] GetAllBstSequences(this Node node)
    {
        if (node == null)
            return Array.Empty<int[]>();

        var left = node.Left;
        var right = node.Right;
        return left.Match(None: () =>
            {
                return right.Match(None: () =>
                    {
                        return new int[1][] { new [] { node.Value }  };
                    },
                    Some: r =>
                    {
                        var prepended = r.GetAllBstSequences().Select(x => x.Prepend(node.Value).ToArray()).ToArray();
                        return prepended;
                    });
            },
            Some: l =>
            {
                return right.Match(None: () =>
                    {
                        var prepended = l.GetAllBstSequences().Select(x => x.Prepend(node.Value).ToArray()).ToArray();
                        return prepended;
                    },
                    Some: r =>
                    {
                        var accum = new List<List<int>>();
                        var rightSequences = r.GetAllBstSequences();
                        var leftSequences = l.GetAllBstSequences();
                        foreach (var rArr in rightSequences)
                        {
                            foreach (var lArr in leftSequences)
                            {

                                var stitched = Stitch(lArr, rArr).Select(x => x.ToList()).ToList();
                                var prepended = stitched.Select(x => x.Prepend(node.Value).ToList()).ToList();
                                accum.AddRange(prepended);
                            }
                        }

                        return accum.Select(x => x.ToArray()).ToArray();
                    });
            });
    }

    private static int[][] Stitch(int[] left, int[] right)
    {
        var accum = new List<List<int>>();
        var leftLinkedList = new LinkedList<int>();
        var rightLinkedList = new LinkedList<int>();
        left.Select(x => leftLinkedList.AddLast(x)).ToList();
        right.Select(x => rightLinkedList.AddLast(x)).ToList();
        Stitch(leftLinkedList, rightLinkedList, new LinkedList<int>(), accum);
        return accum.Select(x => x.ToArray()).ToArray();
    }
    
    /*
     * this is horrific, convert to an expressive recursive method but for the time being function is better than no function
     */
    public static void Stitch(LinkedList<int> b, LinkedList<int> c, LinkedList<int> prefix, List<List<int>> Accum)
    {
        if (b.Count != 0 && (c.Count == 0 && b.Count != 0) || (c.Count != 0 && b.Count == 0))
        {
            var set = (c.Count > 0 ? c : b).ToList();
            var seq =  prefix.Concat(set).ToList();
            Accum.Add(seq);
            return;
        }

        var cb = new LinkedList<int>();
        var cc = new LinkedList<int>();
        var cp = new LinkedList<int>();
        b.Select(x => cb.AddLast(x)).ToList();
        c.Select(x => cc.AddLast(x)).ToList();
        prefix.Select(x => cp.AddLast(x)).ToList();

        if (cb.Count > 0)
        {
            var fb = cb.First.Value;
            cb.RemoveFirst();
            cp.AddLast(fb);
            Stitch(cb, cc, cp, Accum);
        }

        if (c.Count > 0)
        {
            var fc = c.First.Value;
            c.RemoveFirst();
            prefix.AddLast(fc);
            Stitch(b, c, prefix, Accum);
        }
    }
}