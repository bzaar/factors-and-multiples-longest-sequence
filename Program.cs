using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FactorsAndMultiplesGame;

int longest = 45;
const int max = 100;
var stopwatch = Stopwatch.StartNew();
int[][] factorsAndMultiples = PrecomputeFactorsAndMultiples();
var used = new bool[max];
var stack = new Stack<IEnumerator<int>>();

IEnumerator<int> enumerator = Enumerable.Range(1, max-1)
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
            Console.Write(stopwatch.Elapsed + " " + stack.Count + ": ");
            Console.WriteLine(string.Join(" ", stack.Reverse().Select(e => e.Current)));
            longest = stack.Count;
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
    var fam = new FactorsAndMultiples(max);

    return Enumerable.Range(0, max)
        .Select(i => fam.Get(i + 1).ToArray())
        .ToArray();
}