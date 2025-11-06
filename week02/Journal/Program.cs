using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Save to CSV");
            Console.WriteLine("6. Load to CSV");
            Console.WriteLine("7. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

        }
    }
}
