using System;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        string newData;
        int totalPoints = 0;
        List<string> goals = new List<string>();
        while (true)
        {
            Clear();
            WriteLine($"Points: {totalPoints}");
            WriteLine("Main Menu:");
            WriteLine("Points: {insert points here}");
            WriteLine("1. Create New Goal");
            WriteLine("2. List Goals");
            WriteLine("3. Save Goals");
            WriteLine("4. Load Goals");
            WriteLine("5. Record Event");
            WriteLine("6. Remove Goal");
            WriteLine("0. Quit");
            Write("\nWhat would you like to do: ");
            string userInput = ReadLine();
            
            if (userInput == "1")
            {
                while(true)
                {
                    Clear();
                    WriteLine("Create New Goal:");
                    WriteLine("1. Simple Goal");
                    WriteLine("2. Eternal Goal");
                    WriteLine("3. Checklist Goal");
                    WriteLine("0. Back");

                    Write("\nWhat would you like to do: ");
                    userInput = ReadLine();

                    if (userInput == "1")
                    {
                        SimpleGoal simple = new SimpleGoal();
                        string goal = simple.GetInfo();
                        goals.Add(goal);
                        break;
                    }
                    else if (userInput == "2")
                    {
                        EternalGoal eternal = new EternalGoal();
                        string goal = eternal.GetInfo();
                        goals.Add(goal);
                        break;
                    }
                    else if (userInput == "3")
                    {
                        ChecklistGoal checklist = new ChecklistGoal();
                        string goal = checklist.GetInfo();
                        goals.Add(goal);
                        break;
                    }
                    else if (userInput == "0")
                    {
                        break;
                    }
                }
            }
            else if (userInput == "2")
            {
                ListGoals(goals);
                Write("\nPress enter to return to main menu. ");
                ReadLine();
            }
            else if (userInput == "3")
            {
                SaveGoals(totalPoints, goals);
            }
            else if (userInput == "4")
            {
                totalPoints = LoadGoals(totalPoints, goals);
            }
            else if (userInput == "5")
            {
                newData = RecordEvent(goals);
                string[] newdata = newData.Split('*');
                int Index = int.Parse(newdata[0]);
                string Data = newdata[1];

                goals[Index] = $"{Data}";
                string[] findpoints = Data.Split('|');
                string type = findpoints[0];
                int points = int.Parse(findpoints[3]);
                totalPoints += points;
                if (type == "Checklist")
                {
                    int bonusPoints = int.Parse(findpoints[4]);
                    int amountDone = int.Parse(findpoints[5]);
                    int amountNeeded = int.Parse(findpoints[6]);
                    if (amountDone >= amountNeeded)
                    {
                        totalPoints += bonusPoints;
                    }
                }
            }

            else if (userInput == "6")
            {
                ListGoals(goals);
                int Index = 0;
                while(true)
                {
                    WriteLine("Enter the goal index number you would like to remove: ");
                    string index = ReadLine();
                    if (int.TryParse(index, out Index))
                    {
                        if (Index < 1)
                        {
                            WriteLine("Sorry that number is invalid. Please try again.");
                        }

                        else
                        {
                            Index = int.Parse(index) - 1;
                            break;
                        }
                    }
                    else
                    {
                        WriteLine("Sorry that number is invalid. Please try again.");
                    }
                }
                goals.RemoveAt(Index);
            }
            else if (userInput == "0")
            {
                break;
            }

            else
            {
                WriteLine("That number is invalid. Please try again.");
            }
        }
    }

    static void ListGoals(List<string> goals)
    {
        Clear();
        
        WriteLine("Goals:");
        string line = "";
        foreach(string goal in goals)
        {
            string[] data = goal.Split('|');
            if (data[0] == "Simple")
            {
                string type = data[0];
                string title = data[1];
                string description = data[2];
                string Points = data[3];
                string done = data[4];
                string IsComplete = "[ ]";
                if (done == "False")
                {
                    IsComplete = "[ ]";
                }
                else if (done == "True")
                {
                    IsComplete = "[X]";
                }

                line = $"{IsComplete} {title} ({description})";
            }
            else if (data[0] == "Eternal")
            {
                string type = data[0];
                string title = data[1];
                string description = data[2];
                string Points = data[3];
                string done = data[4];
                string IsComplete = "[ ]";
                if (done == "False")
                {
                    IsComplete = "[ ]";
                }
                else if (done == "True")
                {
                    IsComplete = "[X]";
                }

                line = $"{IsComplete} {title} ({description})";
            }
            else if (data[0] == "Checklist")
            {
                string type = data[0];
                string title = data[1];
                string description = data[2];
                string Points = data[3];
                string bonusPoints = data[4];
                string amountDone = data [5];
                string amountNeeded = data[6];
                string done = data[7];
                string IsComplete = "[ ]";
                if (done == "False")
                {
                    IsComplete = "[ ]";
                }
                else if (done == "True")
                {
                    IsComplete = "[X]";
                }

                line = $"{IsComplete} {title} ({description}) -- Currently Completed: {amountDone}/{amountNeeded}";
            }
            WriteLine(line);
        }
    }

    static void SaveGoals(int Points, List<string> goals)
    {
        Write("Enter the name of the file you would like to save: ");
        string FileName = ReadLine();

        using (StreamWriter sw = new StreamWriter(FileName))
        {
            sw.WriteLine(Points);
            foreach(string line in goals)
            {
                sw.WriteLine(line);
            }
        }
    }

    static int LoadGoals(int totalPoints, List<string> goals)
    {
        Write("Enter the name of the file you would like to load: ");
        string FileName = ReadLine();

        using (StreamReader sr = new StreamReader(FileName))
        {
            string points = sr.ReadLine();
            totalPoints = int.Parse(points);

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                goals.Add(line);
            }
        }
        return totalPoints;
    }

    static string RecordEvent(List<string> goals)
    {
        ListGoals(goals);

        string goalindex;
        int goalIndex;
        while(true)
        {
            Write("Enter the goals index number that you have completed: ");
            goalindex = ReadLine();
            if (int.TryParse(goalindex, out goalIndex))
            {
                if (goalIndex < 1)
                {
                    WriteLine("Sorry that number is invalid. Please try again.");
                }
                else
                {
                    break;
                }
            }
            else
            {
                WriteLine("Sorry that number is invalid. Please try again.");
            }
        }

        string selectedGoal = goals[goalIndex];
        string[] goalData = selectedGoal.Split('|');

        string type = goalData[0];
        string title = goalData[1];
        string description = goalData[2];
        string points = goalData[3];
        string IsComplete;
        string Goal = "";
        if (type == "Simple")
        {
            IsComplete = goalData[4];
            IsComplete = "True";
            Goal = $"{type}|{title}|{description}|{points}|{IsComplete}";
        }
        if (type == "Eternal")
        {
            IsComplete = goalData[4];
            Goal = $"{type}|{title}|{description}|{points}|{IsComplete}";
        }
        if (type == "Checklist")
        {
            string bonusPoints = goalData[4];
            int amountDone = int.Parse(goalData[5]);
            amountDone += 1;
            int amountNeeded = int.Parse(goalData[6]);
            IsComplete = goalData[7];
            if (amountDone >= amountNeeded)
            {
                IsComplete = "True";
            }
            else
            {
                IsComplete = "False";
            }
            Goal = $"{type}|{title}|{description}|{points}|{bonusPoints}|{amountDone}|{amountNeeded}|{IsComplete}";
        }
        IsComplete = "True";
        string fullData = $"{goalIndex}*{Goal}";
        return fullData;
    }
}