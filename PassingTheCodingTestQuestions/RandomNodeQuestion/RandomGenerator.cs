namespace PassingTheCodingTestQuestions.RandomNodeQuestion;

public static class RandomGenerator
{
    private static readonly Random Random = new Random(GenerateSeed());
    
    public static int Next(int minValue, int maxValue) => 
        Random.Next(minValue, maxValue + 1);
    
    private static int GenerateSeed()
    {
        var seed = Environment.TickCount;
        seed ^= System.Threading.Thread.CurrentThread.ManagedThreadId;
        seed ^= System.Diagnostics.Process.GetCurrentProcess().Id;
        seed ^= (int)GC.GetTotalMemory(false);
        return seed;
    }

}