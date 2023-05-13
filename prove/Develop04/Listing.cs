using System;
using static System.Console;

class Listing : Activity
{
    private List<string> _prompts = new List<string>
    {
        //prompts
        "Who are people that you appreciate?"
        ,"What are personal strengths of yours?"
        ,"Who are people that you have helped this week?"
        ,"When have you felt the Holy Ghost this month?"
        ,"Who are some of your personal heroes?"
    };

    public string PickRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    public void DisplayPrompt(string Prompt)
    {
        WriteLine($"--- {Prompt} ---");
    }

    public int CountEntries(int totalEntries)
    {
        totalEntries += 1;
        return totalEntries;
    }

    public string DisplayEntryCount()
    {
        return "Sample count display.";
    }

    public void StartListing(int SessionTime)
    {
        //Load
        int TotalTime = SessionTime;
        Clear();
        Write("Loading  ");
        Animation(3000);
        Clear();

        //Get and display prompt.
        string prompt = PickRandomPrompt();
        WriteLine("\nList as many responses you can to to following prompt:");
        DisplayPrompt(prompt);

        Write("You may begin in: ");
        TimerCountdown(5000);

        int TotalEntries = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(SessionTime);

        while (DateTime.Now < endTime)
        {
            Write("\n> ");
            ReadLine();
            TotalEntries = CountEntries(TotalEntries);
        }
        WriteLine($"You listed {TotalEntries} items");

        WriteLine($"\nYou have completed another {TotalTime} seconds of the Reflection Activity.");
        Animation(5000);
    }
}