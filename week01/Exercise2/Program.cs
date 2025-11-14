using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        int gradePercentage = int.Parse(Console.ReadLine());
        string letter="";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");
        
        if (gradePercentage >= 70)
        {
            Console.WriteLine("You passed the class! Congratulations!");
        }
        else
        {
            Console.WriteLine("You failed the class. But don't give up, try again next time!");
        }
    }
}