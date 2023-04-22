using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (grade >= 70)
        {
            Console.WriteLine($"Your letter grade is {letter}. Congratulation! You passed the course.");
        }
        else
        {
            Console.WriteLine($"Your letter grade is {letter}. You did not pass the course. Better luck next time!");
        }

        string sign = "";

        if (letter == "A" && grade % 10 >= 7)
        {
            sign = "+";
        }
        else if ((letter == "B" || letter == "C" || letter == "D") && grade % 10 >= 3 && grade % 10 <= 6)
        {
            sign = "";
        }
        else if ((letter == "B" || letter == "C" || letter == "D") && grade % 10 < 3)
        {
            sign = "-";
        }

        if (letter == "A" && grade != 100 || letter == "F")
        {
            Console.WriteLine($"Your letter grade is {letter}{sign}.");
        }
        else if (letter == "A")
        {
            Console.WriteLine($"Your letter grade is A.");
        }
        else
        {
            Console.WriteLine($"Your letter grade is {letter}{sign}.");
        }
    }
}
