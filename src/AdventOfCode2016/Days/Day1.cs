using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Days
{
    enum Direction { North, East, South, West }

    internal class Day1
    {
        static HashSet<string> visitedLocations = new HashSet<string>();

        public static int SolvePart1(string inputString)
        {
            Direction currDirection = Direction.North;

            var instr = inputString.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int x = 0, y = 0;

            foreach (var i in instr)
            {
                string direction = i.Substring(0, 1);
                int numBlocks = int.Parse(i.Trim().Substring(1));
                bool isRightDirection = direction == "R";
                int directionFactor = isRightDirection ? 1 : -1;

                if (currDirection == Direction.North)
                {                    
                    x += numBlocks * directionFactor;
                    currDirection = isRightDirection ? Direction.East : Direction.West;                    
                }

                else if (currDirection == Direction.East)
                {                    
                    y += numBlocks * directionFactor;
                    currDirection = isRightDirection ? Direction.South : Direction.North;                    
                }
                else if (currDirection == Direction.South)
                {
                    x -= numBlocks * directionFactor;
                    currDirection = isRightDirection ? Direction.West : Direction.East;                    
                }
                else if (currDirection == Direction.West)
                {
                    y -= numBlocks * directionFactor;
                    currDirection = isRightDirection ? Direction.North : Direction.South;                    
                }                
            }

            int blocks = Math.Abs(x) + Math.Abs(y);

            return blocks;
        }

        public static int SolvePart2(string inputString)
        {
            AddToVisitedLocations(0, 0);

            Direction currDirection = Direction.North;

            var instr = inputString.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int x = 0, y = 0;
            bool done = false;

            for (int i=0; i < instr.Length && !done; i++)
            {
                string s = instr[i];
                string direction = s.Substring(0, 1);
                int numBlocks = int.Parse(s.Trim().Substring(1));
                bool isRightDirection = direction == "R";
                int directionFactor = isRightDirection ? 1 : -1;                

                if (currDirection == Direction.North)
                {
                    for (int j = 1; j <= numBlocks && !done; j++)
                    {
                        x += 1 * directionFactor;
                        var result = AddToVisitedLocations(x, y);
                        if (result == 0) { done = true; break; }
                    }                                                                     
                        
                    if (!done)
                    { 
                        currDirection = isRightDirection ? Direction.East : Direction.West;
                    }
                }

                else if (currDirection == Direction.East)
                {
                    for (int j = 1; j <= numBlocks && !done; j++)
                    {
                        y += 1 * directionFactor;
                        var result = AddToVisitedLocations(x, y);
                        if (result == 0) { done = true; break; }
                    }

                    if (!done)
                    {
                        currDirection = isRightDirection ? Direction.South : Direction.North;
                    }
                }
                else if (currDirection == Direction.South)
                {
                    for (int j = 1; j <= numBlocks; j++)
                    {
                        x -= 1 * directionFactor;
                        var result = AddToVisitedLocations(x, y);
                        if (result == 0) { done = true; break; }
                    }

                    if (!done)
                    { 
                        currDirection = isRightDirection ? Direction.West : Direction.East;
                    }
                }
                else if (currDirection == Direction.West)
                {
                    for (int j = 1; j <= numBlocks && !done; j++)
                    {
                        y -= 1 * directionFactor;
                        var result = AddToVisitedLocations(x, y);
                        if (result == 0) { done = true; break; }
                    }

                    if (!done)
                    {
                        currDirection = isRightDirection ? Direction.North : Direction.South;
                    }
                }                                
            }

            int blocks = Math.Abs(x) + Math.Abs(y);

            return blocks;
        }

        private static int AddToVisitedLocations(int x, int y)
        {
            string location = $"{x},{y}";

            if (!visitedLocations.Contains(location))
            {
                visitedLocations.Add(location);
                return 1;
            }
            return 0;
        }        
    }
}
