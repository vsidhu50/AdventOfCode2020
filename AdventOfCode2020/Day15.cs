using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class Day15
    {
        public Day15()
        {
        }

        public static int PartOne()
        {
            var input = new List<int> { 1,0,15,2,10,13 };
            var numbers = new Dictionary<int, int>();

            for (int i = 1; i < input.Count; i++)
            {
                numbers[input[i - 1]] = i;
            }

            var last = input[^1];
            var turn = input.Count + 1;

            while (turn < 2021)
            {
                if (!numbers.ContainsKey(last))
                {
                    numbers[last] = turn - 1;
                    last = 0;
                }
                else
                {
                    var diff = turn - 1 - numbers[last];
                    numbers[last] = turn - 1;
                    last = diff;
                }

                turn++;
            }

            return last;
        }

        public static int PartTwo()
        {
            var input = new List<int> { 1, 0, 15, 2, 10, 13 };
            var numbers = new Dictionary<int, int>();

            for (int i = 1; i < input.Count; i++)
            {
                numbers[input[i - 1]] = i;
            }

            var last = input[^1];
            var turn = input.Count + 1;

            while (turn < 30000001)
            {
                if (!numbers.ContainsKey(last))
                {
                    numbers[last] = turn - 1;
                    last = 0;
                }
                else
                {
                    var diff = turn - 1 - numbers[last];
                    numbers[last] = turn - 1;
                    last = diff;
                }

                turn++;
            }

            return last;
        }
    }
}
