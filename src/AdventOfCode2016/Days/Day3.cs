using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Days
{
    class Day3
    {
        public static int SolvePart1(string inputString)
        {
            var strArray = inputString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            List<Tuple<int, int, int>> tuples = new List<Tuple<int, int, int>>();

            int numTriangles = 0;

            foreach (var str in strArray)
            {
                string currStr = "";
                List<int> l = new List<int>();

                for (int i=0; i < str.Length; i++)
                {
                    var ch = str[i];
                    if (ch != ' ')
                    {
                        currStr += ch;
                    }
                    else
                    {
                        if (currStr != string.Empty)
                        {
                            l.Add(int.Parse(currStr));
                            currStr = "";                            
                        }
                    }

                    if (i == str.Length - 1)
                        l.Add(int.Parse(currStr));
                }

                tuples.Add(new Tuple<int, int, int>(l[0], l[1], l[2]));
            }

            numTriangles = tuples.Where(n => IsTriangle(n.Item1, n.Item2, n.Item3)).Count();

            return numTriangles;
        }

        public static int SolvePart2(string inputString)
        {
            var strArray = inputString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            List<int> all = new List<int>();

            int numTriangles = 0;

            foreach (var str in strArray)
            {
                string currStr = "";
                List<int> l = new List<int>();

                for (int i = 0; i < str.Length; i++)
                {
                    var ch = str[i];
                    if (ch != ' ')
                    {
                        currStr += ch;
                    }
                    else
                    {
                        if (currStr != string.Empty)
                        {
                            all.Add(int.Parse(currStr));
                            currStr = "";
                        }
                    }

                    if (i == str.Length - 1)
                        all.Add(int.Parse(currStr));
                }

                
            }
            List<Tuple<int, int, int>> listColumns = new List<Tuple<int, int, int>>();

            int counter = 0;
            int x = 0, y = 0, z = 0;
            for (int i = 0; i < all.Count; i += 3)
            {
                if (counter == 0)
                {
                    x = all[i];
                    counter++;
                }
                else if (counter == 1)
                {
                    y = all[i];
                    counter++;
                }
                else
                {
                    z = all[i];
                    listColumns.Add(new Tuple<int, int, int>(x, y, z));
                    counter = 0;
                }
            }

            counter = 0;
            for (int i = 1; i < all.Count; i += 3)
            {
                if (counter == 0)
                {
                    x = all[i];
                    counter++;
                }
                else if (counter == 1)
                {
                    y = all[i];
                    counter++;
                }
                else
                {
                    z = all[i];
                    listColumns.Add(new Tuple<int, int, int>(x, y, z));
                    counter = 0;
                }
            }

            counter = 0;            
            for (int i = 2; i < all.Count; i += 3)
            {
                if (counter == 0)
                {
                    x = all[i];
                    counter++;
                }
                else if (counter == 1)
                {
                    y = all[i];
                    counter++;
                }
                else
                {
                    z = all[i];
                    listColumns.Add(new Tuple<int, int, int>(x, y, z));
                    counter = 0;
                }
            }

            numTriangles = listColumns.Where(n => IsTriangle(n.Item1, n.Item2, n.Item3)).Count();

            return numTriangles;
        }

        private static bool IsTriangle(int x, int y, int z)
        {
            return  (x + y) > z && (x + z) > y && (y + z) > x;
        }
    }
}
