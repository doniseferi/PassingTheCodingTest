using System.Diagnostics;
using PassingTheCodingTestQuestions.Extensions;

namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

internal class RandomNodeAlgorithm
{
    public static IBasicNode Get(IBasicNode root)
    {
        ArgumentNullException.ThrowIfNull(root, nameof(root));
        
        var moveToLeftBranch = root.Left.Map(x => x.Count()).IfNone(() => 0);
        var rightCount = root.Right.Map(x => x.Count()).IfNone(0);
        var stayOnCurrentNode = 1 + moveToLeftBranch;
        var moveToRightBranch = root.Right.Map(x => 1 + stayOnCurrentNode).IfNone(0);
        var totalNodesAtCurrentLevel = root.Count();
        var randomValue = RandomGenerator.Next(1, totalNodesAtCurrentLevel);
        return randomValue == stayOnCurrentNode
            ? root
            : randomValue < stayOnCurrentNode
                ? Get(root.Left.UnpackUnsafely())
                : Get(root.Right.UnpackUnsafely());
    }
}