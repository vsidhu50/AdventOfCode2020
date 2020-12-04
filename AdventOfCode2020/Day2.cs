using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day2
    {
        public Day2()
        {
        }

        public static int PartOne()
        {
            var validCount = 0;
            var lines = Utilities.GetLines(2);

            var pattern = @"(\d+)-(\d+) (\w): (\w+)";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            foreach (var line in lines)
            {
                var match = regex.Match(line);
                var min = Int32.Parse(match.Groups[1].ToString());
                var max = Int32.Parse(match.Groups[2].ToString());
                var letter = Char.Parse(match.Groups[3].ToString());
                var password = match.Groups[4].ToString();
                var letterCount = 0;

                foreach (var character in password)
                    if (character == letter)
                        letterCount++;

                if (letterCount >= min && letterCount <= max)
                    validCount++;
            }


            return validCount;
        }

        public static int PartTwo()
        {
            var validCount = 0;
            var lines = Utilities.GetLines(2);

            var pattern = @"(\d+)-(\d+) (\w): (\w+)";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            foreach (var line in lines)
            {
                var match = regex.Match(line);
                var first = Int32.Parse(match.Groups[1].ToString()) - 1;
                var second = Int32.Parse(match.Groups[2].ToString()) - 1;
                var letter = Char.Parse(match.Groups[3].ToString());
                var password = match.Groups[4].ToString();

                if ((first < password.Length && password[first] == letter) ^ (second < password.Length && password[second] == letter))
                    validCount++;
            }


            return validCount;
        }
    }
}
