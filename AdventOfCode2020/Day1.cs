using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day1
    {
        public Day1()
        {
        }

        public static int PartOne()
        {
            var lines = Utilities.GetLines(1, "\n");
            var numbers = new List<int>();

            foreach (var line in lines)
                numbers.Add(Int32.Parse(line));

            for (int i = 0; i < numbers.Count - 1; i++)
                if (numbers[i] < 2020)
                    for (int j = i + 1; j < numbers.Count; j++)
                        if (numbers[i] + numbers[j] == 2020)
                            return numbers[i] * numbers[j];


            return -1;
        }

        public static int PartTwo()
        {
            var lines = Utilities.GetLines(1, "\n");
            var numbers = new List<int>();

            foreach (var line in lines)
                numbers.Add(Int32.Parse(line));

            for (int i = 0; i < numbers.Count - 2; i++)
                if (numbers[i] < 2020)
                    for (int j = i + 1; j < numbers.Count - 1; j++)
                        if (numbers[i] + numbers[j] < 2020)
                            for (int k = j + 1; k < numbers.Count; k++)
                                if (numbers[i] + numbers[j] + numbers[k] == 2020)
                                    return numbers[i] * numbers[j] * numbers[k];

            return -1;
        }
    }
}
