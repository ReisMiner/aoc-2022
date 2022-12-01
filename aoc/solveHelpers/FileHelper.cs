using System.Text;

namespace solveHelpers;

public class FileHelper
{
    /// <summary>
    /// Read A File and Return all Lines in a List
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static List<String> ReadFile(string path)
    {
        return File.ReadAllLines(path, Encoding.UTF8).ToList();
    }
}