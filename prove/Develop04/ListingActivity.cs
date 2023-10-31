
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>{"Who are people that you appreciate?","What are personal strengths of yours?","Who are people that you have helped this week?","When have you felt the Holy Ghost this month?","Who are some of your personal heroes?"};

    public ListingActivity()
    {
        Console.Clear();
        
        _welcomeMessage();

        GetReady();

        _showPrompt();

        _enterResponses();

        EndingMessage($"\nYou have completed another {_time} seconds of the Listing Activity");
    }

    private void _welcomeMessage()
    {
        System.Console.WriteLine("Welcome to the Listing Activity.");
        Console.WriteLine("\nThis activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n");
    }

    private void _showPrompt()
    {
        System.Console.WriteLine("\n\nList as many responses as you can to the following prompt:");
        Random rnd = new Random();
        System.Console.WriteLine($"\n--- {_prompts[rnd.Next(0,4)]} ---");
        System.Console.Write("You may begin in: ");
        CountDown(5);
        System.Console.WriteLine();
    }

    private void _enterResponses()
    {
        SetFutureTime();
        while(currentTime <= futureTime)
        {
            System.Console.Write(">");
            Console.ReadLine();
            currentTime=DateTime.Now;
        }
    }

}