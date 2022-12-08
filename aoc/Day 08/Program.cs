using solveHelpers;

namespace Day_08;

//1791 too low
//1812 too low

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);
        List<List<int>> grid = new();

        for (int i = 0; i < lines.Count; i++)
        {
            grid.Add(new List<int>());
            for (int j = 0; j < lines[i].Length; j++)
            {
                grid[i].Add(Convert.ToInt32(lines[i][j].ToString()));
            }
        }

        int visibleTrees = 0;
        for (int i = 0; i < grid.Count; i++)
        {
            if (i == grid.Count - 1 || i == 0)
            {
                visibleTrees += grid[i].Count;
                Console.WriteLine($"top/bottom add {grid[i].Count}");
                continue;
            }

            for (int j = 0; j < grid[i].Count; j++)
            {
                if (j == grid[i].Count - 1 || j == 0)
                {
                    visibleTrees++;
                    Console.WriteLine($"edge add row {i + 1} treeNr {j + 1} treeval {grid[i][j]}");
                    continue;
                }

                //CHECKING BELOW

                int treeValue = grid[i][j];
                bool isVisible = false;
                // check right
                for (int x = j + 1; x < grid[i].Count; x++)
                {
                    if (grid[i][x] >= treeValue)
                    {
                        isVisible = false;
                        break;
                    }

                    if (grid[i][x] < treeValue)
                    {
                        isVisible = true;
                    }
                }

                if (isVisible)
                {
                    visibleTrees++;
                    Console.WriteLine($"right | row {i + 1} treeNr {j + 1} treeval {treeValue}");
                    continue;
                }

                // check left
                for (int x = j - 1; x >= 0; x--)
                {
                    if (grid[i][x] >= treeValue)
                    {
                        isVisible = false;
                        break;
                    }

                    if (grid[i][x] < treeValue)
                    {
                        isVisible = true;
                    }
                }

                if (isVisible)
                {
                    visibleTrees++;
                    Console.WriteLine($"left | row {i + 1} treeNr {j + 1} treeval {treeValue}");
                    continue;
                }

                // check up
                for (int y = i - 1; y >= 0; y--)
                {
                    if (grid[y][j] >= treeValue)
                    {
                        isVisible = false;
                        break;
                    }

                    if (grid[y][i] < treeValue)
                    {
                        isVisible = true;
                    }
                }

                if (isVisible)
                {
                    visibleTrees++;
                    Console.WriteLine($"up | row {i + 1} treeNr {j + 1} treeval {treeValue}");
                    continue;
                }

                // check down
                for (int y = i + 1; y < grid.Count; y++)
                {
                    if (grid[y][j] >= treeValue)
                    {
                        isVisible = false;
                        break;
                    }

                    if (grid[y][i] < treeValue)
                    {
                        isVisible = true;
                    }
                }

                if (isVisible)
                {
                    Console.WriteLine($"down | row {i + 1} treeNr {j + 1} treeval {treeValue}");
                    visibleTrees++;
                }
            }
        }

        Console.WriteLine(visibleTrees);
    }
}