using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day11
    {
        public Day11()
        {
        }

        public static int PartOne()
        {
            var rows = Utilities.GetInputLines(11);
            var numRows = rows.Count;
            var numCols = rows[0].Length;

            var grid = new char[numRows, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    grid[i, j] = rows[i][j];
                }
            }

            var oldGrid = grid;
            var newGrid = grid;

            do
            {
                var temp = newGrid;
                newGrid = ApplyRulesOne(newGrid);
                oldGrid = temp;
            } while (!Same(oldGrid, newGrid));

            var total = 0;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (newGrid[i, j] == '#')
                        total++;
                }
            }

            return total;
        }

        public static int PartTwo()
        {
            var rows = Utilities.GetInputLines(11);
            var numRows = rows.Count;
            var numCols = rows[0].Length;

            var grid = new char[numRows, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    grid[i, j] = rows[i][j];
                }
            }

            var oldGrid = grid;
            var newGrid = grid;

            do
            {
                var temp = newGrid;
                newGrid = ApplyRulesTwo(newGrid);
                oldGrid = temp;
            } while (!Same(oldGrid, newGrid));

            var total = 0;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (newGrid[i, j] == '#')
                        total++;
                }
            }


            return total;
        }

        private static char[,] ApplyRulesOne(char [,] grid)
        {
            var numRows = grid.GetLength(0);
            var numCols = grid.GetLength(1);

            var newGrid = new char[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (grid[i, j] == 'L' && NumAdjacent(i, j, grid) == 0)
                        newGrid[i, j] = '#';
                    else if (grid[i, j] == '#' && NumAdjacent(i, j, grid) >= 4)
                        newGrid[i, j] = 'L';
                    else
                        newGrid[i, j] = grid[i, j];
                }
            }

            return newGrid;
        }

        private static char[,] ApplyRulesTwo(char[,] grid)
        {
            var numRows = grid.GetLength(0);
            var numCols = grid.GetLength(1);

            var newGrid = new char[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (grid[i, j] == 'L' && NumVisible(i, j, grid) == 0)
                        newGrid[i, j] = '#';
                    else if (grid[i, j] == '#' && NumVisible(i, j, grid) >= 5)
                        newGrid[i, j] = 'L';
                    else
                        newGrid[i, j] = grid[i, j];
                }
            }

            return newGrid;
        }

        private static bool Same(char[,] oldArr, char[,] newArr)
        {
            var numRows = oldArr.GetLength(0);
            var numCols = oldArr.GetLength(1);

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (oldArr[i, j] != newArr[i, j])
                        return false;
                }
            }

            return true;
        }

        private static int NumAdjacent(int row, int col, char[,] grid)
        {
            int adjacent = 0;
            var numRows = grid.GetLength(0);
            var numCols = grid.GetLength(1);

            // SE
            if (row + 1 < numRows && col + 1 < numCols && grid[row + 1, col + 1] == '#')
                adjacent++;
            // E
            if (col + 1 < numCols && grid[row, col + 1] == '#')
                adjacent++;
            // NE
            if (row - 1 > -1 && col + 1 < numCols && grid[row - 1, col + 1] == '#')
                adjacent++;
            // N
            if (row - 1 > -1 && grid[row - 1, col] == '#')
                adjacent++;
            // NW
            if (row - 1 > -1 && col - 1 > -1 && grid[row - 1, col - 1] == '#')
                adjacent++;
            // W
            if (col - 1 > -1 && grid[row, col - 1] == '#')
                adjacent++;
            // SW
            if (row + 1 < numRows && col - 1 > -1 && grid[row + 1, col - 1] == '#')
                adjacent++;
            // S
            if (row + 1 < numRows && grid[row + 1, col] == '#')
                adjacent++;

            return adjacent;
        }

        private static int NumVisible(int row, int col, char[,] grid)
        {
            var numRows = grid.GetLength(0);
            var numCols = grid.GetLength(1);

            var directions = new List<string>() { "se", "e", "ne", "n", "nw", "w", "sw", "s" };
            var occupied = directions.Select(k => new { k, v = 0 }).ToDictionary(x => x.k, x => x.v);

            // SE
            for (int i = row + 1, j = col + 1; i < numRows && j < numCols && occupied["se"] == 0; i++, j++)
            {
                if (grid[i, j] == '#')
                    occupied["se"] = 2;
                else if (grid[i, j] == 'L')
                    occupied["se"] = 1;
            }

            // E
            for (int j = col + 1; j < numCols && occupied["e"] == 0; j++)
            {
                if (grid[row, j] == '#')
                    occupied["e"] = 2;
                else if (grid[row, j] == 'L')
                    occupied["e"] = 1;
            }

            // NE
            for (int i = row - 1, j = col + 1; i > -1 && j < numCols && occupied["ne"] == 0; i--, j++)
            {
                if (grid[i, j] == '#')
                    occupied["ne"] = 2;
                else if (grid[i, j] == 'L')
                    occupied["ne"] = 1;
            }

            // N
            for (int i = row - 1; i > -1 && occupied["n"] == 0; i--)
            {
                if (grid[i, col] == '#')
                    occupied["n"] = 2;
                else if (grid[i, col] == 'L')
                    occupied["n"] = 1;
            }

            // NW
            for (int i = row - 1, j = col - 1; i > -1 && j > -1 && occupied["nw"] == 0; i--, j--)
            {
                if (grid[i, j] == '#')
                    occupied["nw"] = 2;
                else if (grid[i, j] == 'L')
                    occupied["nw"] = 1;
            }

            // W
            for (int j = col - 1; j > -1 && occupied["w"] == 0; j--)
            {
                if (grid[row, j] == '#')
                    occupied["w"] = 2;
                else if (grid[row, j] == 'L')
                    occupied["w"] = 1;
            }

            // SW
            for (int i = row + 1, j = col - 1; i < numRows && j > -1 && occupied["sw"] == 0; i++, j--)
            {
                if (grid[i, j] == '#')
                    occupied["sw"] = 2;
                else if (grid[i, j] == 'L')
                    occupied["sw"] = 1;
            }

            // S
            for (int i = row + 1; i < numRows && occupied["s"] == 0; i++)
            {
                if (grid[i, col] == '#')
                    occupied["s"] = 2;
                else if (grid[i, col] == 'L')
                    occupied["s"] = 1;
            }

            return occupied.Where(x => x.Value == 2).Count();
        }

    }
}
