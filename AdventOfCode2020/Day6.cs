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

            return groups.Aggregate(0, (totalAny, group) => totalAny + group.Replace("\n", "").Distinct().Count());
        }

        public static int PartTwo()
        {
            var groups = Utilities.GetInputParagraphs(6);

            return groups.Aggregate(0, (totalEvery, group) => totalEvery + group.Replace("\n", "").Distinct().Where(c => Utilities.GetLines(group).All(x => x.Contains(c))).Count());
        }

    }
}
