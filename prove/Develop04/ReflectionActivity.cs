using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>{"Think of a time when you stood up for someone else.","Think of a time when you did something really difficult.","Think of a time when you helped someone in need.","Think of a time when you did something truly selfless."};
    private List<string> _questions = new List<string> {"Why was this experience meaningful to you?","Have you ever done anything like this before?","How did you get started?","How did you feel when it was complete?","What made this time different than other times when you were not as successful?","What is your favorite thing about this experience?","What could you learn from this experience that applies to other situations?","What did you learn about yourself through this experience?","How can you keep this experience in mind in the future?"};

    public ReflectionActivity()
    {
        Console.Clear();
        _welcomeMessage();
        
        GetReady();

        _showPrompt();

        _questionLoop();
        
        EndingMessage($"\nYou have completed another {_time} seconds of the Reflecting Activity");
    }

    private void _welcomeMessage()
    {
        System.Console.WriteLine("Welcome to the Reflecting Activity.");
        Console.WriteLine("\nThis activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n");
    }

    private void _showPrompt()
    {
        Random rnd = new Random();
        System.Console.WriteLine("\n\nConsider the following prompt:");
        System.Console.WriteLine($"\n---{_prompts[rnd.Next(0,4)]}---");
        System.Console.Write("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        System.Console.WriteLine("\nNow ponder each of the following questions as they relate to this experience");
        System.Console.Write("You may begin in: ");
        CountDown(5);
        Console.Clear();
    }

    private void _questionLoop()
    {
        SetFutureTime();
        Random rnd = new Random();
        while(currentTime <= futureTime)
        {
            Console.Write($"\n>{_questions[rnd.Next(0,8)]}");
            Pause();
            currentTime = DateTime.Now;
        }
    }

}