using solveHelpers;

namespace Day_07;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = FileHelper.ReadInputFile(args);
        Dir root = ReadInput(lines);
        
        // Task 1
        root.UpdateTotalSize();
        Console.WriteLine(root.GetSmallerThan(new List<int>(), 100000).Sum());
    }


    static Dir ReadInput(List<string> lines)
    {
        Dir root = new("/", null!);
        Dir currentDir = root;

        for (int i = 1; i < lines.Count; i++)
        {
            if (lines[i].StartsWith("$ cd"))
            {
                string[] split = lines[i].Split(" ");
                if (split[2] == "..")
                {
                    currentDir = currentDir.Parent;
                }
                else
                {
                    Dir newDir = new Dir(split[2], currentDir);
                    currentDir.SubDirs.Add(newDir);
                    currentDir = newDir;
                }
            }

            if (lines[i].StartsWith("$ ls"))
            {
                for (int j = i + 1; j < lines.Count; j++)
                {
                    if (lines[j].StartsWith("$"))
                    {
                        i = j - 1;
                        break;
                    }

                    if (!lines[j].StartsWith("dir"))
                    {
                        currentDir.AddFileSize(Convert.ToInt32(lines[j].Split(" ")[0]));
                    }
                }
            }
        }

        return root;
    }
}

class Dir
{
    public Dir(string name, Dir parent)
    {
        Name = name;
        Parent = parent;
        TotalSize = 0;
        SubDirs = new();
    }

    public List<Dir> SubDirs { get; set; }
    public Dir Parent { get; set; }
    public string Name { get; set; }
    public int TotalSize { get; set; }

    public override string ToString()
    {
        return $"{Name},{TotalSize}";
    }

    public void AddFileSize(int size)
    {
        TotalSize += size;
    }

    public int UpdateTotalSize()
    {
        foreach (Dir subDir in SubDirs)
        {
            TotalSize += subDir.UpdateTotalSize();
        }

        return TotalSize;
    }

    public List<int> GetSmallerThan(List<int> x, int comperator)
    {
        List<int> nums = x;

        foreach (Dir subDir in SubDirs)
        {
            if (subDir.TotalSize <= comperator)
            {
                Console.WriteLine(subDir.TotalSize);
                nums.Add(subDir.TotalSize);
            }

            subDir.GetSmallerThan(nums, comperator);
        }

        return nums;
    }
}