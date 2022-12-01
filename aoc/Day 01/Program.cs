using System;
using solveHelpers;

namespace Day_01;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);
        const int getTopCount = 3;

        List<int> maxes = new();
        int current = 0;
        
        foreach (var line in lines)
        {
            if (line == "")
            {
                maxes.Add(current);
                current = 0;
            }
            else
            {
                current += Convert.ToInt32(line);
            }
        }
        
        maxes.Sort();
        maxes.Reverse();

        int total = 0;
        for (int i = 0; i < getTopCount; i++)
        {
            total += maxes[i];
        }
        Console.WriteLine(total);
    }
    
    
}