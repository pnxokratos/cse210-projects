using System.IO;
using static System.Console;
using System.Diagnostics;

class MainMenuclass
{
    List<string> AccountData = new List<string>();
    List<string> NewData = new List<string>();
    string userChoice;
    public List<string> MainMenu(List<string> AccountData)
    {
        NewData.Add(AccountData[0]);
        NewData.Add(AccountData[1]);
        NewData.Add(AccountData[2]);
        NewData.Add(AccountData[3]);
        NewData.Add(AccountData[4]);
        while(true)
        {
            DisplayMainMenu();
            userChoice = ReadLine();

            if(userChoice == "0")
            {
                //quit the program.
                break;
            }
            else if(userChoice == "1")
            {
                //Go to user settings menu.
                Settings settings = new Settings();
                NewData = settings.SettingsMenu(AccountData);
            }
            else if(userChoice == "2")
            {
                //Go to library activity
                Library library = new Library();
                NewData = library.libraryMenu(AccountData);
            }
            else
            {
                WriteLine("Sorry I don't understand that input. Please try again.");
                Thread.Sleep(3000);
            }
            AccountData = NewData;
        }
        return NewData;
    }

    private void DisplayMainMenu()
    {
        Clear();
        WriteLine("Main Menu");
        WriteLine("---------------");
        WriteLine("  0. Quit.");
        WriteLine("  1. Settings");
        WriteLine("  2. Library");
        WriteLine("---------------");
    }
}