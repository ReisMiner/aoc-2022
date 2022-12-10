using System;
using solveHelpers;

namespace Day_10;

class Program
{
    static int _modifier;
    static int _cycle = 1;

    static int Cycle
    {
        get => _cycle;
        set
        {
            if ((_cycle - 20) % 40 == 0)
            {
                int val = RegisterX * _cycle;
                SignalStrengths.Add(val);
            }

            if ((_cycle - 1) % 40 == 0 && _cycle - 1 != 0)
            {
                Console.WriteLine("");
                _modifier += 40;
            }


            if (RegisterX - 1 == _cycle - 1 - _modifier)
            {
                Console.Write("#");
            }
            else if (RegisterX == _cycle - 1 - _modifier)
            {
                Console.Write("#");
            }
            else if (RegisterX + 1 == _cycle - 1 - _modifier)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(".");
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