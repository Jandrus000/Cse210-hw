using Microsoft.VisualBasic;

//Entry class contains NewEntry for the users journal entry, TimeDate which stores the time and date of entry, PromptUsed which stores the prompt the user responded too,
//and Prompts a list of possible prompts .
public class Entry
{

    public string NewEntry;
    public string TimeDate;
    public string PromptUsed;
    public List<string> Prompts = new List<string> {"Who was the most interesting person I interacted with today?","What was the best part of my day?",
                                                    "How did I see the hand of the Lord in my life today?","What was the strongest emotion I felt today?",
                                                    "If I had one thing I could do over today, what would it be?","Whats something I would want to say to my future self?",
                                                    "If today was ideal, what would it have been like?", "What is something I did outside of my comfort zone today"};

    //MakeEntry() calls the ShowPrompt() method and prompts the user for input that is stored in NewEntry
    //The date is collected by using DateTime.now and is converted to string to be stored in TimeDate
    public void MakeEntry()
    {
        ShowPrompt();
        Console.Write("> ");
        NewEntry = Console.ReadLine();

        DateTime DateTimeTemp = new DateTime();
        DateTimeTemp = DateTime.Now;
        TimeDate = DateTimeTemp.ToString();

    }

    //ShowPrompt generates a random number in the range of Prompts.Count(). Generated number is used as index for Prompts[]
    //and is set as value for PromptUsed. PromptUsed is then printed to console.
    public void ShowPrompt(){
        var random = new Random();
        PromptUsed = Prompts[random.Next(0,Prompts.Count())];
        Console.WriteLine(PromptUsed);
    }
}

