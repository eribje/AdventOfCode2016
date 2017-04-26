using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Days
{
    internal class Day6
    {
        const int NumPositions = 8;

        public static string SolvePart1(string inputString)
        {            
            var inputs = InputHelper.SplitByNewline(inputString);            

            string result = "";

            for (int i = 0; i < NumPositions; i++)
            {
                Dictionary<string, int> letters = new Dictionary<string, int>();

                for (int j=0; j < inputs.Length; j++)
                {
                    string currentStr = inputs[j];                    
                    var currentLetter = currentStr[i].ToString();

                    if (!letters.ContainsKey(currentLetter))
                        letters.Add(currentLetter, 1);
                    else
                        letters[currentLetter] += 1;
                }

                var sorted = letters.OrderByDescending(m => m.Value);

                result += sorted.First().Key;
            }

            return result;
        }

        public static string SolvePart2(string inputString)
        {
            var inputs = InputHelper.SplitByNewline(inputString);

            string result = "";

            for (int i = 0; i < NumPositions; i++)
            {
                Dictionary<string, int> pos = new Dictionary<string, int>();

                for (int j = 0; j < inputs.Length; j++)
                {
                    string currentStr = inputs[j];
                    var currentLetter = currentStr[i].ToString();

                    if (!pos.ContainsKey(currentLetter))
                        pos.Add(currentLetter, 1);
                    else
                        pos[currentLetter] += 1;
                }

                var sorted = pos.OrderBy(m => m.Value);

                result += sorted.First().Key;
            }

            return result;
        }
    }
}
