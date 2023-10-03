using Microsoft.VisualBasic;

public class Entry{

    public string NewEntry;
    public string Datetime;
    public string PromptUsed;
    public List<string> Prompts = new List<string> {"Who was the most interesting person I interacted with today?","What was the best part of my day?","How did I see the hand of the Lord in my life today?","What was the strongest emotion I felt today?","If I had one thing I could do over today, what would it be?","Whats something I would want to say to my future self?","If today was ideal, what would it have been like?", "What is something I did outside of my comfort zone today"};

    public void MakeEntry(){
        ShowPrompt();
        Console.Write("> ");
        NewEntry = Console.ReadLine();

        DateTime datetime = new DateTime();
        datetime = DateTime.Now;
        Datetime = datetime.ToString();

    }

    public void ShowPrompt(){
        var random = new Random();
        PromptUsed = Prompts[random.Next(0,Prompts.Count())];
        Console.WriteLine(PromptUsed);
    }
}

