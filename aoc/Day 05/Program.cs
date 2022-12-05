using solveHelpers;

namespace Day_05;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);

        //setup list array with correct amount of indexes
        var t = Setup(lines);
        Task1(t);

        foreach (List<string> list in t.containers)
        {
            Console.Write(list[list.Count - 1]);
        }

        Console.WriteLine();
    }

    static void Task1((List<string>[] containers, List<Move> moves) t)
    {
        foreach (Move move in t.moves)
        {
            List<string> target = t.containers[move.ToIndex];
            List<string> source = t.containers[move.FromIndex];
            List<int> toRemove = new();

            for (int i = 0; i < move.Amount; i++)
            {
                int index = source.Count - i - 1;
                toRemove.Add(index);
                target.Add(source[index]);
            }

            toRemove.ForEach(x => source.RemoveAt(x));
        }
    }

    static (List<string>[] containers, List<Move> moves) Setup(List<string> lines)
    {
        List<Move> moves = new();
        int rows = 0;
        foreach (var line in lines)
        {
            int tmp = line.Count(x => x.Equals('['));
            if (line.Contains("move"))
            {
                string[] split = line.Split(" ");
                moves.Add(new Move(split[3], split[5], split[1]));
            }

            rows = tmp != 0 ? tmp : rows;
        }

        List<string>[] containers = new List<string>[rows];
        for (int i = 0; i < rows; i++)
        {
            containers[i] = new List<string>();
        }

        foreach (var line in lines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '[')
                {
                    containers[i / 4].Add(line[i + 1].ToString());
                }
            }
        }

        //reverse cuz else it no make logic
        foreach (List<string> list in containers)
        {
            list.Reverse();
        }

        return (containers, moves);
    }
}

class Move
{
    public int FromIndex { get; set; }
    public int ToIndex { get; set; }
    public int Amount { get; set; }

    public Move(string fromIndex, string toIndex, string amount)
    {
        FromIndex = Convert.ToInt32(fromIndex) - 1;
        ToIndex = Convert.ToInt32(toIndex) - 1;
        Amount = Convert.ToInt32(amount);
    }
}