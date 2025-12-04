using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "What are you grateful for today?",
        "List people who have influenced you positively.",
        "List things that make you happy.",
        "List achievements you are proud of."
    };

    public ListingActivity()
        : base("Listing Activity",
               "This activity helps you reflect by listing positive things in your life.")
    {
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private List<string> GetListFromUser()
    {
        List<string> entries = new List<string>();
        Console.WriteLine("\nStart listing items (press Enter after each item):");

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                entries.Add(input);
            }
        }

        return entries;
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nYour prompt is:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("Starting in...");
        ShowCountDown(5);

        List<string> list = GetListFromUser();
        _count = list.Count;

        Console.WriteLine($"\nYou listed {_count} items.");

        DisplayEndingMessage();
    }
}
