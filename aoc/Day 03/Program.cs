using System;
using solveHelpers;

namespace Day_03;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);

        //task 1
        List<char> letters = Task1(lines);
        Console.WriteLine(PrioConverter(letters));

        //task 2
        List<char> badges = Task2(lines);
        Console.WriteLine(PrioConverter(badges));
    }

    static List<char> Task1(List<string> lines)
    {
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

        return letters;
    }

    static List<char> Task2(List<string> lines)
    {
        List<char> letters = new();

        for (int i = 0; i < lines.Count; i += 3)
        {
            foreach (var letter in lines[i])
            {
                if (lines[i + 1].Contains(letter))
                {
                    if (lines[i + 2].Contains(letter))
                    {
                        letters.Add(letter);
                        break;
                    }
                }
            }
        }

        return letters;
    }

    static int PrioConverter(List<char> badges)
    {
        int total = 0;
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

        return total;
    }
}