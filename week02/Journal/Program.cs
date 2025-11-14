using System;
using System.IO;
class Program
{
    //I exceed the requirments adding two more options in the menu to save and load to CSV files, and create those new methods in the journal class/file
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

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Your entry: ");
                    string entryText = Console.ReadLine();
                    string dateText = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(dateText, prompt, entryText));
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    Console.Write("Enter CSV filename to save: ");
                    string csvSaveFile = Console.ReadLine();
                    journal.SaveToCsv(csvSaveFile);
                    break;

                case "6":
                    Console.Write("Enter CSV filename to load: ");
                    string csvLoadFile = Console.ReadLine();
                    journal.LoadFromCsv(csvLoadFile);
                    break;

                case "7":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
