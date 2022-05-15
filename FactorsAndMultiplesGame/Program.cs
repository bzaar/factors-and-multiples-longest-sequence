using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FactorsAndMultiplesGame
{
    public static class Program
    {
        const int Max = 100;
        
        static void Main()
        {
            var stopwatch = Stopwatch.StartNew();

            int[][] factorsAndMultiples = Enumerable.Range(0, Max)
                .Select(i => GetFactorsAndMultiples(i+1).ToArray())
                .ToArray();

            bool[] used = new bool[Max];
            
            var stack = new Stack<IEnumerator<int>>();
            
            int longest = 15;

            IEnumerator<int> enumerator = Enumerable.Range(1, Max-1)
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
        }

        public static IEnumerable<int> GetFactorsAndMultiples(int num)
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
}