using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Days
{
    internal class Day9
    {       
        public static int SolvePart1(string inputString)
        {
            StringBuilder resultString = new StringBuilder();
            int startPos;
            int endPos;

            for (int i=0; i < inputString.Length; i++)
            {
                string s = inputString.Substring(i, 1);
                if (s == "(")
                {
                    startPos = i;
                    endPos = inputString.IndexOf(")", startPos);

                    string ds = inputString.Substring(startPos+1, endPos - (startPos+1));
                    int xPos = ds.IndexOf("x");
                    int numCharacters = int.Parse(ds.Substring(0, xPos));
                    int numRepetitions = int.Parse(ds.Substring(xPos + 1));

                    string sub = inputString.Substring(endPos + 1, numCharacters);
                    resultString.Append(string.Concat(Enumerable.Repeat(sub, numRepetitions)));

                    i = endPos + numCharacters;
                }
                else
                {
                    resultString.Append(s);
                }
            }

            return resultString.Length;
        }

        public static int SolvePart2(string inputString)
        {
            StringBuilder resultString = new StringBuilder();
            int startPos;
            int endPos;

            for (int i = 0; i < inputString.Length; i++)
            {
                string s = inputString.Substring(i, 1);
                if (s == "(")
                {
                    startPos = i;
                    endPos = inputString.IndexOf(")", startPos);

                    string ds = inputString.Substring(startPos + 1, endPos - (startPos + 1));
                    int xPos = ds.IndexOf("x");
                    int numCharacters = int.Parse(ds.Substring(0, xPos));
                    int numRepetitions = int.Parse(ds.Substring(xPos + 1));

                    string sub = inputString.Substring(endPos + 1, numCharacters);
                    resultString.Append(string.Concat(Enumerable.Repeat(sub, numRepetitions)));

                    i = endPos + numCharacters;
                }
                else
                {
                    resultString.Append(s);
                }
            }

            return resultString.Length;
        }
    }
}
