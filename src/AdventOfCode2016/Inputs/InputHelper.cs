using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class InputHelper
    {
        public static string[] SplitByNewline(string s, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            return s.Split(new[] { Environment.NewLine }, options);
        }
    }
}
