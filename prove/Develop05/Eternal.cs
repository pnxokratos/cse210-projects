using System;
using static System.Console;

public class EternalGoal : Goal
{
    public override string GetInfo()
    {
        string basicInfo = BasicInfo();
        string[] devidedInfo = basicInfo.Split("|");
        string Title = devidedInfo[0];
        string Description = devidedInfo[1];
        string points = devidedInfo[2];
        int Points = int.Parse(points);

        string goal = CreateGoal(Title, Description, Points);
        return goal;
    }

    private string CreateGoal(string title, string description, int Points)
    {
        string goal = $"Eternal|{title}|{description}|{Points}|False";
        return goal;
    }
}