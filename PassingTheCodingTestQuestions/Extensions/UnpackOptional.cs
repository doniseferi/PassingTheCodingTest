using LanguageExt;

namespace PassingTheCodingTestQuestions.Extensions;

public static class UnpackOptional
{
    public static T UnpackUnsafely<T>(this Option<T> optional)
    {
        return optional.IfNone(() => throw new OptionIsNoneException());
    }
}