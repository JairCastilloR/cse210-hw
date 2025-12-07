using System;

namespace EternalQuest
{
    public static class GoalFactory
    {
        public static Goal FromString(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;

            var parts = line.Split('|');
            if (parts.Length == 0) return null;

            var type = parts[0];

            try
            {
                switch (type)
                {
                    case "Simple":
                        return new SimpleGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            bool.Parse(parts[4])
                        );

                    case "Eternal":
                        return new EternalGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            int.Parse(parts.Length > 4 ? parts[4] : "0")
                        );

                    case "Checklist":
                        return new ChecklistGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),  
                            int.Parse(parts[4]),   
                            int.Parse(parts[5]),   
                            int.Parse(parts.Length > 6 ? parts[6] : "0")
                        );

                    default:
                        return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
