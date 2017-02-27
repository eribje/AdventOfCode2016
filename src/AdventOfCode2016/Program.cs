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
            RunTest<string, string>("5b", Inputs.InputDay5, Day5.SolvePart2);
        }

        private static void RunTest<T,U>(string dayNumber, T input, Func<T, U> f) where T : class
        {
            Console.WriteLine($"Running day {dayNumber}");

            var result = f(input);

            Console.WriteLine($"Result is {result}");
        }
        
    }
}
