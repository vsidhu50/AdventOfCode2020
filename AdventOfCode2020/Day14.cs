using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day14
    {
        public Day14()
        {
        }

        public static long PartOne()
        {
            var lines = Utilities.GetInputLines(14);
            var mask = "";
            var mem = new Dictionary<int, long>();

            foreach (var line in lines)
            {
                var trimmed = line.Replace(" ", "").Replace("]", "").Replace("[", "");
                var action = trimmed.Split("=")[0];
                var result = trimmed.Split("=")[1];

                if (action == "mask")
                {
                    mask = result;
                }
                else
                {
                    var address = Int32.Parse(action.Replace("mem", ""));
                    var binary = new StringBuilder(Convert.ToString(Int32.Parse(result), 2).PadLeft(36, '0'));

                    for (int i = 0; i < 36; i++)
                    {
                        if (mask[i] != 'X')
                            binary[i] = mask[i];
                    }

                    mem[address] = Convert.ToInt64(binary.ToString(), 2);
                }
            }

            return mem.Values.Sum();
        }

        public static long PartTwo()
        {
            var lines = Utilities.GetInputLines(14);
            var mask = "";
            var mem = new Dictionary<long, long>();

            foreach (var line in lines)
            {
                var trimmed = line.Replace(" ", "").Replace("]", "").Replace("[", "");
                var action = trimmed.Split("=")[0];
                var result = trimmed.Split("=")[1];

                if (action == "mask")
                {
                    mask = result;
                }
                else
                {
                    var address = Int64.Parse(action.Replace("mem", ""));
                    var binary = new StringBuilder(Convert.ToString(address, 2).PadLeft(36, '0'));
                    var num = Int64.Parse(result);
                    var floatingPos = new List<int>();

                    for (int i = 0; i < 36; i++)
                    {
                        if (mask[i] == '1')
                            binary[i] = '1';
                        else if (mask[i] == 'X')
                        {
                            floatingPos.Add(35 - i);
                            binary[i] = '0';
                        }
                    }

                    if (floatingPos.Count == 0)
                        mem[address] = num;
                    else
                    {
                        var dec = Convert.ToInt64(binary.ToString(), 2);
                        var memories = new List<long>();

                        AllBin(dec, 0, floatingPos, memories);
                        foreach (var memory in memories)
                            mem[memory] = num;
                    }
                }
            }

            return mem.Values.Sum();
        }

        private static void AllBin(long dec, int index, List<int> floatingPos, List<long> results)
        {
            if (index < floatingPos.Count)
            {
                if (index == floatingPos.Count - 1)
                {
                    results.Add(dec);
                    results.Add(dec + (long)Math.Pow(2, floatingPos[index]));
                }
                else
                {
                    AllBin(dec, index + 1, floatingPos, results);
                    AllBin(dec + (long)Math.Pow(2, floatingPos[index]), index + 1, floatingPos, results);
                }
            }
        }
    }
    
}
