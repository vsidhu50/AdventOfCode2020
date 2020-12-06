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
            var maxSeat = 0;

            foreach (var line in lines)
            {
                var row = Convert.ToInt32(line.Substring(0,7).Replace('F', '0').Replace('B', '1'), 2);
                var col = Convert.ToInt32(line.Substring(7, 3).Replace('L', '0').Replace('R', '1'), 2);

                maxSeat = Math.Max(row * 8 + col, maxSeat);
            }

            return maxSeat;
        }

        public static int PartTwo()
        {
            var lines = Utilities.GetInputLines(5);
            var filledSeats = new List<int>();

            foreach (var line in lines)
            {
                var row = Convert.ToInt32(line.Substring(0, 7).Replace('F', '0').Replace('B', '1'), 2);
                var col = Convert.ToInt32(line.Substring(7, 3).Replace('L', '0').Replace('R', '1'), 2);

                filledSeats.Add(row * 8 + col);
            }

            filledSeats.Sort();

            for (int i = 1; i < filledSeats.Count; i++)
            {
                if (filledSeats[i] == filledSeats[i - 1] + 2)
                    return filledSeats[i] - 1;
            }

            return 0;
        }
    }
}
