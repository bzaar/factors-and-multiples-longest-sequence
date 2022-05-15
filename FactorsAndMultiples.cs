namespace FactorsAndMultiplesGame;

public record FactorsAndMultiples(int Max)
{
    public IEnumerable<int> Get(int num)
    {
        for (int m = num * 2; m <= Max; m += num)
        {
            yield return m;
        }
    
        for (int f = 1; f <= num / 2; ++f)
        {
            if (num % f == 0)
            {
                yield return f;
            }
        }
    }
}