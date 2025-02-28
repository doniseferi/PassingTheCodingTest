using System.Diagnostics;

namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

public static class RandomGenerator
{
    private static readonly Random Random = new(GenerateSeed());

    public static int Next(int minValue, int maxValue)
    {
        return Random.Next(minValue, maxValue + 1);
    }

    private static int GenerateSeed()
    {
        var seed = Environment.TickCount;
        seed ^= Thread.CurrentThread.ManagedThreadId;
        seed ^= Process.GetCurrentProcess().Id;
        seed ^= (int)GC.GetTotalMemory(false);
        return seed;
    }
}