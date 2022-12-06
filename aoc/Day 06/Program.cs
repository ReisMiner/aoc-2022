using System;
using solveHelpers;

namespace Day_06;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);
        
        List<Char> letters = new();

        string line = lines[0];
        int startSize = 14;
        
        for (int i = 0; i < line.Length; i++)
        {
            letters.Add(line[i]);
            if (i >= startSize)
            {
                letters.RemoveAt(0);
            }

            if (letters.Count >= startSize)
            {
                if (letters.Distinct().Count() == startSize)
                {
                    Console.WriteLine(i+1);
                    break;
                }
            }
        }
    }
}