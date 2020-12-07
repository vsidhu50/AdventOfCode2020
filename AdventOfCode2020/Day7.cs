using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day7
    {
        public Day7()
        {
        }

        public static int PartOne()
        {
            var lines = Utilities.GetInputLines(7);
            var canContainGold = 0;
            var bags = new Dictionary<string, List<(string color, int num)>>();

            foreach (var line in lines)
            {
                var nospaces = line.Replace(" ", "").Replace(".", "").Replace("bags", "").Replace("bag", "").Replace("contain", ":");
                var color = nospaces.Split(':')[0];
                var subBags = nospaces.Split(':')[1].Split(',');

                if (subBags[0] != "noother")
                {
                    var pairs = new List<(string, int)>();

                    foreach (var bag in subBags)
                    {
                        var pattern = @"^(\d+)(\w+)$";
                        var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                        var match = regex.Match(bag);
                        var num = Int32.Parse(match.Groups[1].ToString());
                        var subColor = match.Groups[2].ToString();

                        pairs.Add((subColor, num));
                    }

                    bags.Add(color, pairs);
                }
            }

            foreach (var bag in bags.Keys)
            {
                if (CanContainShinyGold(bag, bags))
                    canContainGold++;
            }

            return canContainGold - 1;
        }

        public static int PartTwo()
        {
            var lines = Utilities.GetInputLines(7);
            var bags = new Dictionary<string, List<(string color, int num)>>();

            foreach (var line in lines)
            {
                var nospaces = line.Replace(" ", "").Replace(".", "").Replace("bags", "").Replace("bag", "").Replace("contain", ":");
                var color = nospaces.Split(':')[0];
                var subBags = nospaces.Split(':')[1].Split(',');

                if (subBags[0] != "noother")
                {
                    var pairs = new List<(string, int)>();
                    foreach (var bag in subBags)
                    {
                        var pattern = @"^(\d+)(\w+)$";
                        var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                        var match = regex.Match(bag);
                        var num = Int32.Parse(match.Groups[1].ToString());
                        var subColor = match.Groups[2].ToString();

                        pairs.Add((subColor, num));
                    }
                    bags.Add(color, pairs);
                }
                else
                    bags.Add(color, null);
            }

            return NumContains("shinygold", bags);
        }

        private static bool CanContainShinyGold(string bag, Dictionary<string, List<(string color, int num)>> bags)
        {
            if (bag == "shinygold")
                return true;
            else
                return bags.ContainsKey(bag) && bags[bag].Where(sub => CanContainShinyGold(sub.color, bags)).Any();
        }

        private static int NumContains(string bag, Dictionary<string, List<(string color, int num)>> bags)
        {
            if (bags[bag] == null)
                return 0;
            else
                return bags[bag].Aggregate(0, (sum, subBag) => sum + subBag.num + subBag.num * NumContains(subBag.color, bags));
        }
    }
}
