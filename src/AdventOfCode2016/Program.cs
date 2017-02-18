using AdventOfCode2016.Days;
using System;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Program
    {
        public delegate T DayRunner<T>(string input, out T output);

        static void Main(string[] args)
        {
            RunTest<string, int>("1", Inputs.InputDay1, Day1.SolvePart1);
            RunTest<string, string>("2", Inputs.InputDay2, Day2.SolvePart1);
            RunTest<string, int>("9", Inputs.InputDay9, Day9.SolvePart1);

            RunTest<string, int>("3", Inputs.InputDay3, Day3.SolvePart1);
            RunTest<string, int>("3", Inputs.InputDay3, Day3.SolvePart2);
        }

        private static void RunTest<T,U>(string dayNumber, T input, Func<T, U> f) where T : class
        {
            Console.WriteLine($"Running day {dayNumber}");

            var result = f(input);

            Console.WriteLine($"Result is {result}");
        }
        
    }
}
