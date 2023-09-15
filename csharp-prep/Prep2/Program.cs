using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percent? ");
        var gradePercentstring = Console.ReadLine();
        double gradePercent = double.Parse(gradePercentstring);
        string letter = "";

        if (gradePercent>=90)
            letter = "A";
        else if (gradePercent>=80)
            letter = "B";
        else if (gradePercent>=70)
            letter = "C";
        else if (gradePercent>=60)
            letter = "D";
        else 
            letter = "F";

        Console.WriteLine(letter);
        if (gradePercent>=70)
            Console.WriteLine("Congrats! You Passed!");
        else
            Console.WriteLine("Better luck next time... you failed");
    }
}