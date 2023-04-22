using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = int.Parse(Console.ReadLine());

        while (number != 0)
        {
            numbers.Add(number);
            number = int.Parse(Console.ReadLine());
        }

        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");

        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(int.MaxValue).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
        Console.WriteLine("The sorted list is:");
        foreach (int n in sortedNumbers)
        {
            Console.WriteLine(n);
        }
    }
}
