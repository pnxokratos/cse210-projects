using System;
using static System.Console;

public abstract class Goal
{
    private string _Type;
    private string _Title;
    private string _Description;
    private int _points;
    private bool _IsComplete;

    public string GetgoalType()
    {
        return _Type;
    }
    public string GetTitle()
    {
        return _Title;
    }
    public string GetDescription()
    {
        return _Description;
    }
    public int GetPoints()
    {
        return _points;
    }
    public void SetType(string input)
    {
        _Type = input;
    }
    public void SetTitle(string input)
    {
        _Title = input;
    }
    public void SetDescription(string input)
    {
        _Description = input;
    }
    public void SetPoints(int input)
    {
        _points = input;
    }
    public abstract string GetInfo();

    public string BasicInfo()
    {
        Clear();
        Write("What is the Title of this goal: ");
        string title = ReadLine();
        Write("What is the description of the goal: ");
        string description = ReadLine();
        int Points;
        while (true)
        {
            Write("How many points will you get for completing this goal: ");
            string points = ReadLine();
            if (int.TryParse(points, out Points))
            {
                if (Points < 0)
                {
                    WriteLine("Sorry that number is not valid. Please try again");
                }
                else
                {
                    break;
                }
            }
            else
            {
                WriteLine("Sorry that number is not valid. Please try again");
            }
        }

        string basicinfo = $"{title}|{description}|{Points}";
        return basicinfo;
    }
}