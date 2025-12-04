class Program{
    static void Main(string[] args)
    {
        string inputPathSml = "input_2_sml.txt";
        string inputPath = "input_2.txt";

        string[] lines = File.ReadAllLines(inputPath);

        // PrintLines(lines);
        
        string[] ranges = lines[0].Split(',');
        Console.WriteLine($"length of ranges: {ranges.Length}");
        Console.WriteLine($"ranges: {string.Join(", ", ranges)}");

        // long invalidSum = GetInvalidSum(ranges);
        // Console.WriteLine($"invalidSum: {invalidSum}");

        long invalidSum2 = GetInvalidSum2(ranges);
        Console.WriteLine($"invalidSum2: {invalidSum2}");
    }

    static long GetInvalidSum2(string[] ranges)
    {
        long invalidSum = 0;
        List<long> invalidList = new List<long>();

        foreach(string range in ranges)
        {
            long lowerBound = long.Parse(range.Split('-')[0]);
            long upperBound = long.Parse(range.Split('-')[1]);

            // Console.WriteLine($"lower, upperBound: {lowerBound}, {upperBound}");
            

            for (long i=lowerBound; i <= upperBound; i++)
            {
                int l = 0;
                int r = 1;
                
                string id = i.ToString();
                Console.WriteLine($"id: {id}");
                int idLength = id.Length;
                int halfLength = idLength / 2;
                

                while (r <= halfLength)
                {
                    string group = id.Substring(l,r);
                    // Console.WriteLine($"group: {group}");
                    int groupLength = group.Length;
                    // Console.WriteLine($"groupLength: {groupLength}");

                    int parts = (int)Math.Ceiling((double)idLength / groupLength);
                    // Console.WriteLine($"parts: {parts}");

                    int index = 0;
                    List<string> compareList = new List<string>();

                    for (int p=0; p<parts; p++)
                    {
                        try{
                            compareList.Add(id.Substring(index, groupLength));
                        }
                        catch
                        {
                            compareList.Add("0");
                        }
                        index += groupLength;
                    }

                    if (compareList.Count < 2)
                    {
                        break;
                    }

                    bool allEqual = compareList.All(s => s==group);
                    if (allEqual)
                    {
                        Console.WriteLine($"ALL EQUAL in id for group: {id}, {group}");
                        // foreach(string comp in compareList)
                        // {
                        //     Console.WriteLine(comp);
                        // }
                        if (!invalidList.Contains(long.Parse(id)))
                        {
                            invalidList.Add(long.Parse(id));
                        }
                    }
                    r ++;
                }
            }
        }

        foreach(long id in invalidList)
        {
            Console.WriteLine(id);
            invalidSum += id;
        }
        return invalidSum;
    }

    static long GetInvalidSum(string[] ranges)
    {
        long invalidSum = 0;

        foreach(string range in ranges)
        {
            long lowerBound = long.Parse(range.Split('-')[0]);
            long upperBound = long.Parse(range.Split('-')[1]);

            // Console.WriteLine($"lower, upperBound: {lowerBound}, {upperBound}");

            for (long i=lowerBound; i <= upperBound; i++)
            {
                // Console.WriteLine(i);
                int idLength = i.ToString().Length;
                // Console.WriteLine($"idLength: {idLength}");

                if (idLength%2 != 0)
                {
                    continue;
                }
                else
                {
                    int halfLength = idLength / 2;
                    string firstHalf = i.ToString().Substring(0,halfLength);
                    string secondHalf = i.ToString().Substring(halfLength);
                    // Console.WriteLine($"halfLength, firstHalf, secondHalf: {halfLength}, {firstHalf}, {secondHalf}");

                    if (long.Parse(firstHalf) == long.Parse(secondHalf))
                    {
                        Console.WriteLine($"Invalid ID: {i}");
                        invalidSum += i;
                    }
                }
            }
        }

        return invalidSum;
    }

    static void PrintLines(string[] lines)
    {
        Console.WriteLine($"length of lines: {lines.Length}");

        foreach(var line in lines)
        {
            Console.WriteLine(line);
        }
    }
}