using PassingTheCodingTestQuestions.CoinChange;

namespace TestProject1;

[TestFixture]
public class CoinChangePosibilitiesTests
{
    [Test]
    public void TestAllCombinations_Example1()
    {
        int[] coins = new int[] {1, 2, 5, 10};
        int amount = 12;
        var expected = 15;

        var result = CoinChange.GetAllCombinations(coins, amount);
        Assert.Equals(expected, result);    }

    [Test]
    public void TestAllCombinations_Example2()
    {
        int[] coins = new int[] {2};
        int amount = 3;

        var result = CoinChange.GetAllCombinations(coins, amount);
        Assert.Equals(0, result);    }

    [Test]
    public void TestAllCombinations_ZeroAmount()
    {
        int[] coins = new int[] {1, 2, 5};
        int amount = 0;
        var expected = new List<IList<int>> { new List<int>() };

        var result = CoinChange.GetAllCombinations(coins, amount);
        Assert.Equals(1, result);    }

    [Test]
    public void TestAllCombinations_NoCoins()
    {
        int[] coins = new int[] {};
        int amount = 7;
        var expected = new List<IList<int>>();

        var result = CoinChange.GetAllCombinations(coins, amount);
        Assert.Equals(0, result);    }

    [Test]
    public void TestAllCombinations_ExactMatch()
    {
        int[] coins = new int[] {1, 3, 4};
        int amount = 6;
        var expected = new List<IList<int>>
        {
            new List<int> {1, 1, 1, 1, 1, 1},
            new List<int> {1, 1, 1, 3},
            new List<int> {1, 1, 4},
            new List<int> {3, 3}
        };

        var result = CoinChange.GetAllCombinations(coins, amount);
        Assert.Equals(4, result);
        
    }
}