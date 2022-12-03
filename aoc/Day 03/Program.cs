using System;
using solveHelpers;

namespace Day_03;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);
        int total = 0;

        List<char> badges = new();

        int count = 0;

        for (int i = 0; i < lines.Count; i += 3)
        {
            foreach (var letter in lines[i])
            {
                if (lines[i + 1].Contains(letter))
                {
                    if (lines[i + 2].Contains(letter))
                    {
                        badges.Add(letter);
                        break;
                    }
                }
            }
        }
        
        foreach (char c in badges)
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

    static void Task1(string[] args)
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