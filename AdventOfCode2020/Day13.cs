using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public class Day13
    {
        public Day13()
        {
        }

        public static int PartOne()
        {
            var lines = Utilities.GetInputLines(13);
            var earliest = Int32.Parse(lines[0]);
            var buses = Utilities.GetNums(lines[1].Replace("x,", ""));

            for (int i = earliest; i < Int32.MaxValue; i++)
            {
                foreach (var bus in buses)
                {
                    if (i % bus == 0)
                        return (i - earliest) * bus;
                }
            }

            return -1;
        }

        public static long PartTwo()
        {
            var lines = Utilities.GetInputLines(13);
            var buses = Utilities.GetNums(lines[1].Replace("x", "0"));
            var times = buses.Select((x, i) => (id: x, offset: i)).Where(bus => bus.id != 0);

            var first = times.First();
            long inc = first.id;

            var unmatched = new List<(int id, int offset)>(times.Where(x => x != first));
            var matched = new List<(int id, int offset)> { first };

            for (long t = 0; t < Int64.MaxValue; t += inc)
            {
                for (int i = 0; i < unmatched.Count; i++)
                {
                    if ((t + unmatched[i].offset) % unmatched[i].id == 0)
                    {
                        matched.Add((unmatched[i].id, unmatched[i].offset));
                        inc *= unmatched[i].id;
                        unmatched.Remove((unmatched[i].id, unmatched[i].offset));
                    }
                }

                if (matched.Count == times.Count())
                    return t;
            }

            return -1;
        }

    }
}
