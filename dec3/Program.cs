using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string inputPathSml = "input_3_sml.txt";
        string inputPath = "input_3.txt";

        string[] lines = File.ReadAllLines(inputPathSml);

        // PrintLines(lines);

        // long sumMaxJoltage = getMaxJoltage(lines);
        // Console.WriteLine($"sumMaxJoltage: {sumMaxJoltage}");

        long sumMaxJoltage2 = getMaxJoltage2(lines);
        Console.WriteLine($"sumMaxJoltage2: {sumMaxJoltage2}");
    }

    static long getMaxJoltage2(string[] lines)
    {
        int maxStackLength = 12;
        long sumMaxJoltage = 0;

        foreach(string line in lines)
        {   
            Stack<char> stack = new Stack<char>();
            Console.WriteLine($"line: {line}");

            foreach(char c in line)
            {
                int count = stack.Count;

                if (count == 0)
                {
                    stack.Push(c);
                    Console.WriteLine("FIRST PUSH!");
                    
                    foreach (char item in stack)
                    {
                        Console.Write(item + " ");
                    }

                } 
                else
                {
                    char peekValue = stack.Peek();
                    Console.WriteLine($"peakValue: {peekValue}");

                    if (c > peekValue)
                    {
                        stack.Pop();
                        stack.Push(c);
                    }
                    else
                    {
                        if (count < maxStackLength)
                        {
                            stack.Push(c);
                        } else
                        {
                            if (c > peekValue)
                            {
                                stack.Pop();
                                stack.Push(c);
                            }
                        }
                    }

                    Console.WriteLine("Printing stack");
                    foreach (char item in stack)
                    {
                        Console.Write(item + " ");
                    }
                }
            }
        }

        return sumMaxJoltage;
    }

    static long getMaxJoltage(string[] lines)
    {
        long sumMaxJoltage = 0;

        foreach(string line in lines)
        {
            int maxJoltage = 0;
            Console.WriteLine($"line: {line}");
            int lMax = 0;

            for (int i=0; i<line.Length-1; i++)
            {
                int rMax = 0;
                char c = line[i];
                int joltage = int.Parse(c.ToString());
                // Console.WriteLine($"joltage: {joltage}");

                lMax = Math.Max(lMax, joltage);

                for (int j=i+1; j<line.Length; j++)
                {
                    char innerC = line[j];
                    int innerJoltage = int.Parse(innerC.ToString());
                    rMax = Math.Max(rMax, innerJoltage);
                }
                // Console.WriteLine($"lmax, rmax: {lMax}, {rMax}");
                string maxString = lMax.ToString() + rMax.ToString();
                // Console.WriteLine($"maxString: {maxString}");
                maxJoltage = Math.Max(maxJoltage, int.Parse(maxString));
            }
            Console.WriteLine($"maxJoltage: {maxJoltage}");
            sumMaxJoltage += maxJoltage;
        }

        return sumMaxJoltage;
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