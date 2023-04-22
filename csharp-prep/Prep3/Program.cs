using System;

namespace GuessMyNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //random number generator
            Random rand = new Random();

            bool playAgain = true;
            while (playAgain)
            {
                int magicNumber = rand.Next(1, 101);

                Console.WriteLine("I'm thinking of a number between 1 and 100. Can you guess it?");
                int numberOfGuesses = 0;
                int guess = 0;
                while (guess != magicNumber)
                {
                    Console.Write("What is your guess? ");
                    guess = int.Parse(Console.ReadLine());
                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine("You guessed it!");
                    }

                    numberOfGuesses++;
                }
                Console.WriteLine($"It took you {numberOfGuesses} guesses to guess the number.");
                Console.Write("Do you want to play again? (yes/no) ");
                string answer = Console.ReadLine();
                playAgain = answer.ToLower() == "yes";
            }
        }
    }
}
