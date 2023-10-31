using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public class Activity
{
    protected int _time;
    protected DateTime currentTime;
    protected DateTime futureTime;

    public void GetReady()
    {
        SetTime();
        Console.Clear();
        Console.Write("Ready");
        Pause();
        
    }

    public void EndingMessage(string message)
    {
        System.Console.WriteLine("\n\nWell Done!!");
        Pause();
        System.Console.WriteLine(message);
        Pause();
    }
    public void Pause()
    {
        for(int i=3; i > 0; i--)
        {
            for(int x=0; x < 3; x++)
            {
                Console.Write(".");
                Thread.Sleep(250); 
            } 
            for(int x=0; x < 3; x++)
            {
                Console.Write("\b \b");
                Thread.Sleep(250);
            } 
        }
    }
    public void SetFutureTime()
    {
        currentTime = DateTime.Now;
        futureTime = currentTime.AddSeconds(_time);
    }

    public void CountDown(int length)
    {
        for(int i=length; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void SetTime()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        int time = int.Parse(Console.ReadLine());
        _time = time;
    }
    public int GetTime()
    {
        return _time;
    }
}