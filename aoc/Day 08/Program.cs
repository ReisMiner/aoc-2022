using solveHelpers;

namespace Day_08;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);
        List<List<int>> grid = Setup(lines);

        // int visibleTrees = Task1(grid);
        // Console.WriteLine(visibleTrees);

        int bestDistance = Task2(grid);
        Console.WriteLine(bestDistance);
    }

    static int Task2(List<List<int>> grid)
    {
        int bestDistance = 0;
        for (int i = 0; i < grid.Count; i++)
        {
            if (i == grid.Count - 1 || i == 0)
            {
                continue;
            }

            for (int j = 0; j < grid[i].Count; j++)
            {
                if (j == grid[i].Count - 1 || j == 0)
                {
                    continue;
                }

                //CHECKING BELOW

                int treeValue = grid[i][j];
                List<int> distances = new() { 0, 0, 0, 0 };
                // check right
                for (int x = j + 1; x < grid[i].Count; x++)
                {
                    if (grid[i][x] >= treeValue)
                    {
                        distances[0]++;
                        break;
                    }

                    if (grid[i][x] < treeValue)
                    {
                        distances[0]++;
                    }
                }

                // check left
                for (int x = j - 1; x >= 0; x--)
                {
                    if (grid[i][x] >= treeValue)
                    {
                        distances[1]++;
                        break;
                    }

                    if (grid[i][x] < treeValue)
                    {
                        distances[1]++;
                    }
                }

                // check up
                for (int y = i - 1; y >= 0; y--)
                {
                    if (grid[y][j] >= treeValue)
                    {
                        distances[2]++;
                        break;
                    }

                    if (grid[y][j] < treeValue)
                    {
                        distances[2]++;
                    }
                }

                // check down
                for (int y = i + 1; y < grid.Count; y++)
                {
                    if (grid[y][j] >= treeValue)
                    {
                        distances[3]++;
                        break;
                    }

                    if (grid[y][j] < treeValue)
                    {
                        distances[3]++;
                    }
                }

                int res = distances[0] * distances[1] * distances[2] * distances[3];

                if (res > bestDistance)
                {
                    bestDistance = res;
                    Console.WriteLine($"new res {res}");
                }
            }
        }

        return bestDistance;
    }

    static int Task1(List<List<int>> grid)
    {
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

                    if (grid[y][j] < treeValue)
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

                    if (grid[y][j] < treeValue)
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

        return visibleTrees;
    }

    static List<List<int>> Setup(List<string> lines)
    {
        List<List<int>> grid = new();
        for (int i = 0; i < lines.Count; i++)
        {
            grid.Add(new List<int>());
            for (int j = 0; j < lines[i].Length; j++)
            {
                grid[i].Add(Convert.ToInt32(lines[i][j].ToString()));
            }
        }

        return grid;
    }
}