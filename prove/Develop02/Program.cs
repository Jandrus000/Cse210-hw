using System;

class Program
{
    static void Main(string[] args)
    {
        //New Journal object is made, welcomes user, and call the Chooseoptions method.
        Journal myJournal = new Journal();
        Console.WriteLine("Welcome to the Journal Program!");
        //ChooseOptions displays options to the user, the associated method is called depending what the user chooses
    //if 5 is entered the loop is broken.
    //Creativity is shown by continuing the loop and displaying an error message even if a number is not entered.
        while (true)
        {
            Console.WriteLine("\nPlease Select one of the following choices");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string responseString = Console.ReadLine();
            int response = 0;
            if(int.TryParse(responseString, out response))
                response = Convert.ToInt32(responseString);
        
            if(response == 1)
            {
                Entry entry = new Entry();
                entry.MakeEntry();
                myJournal.AddEntry(entry);
            }
            else if (response == 2) 
                myJournal.DisplayJournal();
            else if (response == 3)
                myJournal.LoadJournal();
            else if (response == 4)
                myJournal.SaveJournal();
            else if (response == 5)
                break;
            else
                Console.WriteLine("Please enter valid menu option");
        
    }



    }
}