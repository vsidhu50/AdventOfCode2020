using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day4
    {
        public Day4()
        {
        }

        public static int PartOne()
        {
            var lines = Utilities.GetLines(4, "\n\n");
            var validCount = 0;

            var reqFields = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            foreach (var line in lines)
            {
                var fields = new Dictionary<string, string>();

                foreach (var pair in line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries))
                {
                    var parts = pair.Split(':');
                    fields.Add(parts[0], parts[1]);
                }

                if (reqFields.All(x => fields.ContainsKey(x)))
                    validCount++;
            }

            return validCount;
        }

        public static int PartTwo()
        {
            var lines = Utilities.GetLines(4, "\n\n");
            var validCount = 0;

            var reqFields = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            foreach (var line in lines)
            {
                var fields = new Dictionary<string, string>();

                foreach (var pair in line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries))
                {
                    var parts = pair.Split(':');
                    fields.Add(parts[0], parts[1]);
                }

                if (reqFields.All(x => fields.ContainsKey(x)) && fields.All(x => isValid(x.Key, x.Value)))
                    validCount++;
            }

            return validCount;
        }

        private static bool isValid(string field, string value)
        {
            switch (field)
            {
                case "byr":
                    return Int32.Parse(value) >= 1920 && Int32.Parse(value) <= 2002;
                case "iyr":
                    return Int32.Parse(value) >= 2010 && Int32.Parse(value) <= 2020;
                case "eyr":
                    return Int32.Parse(value) >= 2020 && Int32.Parse(value) <= 2030;
                case "hgt":
                    var pattern = @"^(\d+)(cm|in)$";
                    var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                    var match = regex.Match(value);

                    if (match.Success)
                    {
                        var height = Int32.Parse(match.Groups[1].ToString());
                        var type = match.Groups[2].ToString();
                        return type == "cm" ? height >= 150 && height <= 193 : height >= 59 && height <= 76;
                    }

                    return false;
                case "hcl":
                    var pattern1 = @"^#[0-9a-f]{6}$";
                    var regex1 = new Regex(pattern1, RegexOptions.IgnoreCase);
                    var match1 = regex1.Match(value);

                    return match1.Success;
                case "ecl":
                    return new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(value);
                case "pid":
                    var pattern2 = @"^\d{9}$";
                    var regex2 = new Regex(pattern2, RegexOptions.IgnoreCase);
                    var match2 = regex2.Match(value);

                    return match2.Success;
                case "cid":
                    return true;
            }

            return false;
        }
    }
}
