using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Days
{
    public class Day5
    {
        private static MD5 _md5;
        private static string _roomId;

        public static string SolvePart1(string inputString)
        {
            _roomId = inputString;
            _md5 = MD5.Create();

            string result = "";
            int i = 0;
            while (result.Length < 8)
            {
                string hashStr = GetHashStr(i++);

                if (hashStr.StartsWith("00-00-0"))
                {
                    result += hashStr.Substring(7, 1);
                }
            }

            return result;
        }

        private static string GetHashStr(int i)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(_roomId + i);
            var hash = _md5.ComputeHash(buffer);
            var hashStr = BitConverter.ToString(hash);

            return hashStr;
        }

        public static string SolvePart2(string inputString)
        {
            _roomId = inputString;
            _md5 = MD5.Create();
            
            char[] res = new char[] { '-', '-', '-', '-', '-', '-', '-', '-' };
            int i = 0;
            while (res.Contains('-'))
            {
                string hashStr = GetHashStr(i++);

                if (hashStr.StartsWith("00-00-0"))
                {
                    string pos = hashStr.Substring(7, 1);
                    int iPos = -1;
                    if (int.TryParse(pos, out iPos) && iPos < 8 && iPos >= 0 && res[iPos] == '-')
                    {
                        Console.WriteLine($"Found position: {iPos}");
                        res[iPos] = hashStr.Substring(9, 1).First();
                    }
                    
                }
            }

            return new string(res);
        }
    }
}
