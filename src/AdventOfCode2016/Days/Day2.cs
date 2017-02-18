using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Days
{
    class Day2
    {
        public static string SolvePart1(string inputString)
        {
            char[,] pad = new char[,] {
                { '1', '2', '3' },
                { '4', '5', '6' }, 
                { '7', '8', '9' } };

            int x = 1;
            int y = 1;

            string result = "";
            
            var instructions = GetInstructionsArray(inputString);

            for (int i = 0; i < instructions.Length; i++)
            {
                var instr = instructions[i];

                foreach (var str in instr)
                {
                    switch (str)
                    {
                        case 'U':
                            y = y > 0 ? y - 1 : 0;
                            break;
                        case 'D':
                            y = y < 2 ? y + 1 : 2;
                            break;
                        case 'R':
                            x = x < 2 ? x + 1 : 2;
                            break;
                        case 'L':
                            x = x > 0 ? x - 1 : 0;
                            break;
                    }
                }
                result += pad[y, x];
            }

            return result;
        }

        public static string SolvePart2(string inputString)
        {
            char[,] pad = new char[,] {
                { '0', '0', '1', '0', '0' },
                { '0', '2', '3', '4', '0' },
                { '5', '6', '7', '8', '9' },
                { '0', 'A', 'B', 'C', '0' },
                { '0', '0', 'D', '0', '0' },
            };

            // Start on 5
            int x = 0;
            int y = 2; 

            string result = "";
            
            var instructions = GetInstructionsArray(inputString);

            for (int i = 0; i < instructions.Length; i++)
            {
                var instr = instructions[i];

                foreach (var str in instr)
                {
                    switch (str)
                    {
                        case 'U':
                            if (y > 0 && pad[y - 1, x] != '0')
                                y -= 1;
                            break;
                        case 'D':
                            if (y < 4 && pad[y + 1, x] != '0')
                                y += 1;
                            break;
                        case 'R':
                            if (x < 4 && pad[y, x + 1] != '0')
                                x += 1;
                            break;
                        case 'L':
                            if (x > 0 && pad[y, x - 1] != '0')
                                x -= 1;
                            break;
                    }
                }
                result += pad[y, x];
            }

            return result;
        }

        private static string[] GetInstructionsArray(string inputString)
        {
            return inputString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
