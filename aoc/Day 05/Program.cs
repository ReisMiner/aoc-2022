using solveHelpers;

namespace Day_05;

class Program
{
    static void Main(string[] args)
    {
        List<Move> moves = new();
        List<string> lines = FileHelper.ReadInputFile(args);

        //setup list array with correct amount of indexes
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

        //initialize lists
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

        //do moves
        foreach (Move move in moves)
        {
            List<string> target = containers[move.ToIndex];
            List<string> source = containers[move.FromIndex];
            List<int> toRemove = new();

            for (int i = 0; i < move.Amount; i++)
            {
                int index = source.Count - i - 1;
                toRemove.Add(index);
                target.Add(source[index]);
            }

            toRemove.ForEach(x => source.RemoveAt(x));
        }

        foreach (List<string> list in containers)
        {
            Console.Write(list[list.Count - 1]);
        }

        Console.WriteLine();
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