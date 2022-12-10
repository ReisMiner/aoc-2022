using solveHelpers;

namespace Day_09;

class Program
{
    static void Main(string[] args)
    {
        int size = 1000;
        List<string> lines = FileHelper.ReadInputFile(args);
        List<List<bool>> grid = GenerateGrid(size);

        Cursor current = new Cursor(size/2, size/2);
        Cursor prev = new Cursor(size/2, size/2);
        Cursor rope = new Cursor(size/2, size/2);

        grid[size/2][size/2] = true;

        foreach (string line in lines)
        {
            string[] split = line.Split(" ");
            switch (split[0])
            {
                case "R":
                    for (int i = 0; i < Convert.ToInt32(split[1]); i++)
                    {
                        prev.SetValues(current);
                        current.X++;
                        UpdateGrid(grid, current, prev, rope);
                    }

                    break;
                case "L":
                    for (int i = 0; i < Convert.ToInt32(split[1]); i++)
                    {
                        prev.SetValues(current);
                        current.X--;
                        UpdateGrid(grid, current, prev, rope);
                    }

                    break;
                case "U":
                    for (int i = 0; i < Convert.ToInt32(split[1]); i++)
                    {
                        prev.SetValues(current);
                        current.Y++;
                        UpdateGrid(grid, current, prev, rope);
                    }

                    break;
                case "D":
                    for (int i = 0; i < Convert.ToInt32(split[1]); i++)
                    {
                        prev.SetValues(current);
                        current.Y--;
                        UpdateGrid(grid, current, prev, rope);
                    }

                    break;
            }
        }

        int points = 0;
        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid[i].Count; j++)
            {
                if (grid[i][j])
                {
                    points++;
                }
            }
        }

        Console.WriteLine(points);
    }

    static void UpdateGrid(List<List<bool>> grid, Cursor current, Cursor prev, Cursor rope)
    {
        if (IsDetached(current, rope))
        {
            rope.SetValues(prev);
            grid[rope.X][rope.Y] = true;
        }
    }

    static List<List<bool>> GenerateGrid(int size)
    {
        List<List<bool>> grid = new();

        for (int i = 0; i < size; i++)
        {
            grid.Add(new List<bool>());
            for (int j = 0; j < size; j++)
            {
                grid[i].Add(false);
            }
        }

        return grid;
    }

    static bool IsDetached(Cursor current, Cursor rope)
    {
        if (new Cursor(current.X - 1, current.Y + 1).Equals(rope) ||
            new Cursor(current.X, current.Y + 1).Equals(rope) ||
            new Cursor(current.X + 1, current.Y + 1).Equals(rope) ||
            new Cursor(current.X + 1, current.Y).Equals(rope) ||
            new Cursor(current.X + 1, current.Y - 1).Equals(rope) ||
            new Cursor(current.X, current.Y - 1).Equals(rope) ||
            new Cursor(current.X - 1, current.Y - 1).Equals(rope) ||
            new Cursor(current.X - 1, current.Y).Equals(rope) ||
            current.Equals(rope)
           )
        {
            return false;
        }
        return true;
    }
}

class Cursor
{
    public Cursor(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj?.GetType() != typeof(Cursor))
            return false;

        if (obj is Cursor c && c.X == X && c.Y == Y)
        {
            Console.WriteLine($"{obj as Cursor} is equal to {this}");
            return true;
            
        }
        return false;
    }

    protected bool Equals(Cursor other)
    {
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override string ToString()
    {
        return $"{X}, {Y}";
    }

    public void SetValues(Cursor c)
    {
        this.X = c.X;
        this.Y = c.Y;
    }
}