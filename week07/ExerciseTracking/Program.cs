using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();

            activities.Add(new Running("03 Nov 2022", 30, 4.8));
            activities.Add(new Cycling("03 Nov 2022", 45, 20.0));
            activities.Add(new Swimming("03 Nov 2022", 25, 40));

            foreach (Activity a in activities)
            {
                Console.WriteLine(a.GetSummary());
            }
        }
    }
}
