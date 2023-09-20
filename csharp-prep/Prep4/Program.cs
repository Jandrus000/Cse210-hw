using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int input = -1;
        while (input != 0)
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0)
                numbers.Add(input);
        }
        int sum = 0;
        int largest = -1000000000;
        foreach (int number in numbers)
        {
            sum += number;
            if (number>largest)
                largest = number;
        }
        float average = (float)sum / numbers.Count();
        Console.WriteLine($"The Sum is: {sum}");
        Console.WriteLine($"The Average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

    }
}