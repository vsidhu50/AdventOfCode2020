using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day5
    {
        public Day5()
        {
        }

        public static int PartOne()
        {
            var lines = Utilities.GetInputLines(5);

            return lines.Select(line => Convert.ToInt32(line.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1'), 2)).Max();
        }

        public static int PartTwo()
        {
            var lines = Utilities.GetInputLines(5);
            var filledSeats = lines.Select(line => Convert.ToInt32(line.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1'), 2)).OrderBy(x => x).ToList();

            for (int i = 1; i < filledSeats.Count; i++)
            {
                if (filledSeats[i] == filledSeats[i - 1] + 2)
                    return filledSeats[i] - 1;
            }

            return -1;
        }
    }
}
