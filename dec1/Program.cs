class Program
{
    static void Main(string[] args)
    {
        string inputPathSml = "input_1_sml.txt";
        string inputPath = "input_1.txt";

        string[] lines = File.ReadAllLines(inputPath);

        // PrintLines(lines);

        int numZero = FindNumZero(lines);

        Console.WriteLine($"num zeros: {numZero}");
    }

    static int FindNumZero(string[] lines)
    {
        int currentPos = 50;
        int numZero = 0;
        int counter = 0;

        foreach(var line in lines)
        {
            string direction = line.Substring(0, 1);
            
            int turnAmount = int.Parse(line.Substring(1));
            if (turnAmount > 100)
            {
                Console.WriteLine($"turnAmount: {turnAmount}");

                int rem = turnAmount/100;
                numZero += rem;
                
                turnAmount = turnAmount%100;
                
                Console.WriteLine($"rem: {rem}");
                Console.WriteLine($"num zeros: {numZero}");
            }

            Console.WriteLine($"line: {line}");

            if (direction == "L")
            {
                int newPos = currentPos - turnAmount;
                Console.WriteLine($"newPos: {newPos}");

                if (newPos < 0)
                {
                    if (currentPos != 0)
                    {
                        numZero += 1;
                    }
                    Console.WriteLine($"num zeros: {numZero}");

                    currentPos = currentPos - turnAmount + 100;
                }
                else
                {
                    currentPos = currentPos - turnAmount;
                }
                Console.WriteLine($"currentPos: {currentPos}");
            }
            else if (direction == "R")
            {
                int newPos = currentPos + turnAmount;

                if (newPos == 100)
                {
                    currentPos = 0;
                }
                else if(newPos > 100)
                {
                    if (currentPos != 0)
                    {
                        numZero += 1;
                    }
                    Console.WriteLine($"num zeros: {numZero}");

                    currentPos = newPos - 100;
                }
                else
                {
                    currentPos = newPos;
                }
                Console.WriteLine($"currentPos: {currentPos}");
            }

            if (currentPos == 0)
            {
                numZero++;
                Console.WriteLine($"num zeros: {numZero}");
            }

        }

        return numZero;
    }

    static void PrintLines(string[] lines)
    {
        foreach(var line in lines)
        {
            Console.WriteLine(line);
        }
    }
}