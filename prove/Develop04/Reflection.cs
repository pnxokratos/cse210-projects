using System;
using static System.Console;

class Reflection : Activity
{
    private List<string> _prompts = new List<string>
    {
        //prompts.
        "Think of a time when you stood up for someone else."
        ,"Think of a time when you did something really difficult."
        ,"Think of a time when you helped someone in need."
        ,"Think of a time when you did something truly selfless"
    };
    private List<string> _Thoughts = new List<string>
    {
        //thoughts.
        "Why was this experience meaningful to you?"
        ,"Have you ever done anything like this before?"
        ,"How did you get started?"
        ,"How did you feel when it wwas complete?"
        ,"What made this time different than other times when you were not as successful?"
        ,"What is your favorite thing about this experience??"
        ,"What could you lern from this experience that applies to other situations?"
        ,"What did you leran about yourself through this experience?"
        ,"how can you keep this experience in mind in the future?"
    };

    public string PickRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    public string PickRandomThought()
    {
        Random rand = new Random();
        int index = rand.Next(_Thoughts.Count);
        return _Thoughts[index];
    }

    public void DisplayPrompt(string Prompt)
    {
        WriteLine($"--- {Prompt} ---");
    }

    public void DisplayThought(string Thought)
    {
        Write($"\n> {Thought} ");
    }

    public void StartReflecting(int SessionTime)
    {
        //Load
        int TotalTime = SessionTime;
        Clear();
        Write("Loading  ");
        Animation(3000);
        Clear();

        //Get and display the prompt.
        string prompt = PickRandomPrompt();
        WriteLine("\nConsider the following prompt:");
        DisplayPrompt(prompt);
        WriteLine("When you have something in mind, press enter to continue.");
        ReadLine();

        WriteLine("Now ponder on each of the following questions as they relate to theis experience.");
        Write("You may begin in: ");
        TimerCountdown(5000);

        Clear();
        while(SessionTime > 0)
        {
            string thought = PickRandomThought();
            DisplayThought(thought);
            Animation(15000);
            SessionTime -=15;
        }

        WriteLine($"\nYou have completed another {TotalTime} seconds of the Reflection Activity.");
        Animation(5000);
    }
}