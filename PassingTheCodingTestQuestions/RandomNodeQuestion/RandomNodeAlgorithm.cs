using PassingTheCodingTestQuestions.Extensions;

namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

internal class RandomNodeAlgorithm
{
    public static IBasicNode GetRandomNode(IBasicNode root)
    {
        ArgumentNullException.ThrowIfNull(root, nameof(root));

        var moveToLeftBranch = root.Left.Map(x => x.Count()).IfNone(() => 0);
        var stayOnCurrentNode = 1 + moveToLeftBranch;
        var totalNodesAtCurrentLevel = root.Count();
        var randomValue = RandomGenerator.Next(1, totalNodesAtCurrentLevel);
        return randomValue == stayOnCurrentNode
            ? root
            : randomValue < stayOnCurrentNode
                ? GetRandomNode(root.Left.UnpackUnsafely())
                : GetRandomNode(root.Right.UnpackUnsafely());
    }
}