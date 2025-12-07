using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public static class Storage
    {
        public static void SaveGoals(string filename, List<Goal> goals, int score)
        {
            using (var writer = new StreamWriter(filename, false))
            {
                writer.WriteLine($"Score|{score}");

                foreach (var g in goals)
                {
                    writer.WriteLine(g.Serialize());
                }
            }
        }
        
        public static List<Goal> LoadGoals(string filename, out int score)
        {
            var result = new List<Goal>();
            score = 0;

            if (!File.Exists(filename)) return result;

            var lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split('|');
                if (parts.Length == 0) continue;

                if (parts[0] == "Score")
                {
                    if (parts.Length > 1 && int.TryParse(parts[1], out var s))
                    {
                        score = s;
                    }
                    continue;
                }

                var g = GoalFactory.FromString(line);
                if (g != null) result.Add(g);
            }

            return result;
        }
    }
}
