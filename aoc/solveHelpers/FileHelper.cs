using System.Text;

namespace solveHelpers;

public class FileHelper
{
    /// <summary>
    /// Read A File and Return all Lines in a List
    /// </summary>
    /// <param name="args">program run arguments</param>
    /// <returns></returns>
    public static List<String> ReadInputFile(string[] args)
    {
        string path = "../../../input.txt";
        if (args.Length == 1)
            path = args[0];
        return File.ReadAllLines(path, Encoding.UTF8).ToList();
    }
}