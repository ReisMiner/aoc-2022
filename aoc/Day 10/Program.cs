using System;
using solveHelpers;

namespace Day_10;

class Program
{
    static int _cycle = 1;

    static int Cycle
    {
        get => _cycle;
        set
        {
            if ((_cycle - 20) % 40 == 0)
            {
                int val = RegisterX * _cycle;
                Console.WriteLine($"Add Signal {val}, cycle = {_cycle}, registerX = {RegisterX}");
                SignalStrengths.Add(val);
            }
            _cycle = value;
        }
    }

    static List<int> SignalStrengths { get; set; }

    static int RegisterX { get; set; } = 1;

    static void Main(string[] args)
    {
        SignalStrengths = new List<int>();
        List<string> lines = FileHelper.ReadInputFile(args);

        foreach (string line in lines)
        {
            string[] split = line.Split(" ");

            Cycle++;
            switch (split[0])
            {
                case "addx":
                    Cycle++;
                    RegisterX += Convert.ToInt32(split[1]);
                    break;
                case "noop": break;
            }
        }

        Console.WriteLine(SignalStrengths.Sum());
    }
}