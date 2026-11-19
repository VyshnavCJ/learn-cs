namespace MathGame;

public static class Helper
{
    public static int[] GetDividableNumbers()
    {
        var random = new Random();
        var denominator = random.Next(1, 99);
        var quotient = random.Next(1, 99 / denominator);
        var numerator = denominator * quotient;
        return [numerator, denominator];
    }
}
