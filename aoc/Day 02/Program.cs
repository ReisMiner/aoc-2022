using System;
using solveHelpers;

namespace Day_02;

class Program
{
    static void Main(string[] args)
    {
        string rock = "A";
        string paper = "B";
        string scissor = "C";

        string winC = "Z";
        string drawC = "Y";
        string loseC = "X";

        const int loseP = 0;
        const int drawP = 3;
        const int winP = 6;
        
        const int rockP = 1;
        const int paperP = 2;
        const int scissorP = 3;
        
        List<string> lines = FileHelper.ReadInputFile(args);

        int points = 0;
        foreach (var line in lines)
        {
            switch (line[2])
            {   
                //lose
                case 'X':
                    points += loseP;
                    if (line[0].ToString() == rock)
                        points += scissorP;
                    else if (line[0].ToString() == paper)
                        points += rockP;
                    else
                        points += paperP;
                    break;
                //draw
                case 'Y': 
                    points += drawP;
                    if (line[0].ToString() == rock)
                        points += rockP;
                    else if (line[0].ToString() == paper)
                        points += paperP;
                    else
                        points += scissorP;
                    break;
                //win
                case 'Z': 
                    points += winP;
                    if (line[0].ToString() == rock)
                        points += paperP;
                    else if (line[0].ToString() == paper)
                        points += scissorP;
                    else
                        points += rockP;
                    break;
            }
        }

        Console.WriteLine(points);
    }

    static void Task1(string[] args)
    {
        string rock = "AX";
        string paper = "BY";
        string scissor = "CZ";
        
        const int loseP = 0;
        const int drawP = 3;
        const int winP = 6;
        
        const int rockP = 1;
        const int paperP = 2;
        const int scissorP = 3;
        
        
        List<string> lines = FileHelper.ReadInputFile(args);

        int points = 0;
        foreach (var line in lines)
        {
            Console.WriteLine(line);
            //rock
            if (rock.Contains(line[2]))
            {
                points += rockP;
                //draw
                if (rock.Contains(line[0]))
                {
                    points += drawP;
                }
                //lose
                else if (paper.Contains(line[0]))
                {
                    points += loseP;
                }
                //win
                else
                {
                    points += winP;
                }
            }
            //paper
            else if (paper.Contains(line[2]))
            {
                points += paperP;
                //lose
                if (rock.Contains(line[0]))
                {
                    points += winP;
                }
                //draw
                else if (paper.Contains(line[0]))
                {
                    points += drawP;
                }
                //win
                else
                {
                    points += loseP;
                }
            }
            //scissors
            else
            {
                points += scissorP;
                //lose
                if (rock.Contains(line[0]))
                {
                    points += loseP;
                }
                //win
                else if (paper.Contains(line[0]))
                {
                    points += winP;
                }
                //draw
                else
                {
                    points += drawP;
                }
            }
        }

        Console.WriteLine(points);
    }
}