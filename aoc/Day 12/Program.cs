using solveHelpers;

namespace Day_12;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);

        foreach (string line in lines)
        {
            Console.WriteLine();
            foreach (char c in line)
            {
                Console.Write(c + ",");
            }
        }
    }
}