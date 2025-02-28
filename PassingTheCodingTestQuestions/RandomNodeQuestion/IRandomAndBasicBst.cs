using LanguageExt;

namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

internal interface IRandomAndBasicBst
{
    Option<IBasicNode> Root { get; }
    Option<IBasicNode> Find(int value);
    void Insert(int value);
    void Delete(int value);
    IBasicNode GetRandomNode();
}