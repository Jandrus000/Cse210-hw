using System;
using System.Data.Common;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        //Exceeded requirements by adding a totalTime variable that keeps track of how much time is spent in all ativites in a given
        //session. This time is calculated using the time that the user enters for how long he wants each activity to last.
        int totalTime = 0;
        while(true){
            Console.Clear();
            if(totalTime > 120)
            {
                System.Console.WriteLine($"Total time being mindful: {totalTime/60} mins");
            }else if(totalTime > 0)
            {
                System.Console.WriteLine($"Total time being mindful: {totalTime} secs");
            }
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("\t1. Start breathing activty");
            Console.WriteLine("\t2. Start reflecting activty");
            Console.WriteLine("\t3. Start listening activty");
            Console.WriteLine("\t4. Quit");
            Console.Write("Select a choice from the menu: ");

            string tryChoice = Console.ReadLine();
            int choice = 0;
            if(int.TryParse(tryChoice, out choice))
                choice = int.Parse(tryChoice);

            if(choice == 1)
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                //adds time to totalTime
                totalTime += breathingActivity.GetTime();
            }
            else if(choice == 2)
            {
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                //adds time to totalTime
                totalTime += reflectionActivity.GetTime();
            }
            
            else if(choice == 3)
            {
                ListingActivity listingActivity = new ListingActivity();
                //adds time to totalTime
                totalTime += listingActivity.GetTime();
            }
            else if (choice == 4)
            {
                break;
            } 
        }
    }
}