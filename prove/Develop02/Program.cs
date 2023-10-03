using System;

class Program
{
    static void Main(string[] args)
    {
        //New Journal object is made, welcomes user, and call the Chooseoptions method.
        Journal myJournal = new Journal();
        Console.WriteLine("Welcome to the Journal Program!");
        myJournal.ChooseOptions();


    }
}