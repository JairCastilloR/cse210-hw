using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("What is the magic number?");
        //int magicNumber = int.Parse(Console.ReadLine());
        
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        int Guess = -1;

        while (Guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            Guess = int.Parse(Console.ReadLine());

            if (magicNumber > Guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < Guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        }
    }
}