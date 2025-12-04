using System;

class Program
{
    static void Main()
    {
        // EXTRA FEATURES ADDED:
        // 1. The program keeps a session log that counts how many times each activity has been performed. This goes beyond the core requirements.
        // 2. A new menu option (5) was added to display this session log.

        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        int choice = 0;

        // Program runs until "Quit" is chosen (4)
        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("5. View Activity Log");   // Extra feature
            Console.Write("Choose an option: ");

            choice = int.Parse(Console.ReadLine() ?? "4");

            Console.Clear();

            switch (choice)
            {
                case 1:
                    breathingCount++;
                    new BreathingActivity().Run();
                    Console.WriteLine("\nReturning to menu...");
                    new Activity("", "").ShowSpinner(3);
                    break;

                case 2:
                    reflectingCount++;
                    new ReflectingActivity().Run();
                    Console.WriteLine("\nReturning to menu...");
                    new Activity("", "").ShowSpinner(3);
                    break;

                case 3:
                    listingCount++;
                    new ListingActivity().Run();
                    Console.WriteLine("\nReturning to menu...");
                    new Activity("", "").ShowSpinner(3);
                    break;

                case 4:
                    Console.WriteLine("\nGoodbye!");
                    return;

                case 5:
                    Console.WriteLine("\n--- Session Activity Log ---");
                    Console.WriteLine($"Breathing Activity performed: {breathingCount} time(s)");
                    Console.WriteLine($"Reflecting Activity performed: {reflectingCount} time(s)");
                    Console.WriteLine($"Listing Activity performed: {listingCount} time(s)");
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();                    
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    new Activity("", "").ShowSpinner(3);
                    break;
            }
        }
    }
}
