using System.ComponentModel;
using System.Net;
using System.Text.Json.Serialization;

public class Journal 
{
    public List<Entry> Entries = new List<Entry>();

    public void SaveJournal()
    {
        Console.WriteLine();
        Console.Write("PLease enter the filename where you want journal to be saved: ");
        string fileLocation = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileLocation))
        {
            
            foreach (Entry entry in Entries)
            {
                outputFile.WriteLine(entry.Datetime);
                outputFile.WriteLine(entry.PromptUsed);
                outputFile.WriteLine(entry.NewEntry);
            }
            outputFile.WriteLine("End of Journal");
            
        }
    }

    public void AddEntry(Entry NewEntry)
    {
        Entries.Add(NewEntry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in Entries){
            Console.WriteLine(entry.Datetime);
            Console.WriteLine(entry.PromptUsed);
            Console.WriteLine(entry.NewEntry+"\n");
        }
    }

    public void ChooseOptions()
    {
        while (true){
            Console.WriteLine("\nPlease Select one of the following choices");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string response_string = Console.ReadLine();
            int response = 0;
            
            if(int.TryParse(response_string, out response))
                response = Convert.ToInt32(response_string);
            

            if(response == 1){
                Entry entry = new Entry();
                entry.MakeEntry();
                AddEntry(entry);
            }
            else if (response == 2) 
                DisplayJournal();
            else if (response == 3)
                LoadJournal();
            else if (response == 4)
                SaveJournal();
            else if (response == 5)
                break;
            else
                Console.WriteLine("Please enter valid menu option");
        }
    }

    public void LoadJournal()
    {
        Entries.Clear();

        Console.Write("Please enter file name of journal to load: ");
        string[] lines = System.IO.File.ReadAllLines(Console.ReadLine());
        int count = 0;
        while (true)
        {   
            Entry currentEntry = new Entry();
            
            currentEntry.Datetime = lines[count];
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