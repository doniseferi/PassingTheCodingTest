using LanguageExt;

namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

internal interface IBasicNode : IGetNextInOrderSuccessor, IMutableNode
{
    Option<IBasicNode> Left { get; }
    Option<IBasicNode> Right { get; }
    int Value { get; }
    Option<IBasicNode> Find(int value);
    void AddChild(int value);
    int Count();
    void UpdateNode(int value);
}

internal interface IMutableNode
{
    void DeleteChild(int value);
}

internal interface IGetNextInOrderSuccessor
{
    Option<IBasicNode> GetNextInOrderSuccessor();
}