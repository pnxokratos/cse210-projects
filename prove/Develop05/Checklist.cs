using System;
using static System.Console;

public class ChecklistGoal : Goal
{
    public override string GetInfo()
    {
        string basicInfo = BasicInfo();
        string[] devidedInfo = basicInfo.Split("|");
        string Title = devidedInfo[0];
        string Description = devidedInfo[1];
        string points = devidedInfo[2];
        int Points = int.Parse(points);
        int BonusPoints;
        int intTimesNeeded;
        while (true)
        {
            Write("How many times do you need to complete this goal: ");
            string timesNeeded = ReadLine();
            if (int.TryParse(timesNeeded, out intTimesNeeded))
            {
                if (intTimesNeeded > 0)
                {
                    break;
                }
                else
                {
                    WriteLine("Sorry that number is not valid. Please try again.");
                }
            }
            else
            {
                WriteLine("Sorry that number is not valid. Please try again.");
            }
        }
        while (true)
        {
            Write($"How many points will you get for completing this goal {intTimesNeeded} times: ");
            string bonuspoints = ReadLine();
            if (int.TryParse(bonuspoints, out BonusPoints))
            {
                break;
            }
            else
            {
                WriteLine("Sorry that nuber is not valid. Please try again.");
            }
        }
        string goal = CreateGoal(Title, Description, Points, BonusPoints, intTimesNeeded);
        return goal;
    }

    private string CreateGoal(string title, string description, int Points, int bonusPoints, int intTimesNeeded)
    {
        string goal = $"Checklist|{title}|{description}|{Points}|{bonusPoints}|0|{intTimesNeeded}|False";
        return goal;
    }
}