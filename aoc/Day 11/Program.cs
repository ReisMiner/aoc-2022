using System;
using solveHelpers;

namespace Day_11;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);
        List<Monkeh> monkehs = Parse(lines);
        int numberOfTurns = 20;

        for (int i = 0; i < numberOfTurns; i++)
        {
            foreach (Monkeh monkeh in monkehs)
            {
                List<long> toRemove = new();
                for (int m = 0; m < monkeh.Items.Count; m++)
                {
                    monkeh.InspectCount++;
                    string[] split = monkeh.Operation.Split(" ");
                    switch (split[1])
                    {
                        case "+":
                            monkeh.Items[m] += Convert.ToInt32(split[2]);
                            break;
                        case "*":
                            if (split[2] == "old")
                                monkeh.Items[m] *= monkeh.Items[m];
                            else
                                monkeh.Items[m] *= Convert.ToInt32(split[2]);
                            break;
                    }

                    monkeh.Items[m] /= 3;
                    if (monkeh.Items[m] % monkeh.TestNum == 0)
                    {
                        monkehs[monkeh.TestPass].Items.Add(monkeh.Items[m]);
                    }
                    else
                    {
                        monkehs[monkeh.TestFail].Items.Add(monkeh.Items[m]);
                    }

                    toRemove.Add(monkeh.Items[m]);
                }

                foreach (var i1 in toRemove)
                {
                    monkeh.Items.Remove(i1);
                }
            }
        }

        var sortedList = monkehs.OrderBy(m => m.InspectCount).ToList();
        sortedList.Reverse();
        sortedList.ForEach(Console.WriteLine);
        Console.WriteLine(sortedList[0].InspectCount * sortedList[1].InspectCount);
    }

    static List<Monkeh> Parse(List<string> lines)
    {
        List<Monkeh> monkehs = new();
        for (int i = 0; i < lines.Count; i++)
        {
            // line 0
            Monkeh temp = new Monkeh();

            //line 1
            i++;
            lines[i].Split(":")[1].Split(", ").ToList().ForEach(x => temp.Items.Add(Convert.ToInt32(x)));

            //line 2
            i++;
            temp.Operation = lines[i].Split("= ")[1];

            //line 3
            i++;
            temp.TestNum = Convert.ToInt32(lines[i].Split("by ")[1]);

            //line 4
            i++;
            temp.TestPass = int.Parse(lines[i].Split("monkey ")[1]);

            //line 5
            i++;
            temp.TestFail = int.Parse(lines[i].Split("monkey ")[1]);

            //line 6
            i++;
            monkehs.Add(temp);
        }

        return monkehs;
    }
}

class Monkeh
{
    public List<long> Items { get; set; }
    public string Operation { get; set; }
    public int TestFail { get; set; }
    public int TestPass { get; set; }
    public int TestNum { get; set; }
    public long InspectCount { get; set; } = 0;

    public Monkeh()
    {
        Items = new List<long>();
    }

    public override string ToString()
    {
        string x = "";
        Items.ForEach((i => x += $"{i},"));
        return $"Items: {x} Operation: {Operation}, TestNum: {TestNum}, TestPass: {TestPass}, TestFail: {TestFail}, Inspections: {InspectCount}";
    }
}