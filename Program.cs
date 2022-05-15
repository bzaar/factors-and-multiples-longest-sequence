int longest = 45; // do not print anything shorter than this
const int max = 100;
var stopwatch = System.Diagnostics.Stopwatch.StartNew();
var used = new bool[max];
var stack = new Stack<IEnumerator<int>>();
int[][] factorsAndMultiples = PrecomputeFactorsAndMultiples();

Console.WriteLine("The average number of factors and multiples per number is " + 
    factorsAndMultiples.Select(fam => (double) fam.Length).Average());

IEnumerator<int> enumerator = Enumerable.Range(1, max)
    .Reverse()
    .GetEnumerator();

enumerator.MoveNext();

for (;;)
{
    IEnumerator<int> enumerator1 = factorsAndMultiples[enumerator.Current-1]
        .Where(i => !used[i-1])
        .GetEnumerator();

    if (enumerator1.MoveNext())
    {
        stack.Push(enumerator);
        used[enumerator.Current - 1] = true;
        enumerator = enumerator1;

        if (stack.Count > longest)
        {
            longest = stack.Count;
            Console.Write(stopwatch.Elapsed + " " + stack.Count + ": ");
            Console.WriteLine(string.Join(" ", stack.Reverse().Select(e => e.Current)));
        }
    }
    else
    {
        while (!enumerator.MoveNext())
        {
            if (stack.Count == 0) return;
            enumerator = stack.Pop();
            used[enumerator.Current - 1] = false;
        }
    }
}

int[][] PrecomputeFactorsAndMultiples()
{
    var fam = new FactorsAndMultiplesGame.FactorsAndMultiples(max);

    return Enumerable.Range(1, max)
        .Select(i => fam.Get(i).ToArray())
        .ToArray();
}