using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number= randomGenerator.Next(1,101);

        int guess = -5;
        while (guess != number)
        {
        Console.Write("Whats is your guess? ");
        guess = int.Parse(Console.ReadLine());
        if (guess > number)
            Console.WriteLine("Lower");
        else if (guess < number)
            Console.WriteLine("Higher");
        }
        Console.WriteLine("you guessed it!");
    }
}