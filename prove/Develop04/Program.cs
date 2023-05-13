using System;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        //variables.
        int CountBreathing = 0;
        int CountReflecting = 0;
        int CountListing = 0;
        int running = 1;
        while(running != 0)
        {
            Console.Clear();
            WriteLine("\n-----------------------------");
            WriteLine("         Menu Options");
            WriteLine("-----------------------------");
            WriteLine("1. Start breathing activity");
            WriteLine("2. Start reflecting activity");
            WriteLine("3. Start listing activity");
            WriteLine("4. Details");
            WriteLine("0. Quit");
            WriteLine("-----------------------------");
            Write("Select a choice from the menu: ");
            string userChoice = ReadLine();

            if (userChoice == "1")
            {
                CountBreathing += 1;
                //Create an instance of the breathing activity.
                Breathing breathing1 = new Breathing();

                //Set the welcome message.
                breathing1.SetWelcomeText("Welcome to the Breathing Activity.");
                WriteLine(breathing1.GetWelcomText());

                //Set the activity Discription.
                breathing1.SetActivityDiscription("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
                WriteLine(breathing1.GetActivityDiscription());
                
                //Get the session time.
                WriteLine("How long do you want your session to be in seconds? ");
                string time = ReadLine();
                breathing1.SetSessionTime(time);
                int intTime = breathing1.GetSessionTime();

                //start the process
                breathing1.StartBreathing(intTime);
            }

            else if (userChoice == "2")
            {
                CountReflecting += 1;
                //Create an instance of the reflection activity.
                Reflection reflection1 = new Reflection();

                //Set the welcome message.
                reflection1.SetWelcomeText("Welcome to the Reflecting Activity.");
                WriteLine(reflection1.GetWelcomText());

                //Set the activity Discription.
                reflection1.SetActivityDiscription("This activity will help you reflect on times in you life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of you life.");
                WriteLine(reflection1.GetActivityDiscription());

                //Get the session time.
                WriteLine("How long do you want your session to be in seconds? ");
                string time = ReadLine();
                reflection1.SetSessionTime(time);
                int intTime = reflection1.GetSessionTime();

                //Start the process
                reflection1.StartReflecting(intTime);
            }

            else if (userChoice == "3")
            {
                CountListing += 1;
                //Create an instance of the listing activity.
                Listing listing1 = new Listing();

                //Set the welcome message.
                listing1.SetWelcomeText("Welcome to the Listing Activity.");
                WriteLine(listing1.GetWelcomText());

                //Set the activity Discription.
                listing1.SetActivityDiscription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                WriteLine(listing1.GetActivityDiscription());

                //Get the session time.
                WriteLine("How long do you want your session to be in seconds? ");
                string time = ReadLine();
                listing1.SetSessionTime(time);
                int intTime = listing1.GetSessionTime();

                //Start the process
                listing1.StartListing(intTime);
            }

            else if (userChoice == "4")
            {
                int data = 1;
                while(data == 1)
                {
                    Details details1 = new Details();
                    WriteLine("--------------------");
                    WriteLine("       Details");
                    WriteLine("--------------------");
                    WriteLine("1. Statistics");
                    WriteLine("2. About activities");
                    WriteLine("0. Back");
                    userChoice = ReadLine();

                    if (userChoice == "1")
                    {
                        details1.Statistics(CountBreathing, CountReflecting, CountListing);
                    }

                    else if (userChoice == "2")
                    {
                        details1.AboutActivities();
                    }

                    else if (userChoice == "0")
                    {
                        data = 0;
                    }

                    else
                    {
                        WriteLine("Sorry I don't understand that.");
                    }
                }
            }

            else if (userChoice == "0")
            {
                //Close the program.
                WriteLine("See you next time.");
                running = 0;
            }

            else
            {
                WriteLine("Sorry I don't understand that.");
            }
        }
    }
}