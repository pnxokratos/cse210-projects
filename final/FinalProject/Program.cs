using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        List<string> AccountData = new List<string>();
        string OldAccountNumber;
        List<string> NewData = new List<string>();

        Login login = new Login();
        NewData = login.LoginMenu(AccountData);
        AccountData = NewData;
        OldAccountNumber = AccountData[0];

        MainMenuclass menu = new MainMenuclass();
        NewData = menu.MainMenu(AccountData);
        AccountData = NewData;
    }
}