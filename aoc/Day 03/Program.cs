using System;
using solveHelpers;

namespace Day_03;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);
        int total = 0;

        List<char> letters = new();

        //grab letters
        foreach (var line in lines)
        {
            string first = line.Substring(0, line.Length / 2);
            string second = line.Substring(line.Length / 2, line.Length / 2);

            foreach (var letter in first)
            {
                if (second.Contains(letter))
                {
                    letters.Add(letter);
                    break;
                }
            }
        }

        foreach (char c in letters)
        {
            int letter = Convert.ToInt32(c);

            if (letter < 96)
            {
                total += letter - 38;
            }
            else
            {
                total += letter - 96;
            }
        }
        Console.WriteLine(total);
    }
}