using System;
using System.Collections.Generic;
using System.IO;

// Creative Feature:
// This program includes a level-up system that increases the
// user's level depending on accumulated points. This exceeds
// the core Eternal Quest requirements by adding progression
// and motivation through levels.

namespace EternalQuest
{
    class Program
    {
        private const string DefaultDataFile = "goals.txt";
        private static int level = 1;

        static void Main(string[] args)
        {
            int score = 0;
            var goals = new List<Goal>();

            if (File.Exists(DefaultDataFile))
            {
                goals = Storage.LoadGoals(DefaultDataFile, out score);
                CheckLevelUp(score);
            }

            bool exit = false;

            Console.WriteLine("=== Eternal Quest ===");

            while (!exit)
            {
                Console.WriteLine($"\nScore: {score} | Level: {level}");
                Console.WriteLine("1. Create a goal");
                Console.WriteLine("2. List goals");
                Console.WriteLine("3. Record an event (complete a goal)");
                Console.WriteLine("4. Save goals");
                Console.WriteLine("5. Load goals");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        CreateGoal(goals);
                        break;
                    case "2":
                        ListGoals(goals);
                        break;
                    case "3":
                        score += RecordEvent(goals);
                        CheckLevelUp(score);
                        break;
                    case "4":
                        Storage.SaveGoals(DefaultDataFile, goals, score);
                        Console.WriteLine($"Saved to {DefaultDataFile}");
                        break;
                    case "5":
                        goals = Storage.LoadGoals(DefaultDataFile, out score);
                        Console.WriteLine($"Loaded from {DefaultDataFile}");
                        CheckLevelUp(score);
                        break;
                    case "6":
                        // Antes de salir guardamos
                        Storage.SaveGoals(DefaultDataFile, goals, score);
                        Console.WriteLine("Saved. Goodbye!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void CreateGoal(List<Goal> goals)
        {
            Console.WriteLine("Choose goal type: 1) Simple  2) Eternal  3) Checklist");
            var type = Console.ReadLine()?.Trim();

            Console.Write("Name: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("Description: ");
            var desc = Console.ReadLine() ?? "";

            switch (type)
            {
                case "1":
                    Console.Write("Points when completed (e.g., 100): ");
                    if (int.TryParse(Console.ReadLine(), out var p))
                    {
                        goals.Add(new SimpleGoal(name, desc, p));
                        Console.WriteLine("Simple goal added.");
                    }
                    else Console.WriteLine("Invalid points value.");
                    break;

                case "2":
                    Console.Write("Points per recording (e.g., 10): ");
                    if (int.TryParse(Console.ReadLine(), out var per))
                    {
                        goals.Add(new EternalGoal(name, desc, per));
                        Console.WriteLine("Eternal goal added.");
                    }
                    else Console.WriteLine("Invalid points value.");
                    break;

                case "3":
                    Console.Write("Points per completion (e.g., 10): ");
                    if (!int.TryParse(Console.ReadLine(), out var pts)) { Console.WriteLine("Invalid points."); break; }
                    Console.Write("Required times to complete (e.g., 10): ");
                    if (!int.TryParse(Console.ReadLine(), out var req)) { Console.WriteLine("Invalid required times."); break; }
                    Console.Write("Completion bonus (e.g., 500): ");
                    if (!int.TryParse(Console.ReadLine(), out var bonus)) { Console.WriteLine("Invalid bonus."); break; }

                    goals.Add(new ChecklistGoal(name, desc, pts, req, bonus));
                    Console.WriteLine("Checklist goal added.");
                    break;

                default:
                    Console.WriteLine("Invalid type.");
                    break;
            }
        }

        static void ListGoals(List<Goal> goals)
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }

            for (int i = 0; i < goals.Count; i++)
            {
                var g = goals[i];
                Console.WriteLine($"{i + 1}. {g.GetStatusString()} {g.Name} - {g.Description}");
                var extra = g.ExtraInfo();
                if (!string.IsNullOrWhiteSpace(extra)) Console.WriteLine($"   {extra}");
            }
        }

        static int RecordEvent(List<Goal> goals)
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available.");
                return 0;
            }

            ListGoals(goals);
            Console.Write("Select goal number to record an event: ");
            if (!int.TryParse(Console.ReadLine(), out int idx))
            {
                Console.WriteLine("Invalid number.");
                return 0;
            }

            if (idx < 1 || idx > goals.Count)
            {
                Console.WriteLine("Out of range.");
                return 0;
            }

            var g = goals[idx - 1];
            var gained = g.RecordEvent();

            if (gained > 0)
            {
                Console.WriteLine($"You gained {gained} points!");
            }
            else
            {
                Console.WriteLine("No points gained (maybe it was already complete).");
            }

            if (g.IsComplete())
            {
                Console.WriteLine($"Goal '{g.Name}' is now complete! Congratulations!");
            }

            return gained;
        }

        static void CheckLevelUp(int score)
        {
            int newLevel = 1;
            if (score >= 2000) newLevel = 4;
            else if (score >= 1000) newLevel = 3;
            else if (score >= 500) newLevel = 2;

            if (newLevel > level)
            {
                level = newLevel;
                Console.WriteLine($"\n🎉 Congratulations! You reached Level {level}!");
            }
        }
    }
}
