using LanguageExt;

namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

internal interface IRandomAndBasicBst
{
    Option<IBasicNode> Find(int value);
    void Insert(int value);
    void Delete(int value);
    Option<IBasicNode> Root { get; }
}