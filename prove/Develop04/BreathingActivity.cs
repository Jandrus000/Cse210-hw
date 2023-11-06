
using System.Runtime.InteropServices;
using System.Transactions;

public class BreathingActivity : Activity
{

    public BreathingActivity()
    {
        Console.Clear();

        _startMessage();

        GetReady();

        _breathingLoop();

        EndingMessage($"\nYou have completed another {_time} seconds of the Breathing Activity");

    }

    private void _breathingLoop()
    {
        SetFutureTime();
        while(currentTime <= futureTime)
        {
            Console.Write("\n\nBreathe in...");
            CountDown(4);
            Console.Write("\nnow breathe out...");
            CountDown(6);
            currentTime = DateTime.Now;
        }
    }

    private void _startMessage()
    {
        Console.WriteLine("Welcome to the Breathing Activity");
        Console.WriteLine("\nThis activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

}