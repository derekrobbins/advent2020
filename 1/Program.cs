using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using MoreLinq;

namespace _1
{
    class Program {
        private const int TARGET = 2020;
        static async Task Main(string[] args) {
            // await ProblemOne();
            await ProblemTwo();
        }

        static private async Task ProblemTwo() {
            var values = await GetInput();
            var addedValues = values
                .SelectMany(x => values
                    .Except(new [] { x })
                    .Select(y => new { x, y, sum = x + y }))
                .Where(x => x.sum <= TARGET - values.Min())
                
                // assume only one answer so no sense running through all of the different sums
                .DistinctBy(x => x.sum)
                .OrderByDescending(x => x.sum)
                .ToArray();
            var iterations = 0;
            var sortedValues = values.OrderBy(x => x).ToArray();
            foreach (var lowNumer in sortedValues) {
                foreach (var highNumber in addedValues) {
                    iterations++;
                    var result = lowNumer + highNumber.sum;
                    if (result < TARGET) {
                        break;
                    }
                    if (result == TARGET) {
                        Console.WriteLine(lowNumer * highNumber.x * highNumber.y);
                        Console.WriteLine($"{iterations} iterations");
                        Console.WriteLine($"{values.Length} lines");
                        return;
                    }
                }
            }
            Console.WriteLine($"{iterations} iterations");
            Console.WriteLine($"{values.Length} lines");
        }

        static private async Task ProblemOne() {
            var iterations = 0;
            var values = await GetInput();
            var sortedValues = values.OrderBy(x => x).ToArray();
            foreach (var lowNumer in sortedValues) {
                foreach (var highNumber in sortedValues.Reverse()) {
                    iterations++;
                    var result = lowNumer + highNumber;
                    if (result < TARGET) {
                        break;
                    }
                    if (result == TARGET) {
                        Console.WriteLine(lowNumer * highNumber);
                        Console.WriteLine($"{iterations} iterations");
                        Console.WriteLine($"{values.Length} lines");
                        return;
                    }
                }
            }
        }

        static private async Task<int[]> GetInput() {
            return (await File.ReadAllLinesAsync("../../../input1.txt")).Select(int.Parse).ToArray();
        }
    }
}
