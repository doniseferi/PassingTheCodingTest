namespace PassingTheCodingTestQuestions.CoinChange;

public static class CoinChange
{
    public static int GetAllCombinations(int[] coins, int amount)
    {
        var table = new int[amount + 1];
        table[0] = 1;
        foreach (var coin in coins)
            for (var c = coin; c <= amount; c++)
                table[c] += table[c - coin];

        return table[amount];
    }
}