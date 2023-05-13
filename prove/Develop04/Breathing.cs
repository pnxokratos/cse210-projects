using System;
using static System.Console;

class Breathing : Activity
{
    private void breathIn()
    {
        //breath in
        Write("\nBreath in... ");
        TimerCountdown(5000);
    }
    private void breathOut()
    {
        //breath out
        Write("\nBreath out... ");
        TimerCountdown(5000);
    }

    public void StartBreathing(int SessionTime)
    {
        //getting ariginal starting time.
        int TotalTime = SessionTime;
        //Start the loading sequence.
        Clear();
        Write("Loading  ");
        Animation(3000);
        Clear();
        WriteLine("Get Ready.");
        TimerCountdown(3000);

        while(SessionTime > 0)
        {
            breathIn();
            breathOut();
            SessionTime -= 10;
        }
        WriteLine($"\nYou have Completed another {TotalTime} seconds of the Breathing Activity.");
        Animation(3000);
    }
    
}