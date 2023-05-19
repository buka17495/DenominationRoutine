namespace DenominationRoutine
{
    public class Program
    {
        private static readonly int[] Denominations = new int[] { 10, 50, 100 };

        public static int Denominate(int ammount)
        {
            var combinations = CalculateCombinations(ammount);

            if (combinations.Count == 0)
            {
                Console.WriteLine("No combinations available.");
            }
            else
            {
                foreach (var combination in combinations)
                {
                    var isFirst = true;
                    foreach (var c in combination)
                    {
                        if(!isFirst)
                            Console.Write(" + ");
                        Console.Write($"{c.Value} x {c.Key} EUR");
                        isFirst = false;
                    }
                    Console.WriteLine();
                }
            }

            return combinations.Count;
        }

        public static List<Dictionary<int, int>> CalculateCombinations(int amount)
        {
            var min = Denominations.Min();
            var dp = new List<Dictionary<int, int>>[amount + 1];
            dp[0] = new List<Dictionary<int, int>>() { new Dictionary<int, int>() };

            foreach (var denomination in Denominations)
            {
                for (var i = denomination; i <= amount; i += min)
                {
                    if (dp[i - denomination] != null)
                    {
                        foreach (var combination in dp[i - denomination])
                        {
                            var newCombination = new Dictionary<int, int>(combination);
                            if (!newCombination.ContainsKey(denomination))
                                newCombination[denomination] = 0;
                            newCombination[denomination]++;
                            if (dp[i] == null)
                                dp[i] = new List<Dictionary<int, int>>();
                            dp[i].Add(newCombination);
                        }
                    }
                }
            }a

            return dp[amount] ?? new List<Dictionary<int, int>>();
        }
    }
}