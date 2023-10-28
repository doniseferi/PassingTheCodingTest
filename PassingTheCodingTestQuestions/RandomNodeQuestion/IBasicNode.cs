using LanguageExt;

namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

internal interface IBasicNode
{
    Option<IBasicNode> Left { get; }
    Option<IBasicNode> Right { get; }
    Option<IBasicNode> Find(int value);
    int Value { get; }
    void AddChild(int value);
    int Count();
    void DeleteChild(int value);
    Option<IBasicNode> GetLeftMostNode();
}