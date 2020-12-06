using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day6
    {
        public Day6()
        {
        }

        public static int PartOne()
        {
            var groups = Utilities.GetInputParagraphs(6);
            var totalAny = 0;

            foreach (var group in groups)
            {
                var answers = new HashSet<char>();

                foreach(var line in Utilities.GetLines(group))
                {
                    foreach (var letter in line)
                        answers.Add(letter);
                }

                totalAny += answers.Count;
            }

            return totalAny;
        }

        public static int PartTwo()
        {
            var groups = Utilities.GetInputParagraphs(6);
            var totalEvery = 0;

            foreach (var group in groups)
            {
                var answers = new HashSet<char>();
                var lines = Utilities.GetLines(group);

                foreach (var line in lines)
                {
                    foreach (var letter in line)
                        answers.Add(letter);
                }

                totalEvery += answers.Where(c => lines.All(x => x.Contains(c))).Count();
            }

            return totalEvery;
        }


    }
}
