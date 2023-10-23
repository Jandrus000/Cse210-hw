using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment myAssignment = new MathAssignment("Joe Biden","Multiplication",7.3,"7-11");
        System.Console.WriteLine(myAssignment.GetSummary());
        System.Console.WriteLine(myAssignment.GetHomeWorkList());

        WritingAssignment myAssignment0 = new WritingAssignment("Jerry SeinFeld","History","The Industrial Revoloution and its Consequences");
        System.Console.WriteLine(myAssignment0.GetSummary());
        System.Console.WriteLine(myAssignment0.GetWritingInformation());
    }
}