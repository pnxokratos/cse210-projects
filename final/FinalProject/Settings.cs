using static System.Console;

class Settings
{
    List<string> AccountData = new List<string>();
    string userChoice;
    public List<string> SettingsMenu(List<string> AccountData)
    {
        List<string> NewData = new List<string>();

        while(true)
        {
            NewData = AccountData;
            DisplaySettingsMenu();
            userChoice = ReadLine();

            if (userChoice == "0")
            {
                break;
            }
            else if (userChoice == "1")
            {
                DisplayInfo(AccountData);
            }
            else if (userChoice == "2")
            {
                NewData = ChangeInfo(AccountData);
                AccountData = NewData;
            }
            else
            {
                WriteLine("Sorry I don't understand that input. Please try again.");
                Thread.Sleep(3000);
            }
        }

        return NewData;
    }
    public void DisplayInfo(List<string> AccountData)
    {
        Clear();
        CommonComands common = new CommonComands();
        string AccountNumber = common.GetAccountNumber(AccountData);
        WriteLine($"Account Number: {AccountNumber}");

        string AccountPassword = common.GetAccountPassword(AccountData);
        WriteLine($"AccountPassword: {AccountPassword}");

        string usernameFirst = common.GetusernameFirst(AccountData);
        WriteLine($"First Name: {usernameFirst}");

        string usernameLast = common.GetusernameLast(AccountData);
        WriteLine($"Last Name: {usernameLast}");

        WriteLine("Press Enter when done.");
        ReadLine();
    }
    public List<string> ChangeInfo(List<string> AccountData)
    {
        List<string> NewData = new List<string>();

        string OldAccountNumber = AccountData[0];
        string NewAccountNumber = AccountData[0];
        string NewAccountPassword = AccountData[1];
        string NewFirstName = AccountData[2];
        string NewLastName = AccountData[3];

        while(true)
        {
            Clear();
            WriteLine("What would you like to change?");
            WriteLine("------------------------------");
            WriteLine("  0. Back.");
            WriteLine("  1. Account Number.");
            WriteLine("  2. AccountPassword.");
            WriteLine("  3. First Name.");
            WriteLine("  4. Last Name.");
            WriteLine("------------------------------");
            userChoice = ReadLine();

            if (userChoice == "0")
            {
                NewData.Add(NewAccountNumber);
                NewData.Add(NewAccountPassword);
                NewData.Add(NewFirstName);
                NewData.Add(NewLastName);
                NewData.Add(AccountData[4]);
                break;
            }
            else if(userChoice == "1")
            {
                Write("What is your new Account Number: ");
                NewAccountNumber = ReadLine();
            }
            else if (userChoice == "2")
            {
                Write("What is your new Account Password: ");
                NewAccountPassword = ReadLine();
            }
            else if (userChoice == "3")
            {
                Write("What is your new First Name: ");
                NewFirstName = ReadLine();
            }
            else if (userChoice == "4")
            {
                Write("What is your new Last Name: ");
                NewLastName = ReadLine();
            }
            else
            {
                WriteLine("Sorry I don't understand that input. Please try again.");
            }
        }
        CommonComands common = new CommonComands();
        common.UpdateAccountData(OldAccountNumber, NewData);

        WriteLine("Warning: Go back to main menu to save changes.");
        Thread.Sleep(3000);
        return NewData;
    }
    private void DisplaySettingsMenu()
    {
        Clear();
        WriteLine("Settings Menu");
        WriteLine("-------------------");
        WriteLine("  0. Back.");
        WriteLine("  1. View info.");
        WriteLine("  2. Change info.");
        WriteLine("-------------------");
    }
}