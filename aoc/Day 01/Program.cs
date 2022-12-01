﻿using System;
using solveHelpers;

namespace Day_01;

class Program
{
    static void Main(string[] args)
    {
        string path = "../../../input.txt";
        if (args.Length == 1)
            path = args[0];
        List<string> lines = FileHelper.ReadFile(path);

        int max = 0, current = 0;

        foreach (var line in lines)
        {
            if (line == "")
            {
                if (current > max)
                    max = current;
                current = 0;
            }
            else
            {
                current += Convert.ToInt32(line);
            }
        }

        Console.WriteLine(max);
    }
}