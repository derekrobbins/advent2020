using System;
using System.IO;
using System.Linq;

namespace _2
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }

        static int PartOne() {
            return File.ReadAllLines("../../../input.txt")
                .Select(x => x.Split(' '))
                .Where(x => {
                    var parts = x[0].Split('-').Select(int.Parse).ToArray();
                    var charCount = x[2].Count(y => y == x[1][0]);
                    return charCount >= parts[0] && charCount <= parts[1];
                })
                .Count();
        }

        static int PartTwo() {
            return File.ReadAllLines("../../../input.txt")
                .Select(x => x.Split(' '))
                .Where(x => {
                    var parts = x[0].Split('-').Select(int.Parse).ToArray();
                    var testChar = x[1][0];
                    return x[2][parts[0] - 1] == testChar ^ x[2][parts[1] - 1] == testChar;
                })
                .Count();
        }
    }
}
