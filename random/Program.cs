using System;
using System.Linq;

namespace random
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[]
            {
                // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };              // 9 (or words.Length) ^0
            
            Console.WriteLine($"The last word is {words[^1]}");
            
            string[] quickBrownFox = words[2..3];
            foreach (var word in quickBrownFox)
                Console.Write($"< {word} >");
            Console.WriteLine();
            
            int[] sequence = Sequence(1000);


            for(int start = 0; start < sequence.Length; start += 100)
            {
                Range r = start..(start+10);
                var (min, max, average) = MovingAverage(sequence, r);
                Console.WriteLine($"From {r.Start} to {r.End}:    \tMin: {min},\tMax: {max},\tAverage: {average}");
            }

            for (int start = 0; start < sequence.Length; start += 100)
            {
                Range r = ^(start + 10)..^start;
                var (min, max, average) = MovingAverage(sequence, r);
                Console.WriteLine($"From {r.Start} to {r.End}:  \tMin: {min},\tMax: {max},\tAverage: {average}");
            }

            (int min, int max, double average) MovingAverage(int[] subSequence, Range range) =>
            (
                subSequence[range].Min(),
                subSequence[range].Max(),
                subSequence[range].Average()
            );

            int[] Sequence(int count) =>
                Enumerable.Range(0, count).Select(x => (int)(Math.Sqrt(x) * 100)).ToArray();

        }
    }
}
