using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2016.Days
{
    public class Day4
    {
        public static int SolvePart1(string inputString)
        {                                    
            return GetDays(inputString).Where(n => n.IsReal()).Sum(n => n.SectorId);
        }

        public static int SolvePart2(string inputString)
        {
            var days = GetDays(inputString);
            int sectorId = 0;

            foreach (var day in days)
            {
                if (day.GetDecryptedNames().Contains("pole"))
                    sectorId = day.SectorId;
            }            

            return sectorId;
        }

        private static List<Day4Result> GetDays(string inputString)
        {
            var daysList = new List<Day4Result>();
            var days = InputHelper.SplitByNewline(inputString);

            foreach (var day in days)
                daysList.Add(ExtractRoom(day.Trim()));

            return daysList;
        }

        private static Day4Result ExtractRoom(string inputString)
        {
            Day4Result res = new Day4Result();

            // Checksum
            string checksumPattern = @"\[?([a-z,A-Z]*){1}\]";            
            var match = Regex.Match(inputString, checksumPattern);            
            if (match.Success)
            {
                res.Checksum = match.Groups["1"].Value;
            }

            // Sector ID
            string sectorIdPattern = @"-?(\d+){1}\[";
            match = Regex.Match(inputString, sectorIdPattern);
            if (match.Success)
            {
                res.SectorId = int.Parse(match.Groups["1"].Value);
            }

            // Names
            var names = inputString.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            var names2 = names.Take(names.Count() - 1).ToList();
            res.Names = names2;

            return res;
        }
    }

    class Day4Result
    {
        public string Checksum { get; set; }
        public int SectorId { get; set; }
        public List<string> Names { get; set; }

        public Day4Result()
        {
            Names = new List<string>();
        }

        public string GetChecksum()
        {
            var l2 = new List<string>();
            foreach (var s in Names)
            {
                foreach (var c in s)
                {
                    l2.Add(c.ToString());
                }
            }

            Dictionary<string, int> vals = new Dictionary<string, int>();
            foreach (var s in l2)
            {
                if (vals.ContainsKey(s))
                    vals[s] += 1;
                else
                    vals.Add(s, 1);
            }
            var list = vals.Select(n => new { Character = n.Key, Count = n.Value }).ToList();
            var sorted = list.OrderByDescending(n => n.Count)
                .ThenBy(n => n.Character)
                .Take(5);

            string checksum = "";
            foreach (var s in sorted)
                checksum += s.Character;

            return checksum;
        }

        public string GetDecryptedNames()
        {
            string result = "";
            int int_a = (int)'a';
            int int_z = (int)'z';

            foreach (var name in Names)
            {
                for (int i =0; i < name.Length; i++)
                {
                    char c = name[i];
                    int charint = (int)c;
                    int counter = 0;

                    while (counter < SectorId)
                    {
                        if (charint == int_z)
                            charint = int_a;
                        else
                            charint++;

                        counter++;
                    }
                    
                    c = (char)charint;

                    result += c;
                }

                result += " ";
            }

            return result;
        }

        public bool IsReal()
        {
            return GetChecksum() == Checksum;
        }
    }
}
