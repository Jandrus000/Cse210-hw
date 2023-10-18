using System;
using System.Runtime.InteropServices;
// Assignment requirements are exceeded by implementing a way that the program only decides if Words are hidden for Words if they are already shown.
// Also when the user presses enter the program will continuously loop through the hiding algorithm until at least one word is hidden.

class Program
{
    static void Main(string[] args)
    {
        List<int> verses = new List<int>(new int[] { 1, 2, 3 } );;
        Reference myReference = new Reference("Romans", 9, verses);
        Scripture myScripture = new Scripture(myReference, "I say the truth in Christ, I lie not, my conscience also bearing me witness in the Holy Ghost, That I have great heaviness and continual sorrow in my heart. For I could wish that myself were accursed from Christ for my brethren, my kinsmen according to the flesh:");
        string userInput = "";
        while(userInput!="quit")
        {
            Console.Clear();
            if(myScripture.IsHidden())
            {
                userInput="quit";
                myScripture.DisplayScripture();
            }else
            {
                myScripture.DisplayScripture();
                Console.Write("\n\nPress enter to continue or type 'quit' to finish: ");
                userInput = Console.ReadLine();
                // See HideWords() in Scripture to see how I exceeded requirements
                myScripture.HideWords();
            }
            
            
        }
    }
}