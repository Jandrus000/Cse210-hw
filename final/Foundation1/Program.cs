using System;

class Program
{
    static void Main(string[] args)
    {
        int[] years = { 2013, 2014, 2015 };
        int[] population = { 1025632, 1105967, 1148203 };
        String s = String.Format("{0,-10} {1,-10}\n\n", "Year", "Population");
        for(int index = 0; index < years.Length; index++)
        s += String.Format("{0,-10} {1,-10:N0}\n",
                            years[index], population[index]);
        Console.WriteLine($"\n{s}");
    }
}