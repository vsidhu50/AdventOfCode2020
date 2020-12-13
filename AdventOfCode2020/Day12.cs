using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day12
    {
        public Day12()
        {
        }

        public static int PartOne()
        {
            var lines = Utilities.GetInputLines(12);

            var instructions = new List<(char action, int num)>();

            foreach (var line in lines)
            {
                var pattern = @"(\w)(\d+)";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                var match = regex.Match(line);
                var direction = Char.Parse(match.Groups[1].ToString());
                var distance = Int32.Parse(match.Groups[2].ToString());
                instructions.Add((direction, distance));
            }

            var (x, y) = (0, 0);
            var currDir = 0;

            foreach (var (action, num) in instructions)
            {
                switch (action)
                {
                    case 'N':
                        y += num;
                        break;
                    case 'S':
                        y -= num;
                        break;
                    case 'E':
                        x += num;
                        break;
                    case 'W':
                        x -= num;
                        break;
                    case 'L':
                        currDir += num;
                        currDir %= 360;
                        break;
                    case 'R':
                        currDir -= num;
                        currDir %= 360;
                        break;
                    case 'F':
                        if (currDir == 90 || currDir == -270)
                                y += num;
                        else if (currDir == -90 || currDir == 270)
                            y -= num;
                        else if (currDir == 0)
                            x += num;
                        else if (currDir == 180 || currDir == -180)
                            x -= num;
                        break;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        public static int PartTwo()
        {
            var lines = Utilities.GetInputLines(12);
            var instructions = new List<(char action, int num)>();

            foreach (var line in lines)
            {
                var pattern = @"(\w)(\d+)";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                var match = regex.Match(line);
                var direction = Char.Parse(match.Groups[1].ToString());
                var distance = Int32.Parse(match.Groups[2].ToString());

                instructions.Add((direction, distance));
            }

            var (x, y) = (0, 0);
            var (wayX, wayY) = (10, 1);

            foreach (var (action, num) in instructions)
            {
                switch (action)
                {
                    case 'N':
                        wayY += num;
                        break;
                    case 'S':
                        wayY -= num;
                        break;
                    case 'E':
                        wayX += num;
                        break;
                    case 'W':
                        wayX -= num;
                        break;
                    case 'L':
                        var dirL = num % 360;

                        if (dirL == 270)
                        {
                            var temp = wayY;
                            wayY = -wayX;
                            wayX = temp;
                        }
                        else if (dirL == 180)
                        {
                            wayY *= -1;
                            wayX *= -1;
                        }
                        else if (dirL == 90)
                        {
                            var temp = wayY;
                            wayY = wayX;
                            wayX = -temp;
                        }
                        break;
                    case 'R':
                        var dirR = num % 360;

                        if (dirR == 90)
                        {
                            var temp = wayY;
                            wayY = -wayX;
                            wayX = temp;
                        }
                        else if (dirR == 180)
                        {
                            wayY *= -1;
                            wayX *= -1;
                        }
                        else if (dirR == 270)
                        {
                            var temp = wayY;
                            wayY = wayX;
                            wayX = -temp;
                        }
                        break;
                    case 'F':
                        x += wayX * num;
                        y += wayY * num;
                        break;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        
    }

}
