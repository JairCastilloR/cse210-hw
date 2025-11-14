using System;

class Program
{
    //I exceed the requirements adding a list of scriptures(in the ScriptureLibrary class) to choose them randomly, 
    //In the menu I added a new opction name change to swith to another scripture of the list randomly
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");

        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Options:");
            Console.WriteLine("1. Press Enter to hide words");
            Console.WriteLine("2. Type 'change' to select a new scripture");
            Console.WriteLine("3. Type 'quit' to exit");

            var input = Console.ReadLine();
            if (input?.ToLower() == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else if (input?.ToLower() == "change")
            {
                scripture = library.GetRandomScripture(); 
                continue; 
            }

            scripture.HideRandomWords(1);
            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("All words are now hidden! Goodbye!");
                break;
            }
        }
    }
}