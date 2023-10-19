using System.ComponentModel;
using System.Net;
using System.Text.Json.Serialization;

//The save Journal class keeps a list of objects from the Entry class.  Contains the methods SaveJournal(), AddEntry(), 
//DisplayJournal(), ChooseOptions,and LoadJournal()
public class Journal 
{
    public List<Entry> Entries = new List<Entry>();

    //SaveJournal recieves the name of the of a file from the user and prints the entire list of Entry Objects
    //to the .txt file. End of Journal is added to the end of the Saved Journal to be detected by the LoadJournal method.
    public void SaveJournal()
    {
        Console.WriteLine();
        Console.Write("PLease enter the filename where you want journal to be saved: ");
        string fileLocation = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileLocation))
        {
            foreach (Entry entry in Entries)
            {
                outputFile.WriteLine(entry.TimeDate);
                outputFile.WriteLine(entry.PromptUsed);
                outputFile.WriteLine(entry.NewEntry);
            }
            outputFile.WriteLine("End of Journal");
        }
    }

    //AddEntry() recieves an Entry object and adds it to the Entry List contained in Journal.
    public void AddEntry(Entry NewEntry)
    {
        Entries.Add(NewEntry);
    }

    //DisplayJournal loops through Entries and prints them to Console.
    public void DisplayJournal()
    {
        foreach (Entry entry in Entries)
        {
            Console.WriteLine(entry.TimeDate);
            Console.WriteLine(entry.PromptUsed);
            Console.WriteLine(entry.NewEntry+"\n");
        }
    }

    
    //LoadJournal clears all Entries from current List. Then, reads all lines from .txt file (file name provided by user), each line is put into array
    //of strings. Each string is iterated through in array. Each string is put into prospective TimeDate, PromptUsed and NewEntry depending on what order they appear.
    //When "End of Journal" is encountered the loop breaks.
    public void LoadJournal()
    {
        Entries.Clear();

        Console.Write("Please enter file name of journal to load: ");
        string[] lines = System.IO.File.ReadAllLines(Console.ReadLine());

        int count = 0;
        while (true)
        {   
            Entry currentEntry = new Entry();
            
            currentEntry.TimeDate = lines[count];
            count++;
            currentEntry.PromptUsed = lines[count];
            count++;
            currentEntry.NewEntry = lines[count];
            count++;

            AddEntry(currentEntry);
            
            if(lines[count]=="End of Journal")
                break;
        }
        
    }
}