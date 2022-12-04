using System;
using solveHelpers;

namespace Day_04;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);
        List<Range> ranges = RangeSetup(lines);
        Console.WriteLine(Task1(ranges));
        Console.WriteLine(Task2(ranges));
    }

    static int Task1(List<Range> ranges)
    {
        int points = 0;
        for (int i = 0; i < ranges.Count; i += 2)
        {
            if (ranges[i].Start <= ranges[i + 1].Start && ranges[i].End >= ranges[i + 1].End)
            {
                points++;
            }
            else if (ranges[i + 1].Start <= ranges[i].Start && ranges[i + 1].End >= ranges[i].End)
            {
                points++;
            }
        }

        return points;
    }

    static int Task2(List<Range> ranges)
    {
        int points = 0;
        for (int i = 0; i < ranges.Count; i += 2)
        {
            if (ranges[i + 1].Start <= ranges[i].End && ranges[i + 1].Start >= ranges[i].Start)
            {
                points++;
            }
            else if (ranges[i].Start <= ranges[i+1].End && ranges[i].Start >= ranges[i+1].Start)
            {
                points++;
            }
        }

        return points;
    }

    static List<Range> RangeSetup(List<string> lines)
    {
        List<Range> ranges = new();
        foreach (var line in lines)
        {
            string[] twoRanges = line.Split(",");
            ranges.Add(new Range(twoRanges[0]));
            ranges.Add(new Range(twoRanges[1]));
        }

        return ranges;
    }
}

class Range
{
    public int Start { get; set; }
    public int End { get; set; }

    public Range(string oneRange)
    {
        string[] split = oneRange.Split("-");
        Start = Convert.ToInt32(split[0]);
        End = Convert.ToInt32(split[1]);
    }
}