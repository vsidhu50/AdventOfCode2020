using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day8
    {
        public Day8()
        {
        }

        public static int PartOne()
        {
            var lines = Utilities.GetInputLines(8);
            var instructions = new List<(string instruction, int num)>();
            var acc = 0;

            foreach (var line in lines)
            {
                var pattern = @"^(\w{3}) (\+|-)(\d+)$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                var match = regex.Match(line);
                var num = Int32.Parse(match.Groups[3].ToString()) * (match.Groups[2].ToString() == "-" ? -1 : 1);
                var instruction = match.Groups[1].ToString();

                instructions.Add((instruction, num));
            }

            var executed = new List<int>();
            var curr = 0;

            while (!executed.Contains(curr))
            {
                executed.Add(curr);

                switch (instructions[curr].instruction)
                {
                    case "nop":
                        curr++;
                        break;
                    case "acc":
                        acc += instructions[curr].num;
                        curr++;
                        break;
                    case "jmp":
                        curr += instructions[curr].num;
                        break;
                }
            }

            return acc;
        }

        public static int PartTwo()
        {
            var lines = Utilities.GetInputLines(8);

            var instructions = new List<(string instruction, int num)>();

            foreach (var line in lines)
            {
                var pattern = @"^(\w{3}) (\+|-)(\d+)$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                var match = regex.Match(line);
                var num = Int32.Parse(match.Groups[3].ToString()) * (match.Groups[2].ToString() == "-" ? -1 : 1);
                var instruction = match.Groups[1].ToString();
                instructions.Add((instruction, num));
            }

            for (int i = 0; i < instructions.Count; i++)
            {
                var result = ChangeOne(i, "nop", "jmp", new List<(string instruction, int num)>(instructions));
                if (result != -1)
                    return result;
            }

            for (int i = 0; i < instructions.Count; i++)
            {
                var result = ChangeOne(i, "jmp", "nop", new List<(string instruction, int num)>(instructions));
                if (result != -1)
                    return result;
            }

            return -1;
        }

        public static int ChangeOne(int index, string from, string to, List<(string instruction, int num)> instructions)
        {
            if (instructions[index].instruction == from)
            {
                instructions[index] = (to, instructions[index].num);

                var executed = new List<int>();
                var curr = 0;
                var acc = 0;

                while (!executed.Contains(curr))
                {
                    executed.Add(curr);

                    if (curr == instructions.Count)
                        return acc;

                    switch (instructions[curr].instruction)
                    {
                        case "nop":
                            curr++;
                            break;
                        case "acc":
                            acc += instructions[curr].num;
                            curr++;
                            break;
                        case "jmp":
                            curr += instructions[curr].num;
                            break;
                    }
                }
            }

            return -1;
        }

    }
}
