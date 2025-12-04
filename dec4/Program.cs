class Program
{
    static void Main(string[] args)
    {
        string inputPathSml = "input_4_sml.txt";
        string inputPath = "input_4.txt";

        string[] lines = File.ReadAllLines(inputPath);

        // PrintLines(lines);

        // int validRolls = getValidRolls(lines);
        // Console.WriteLine($"Valid rolls: {validRolls}");

        int removedRolls = getRemovedRolls(lines);
        Console.WriteLine($"removedRolls: {removedRolls}");
    }

    static int getRemovedRolls(string[] lines)
    {
        int removedRolls = 0;
        int rows = lines.Length;
        int cols = lines[0].Length;
        var grid = lines.Select(s => s.ToCharArray()).ToArray();
        Console.WriteLine($"rows, cols: {rows}, {cols}");

        var directions = new (int, int)[]
        {
            (-1, 1), (0, 1), (1, 1),
            (-1, 0), (1, 0),
            (-1, -1), (0, -1), (1, -1)
        };

        bool stopFlag = false;

        while (!stopFlag){
            int validRolls = 0;

            for (int r=0; r<rows; r++)
            {
                for (int c=0; c<cols; c++)
                {
                    char item = grid[r][c];
                    // Console.WriteLine($"item: {item}");

                    if (item == '.' || item == 'x')
                    {
                        continue;
                    }
                    else
                    {
                        // Console.WriteLine($"item: {item}");
                        int counter = 0;
                        foreach (var (dx, dy) in directions)
                        {
                            int newR = r + dx;
                            int newC = c + dy;

                            if (newR >= rows || newR < 0 || newC >= cols || newC < 0)
                            {
                                continue;
                            }
                            else
                            {
                                if (grid[newR][newC] == '@')
                                {
                                    counter ++;
                                }
                            }
                        }
                        if (counter < 4)
                        {
                            validRolls++;
                            Console.WriteLine($"Count of validRolls: {validRolls}");
                            grid[r][c] = 'x';
                            removedRolls++;
                            Console.WriteLine($"Count of removedRolls: {removedRolls}");
                        } 
                    }
                }
            }

            if (validRolls == 0)
            {
                stopFlag = true;
            }
        }

        return removedRolls;

    }

    static int getValidRolls(string[] lines)
    {
        int validRolls = 0;
        int rows = lines.Length;
        int cols = lines[0].Length;

        Console.WriteLine($"rows, cols: {rows}, {cols}");

        var directions = new (int, int)[]
        {
            (-1, 1), (0, 1), (1, 1),
            (-1, 0), (1, 0),
            (-1, -1), (0, -1), (1, -1)
        };

        for (int r=0; r<rows; r++)
        {
            for (int c=0; c<cols; c++)
            {
                char item = lines[r][c];
                // Console.WriteLine($"item: {item}");

                if (item == '.')
                {
                    continue;
                }
                else
                {
                    // Console.WriteLine($"item: {item}");
                    int counter = 0;
                    foreach (var (dx, dy) in directions)
                    {
                        int newR = r + dx;
                        int newC = c + dy;

                        if (newR >= rows || newR < 0 || newC >= cols || newC < 0)
                        {
                            continue;
                        }
                        else
                        {
                            if (lines[newR][newC] == '@')
                            {
                                counter ++;
                            }
                        }
                    }
                    if (counter < 4)
                    {
                        validRolls++;
                    }
                }
            }
        }

        return validRolls;
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