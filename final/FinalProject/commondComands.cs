using static System.Console;
using System.IO;

class CommonComands
{
    private string AccountNumber;
    private string AccountPassword;
    private string usernameFirst;
    private string usernameLast;

    public string GetAccountNumber(List<string> AccountData)
    {
        AccountNumber = AccountData[0];
        return AccountNumber;
    }
    public string GetAccountPassword(List<string> AccountData)
    {
        AccountPassword = AccountData[1];
        return AccountPassword;
    }
    public string GetusernameFirst(List<string> AccountData)
    {
        usernameFirst = AccountData[2];
        return usernameFirst;
    }
    public string GetusernameLast(List<string> AccountData)
    {
        usernameLast = AccountData[3];
        return usernameLast;
    }
    public void UpdateAccountData(string OldAccountNumber, List<string> AccountData)
    {
        string AccountNumber = AccountData[0];
        string FilePath = Path.Combine(Directory.GetCurrentDirectory(), OldAccountNumber);

        if (File.Exists(FilePath))
        {
            string line1 = $"{AccountData[0]}|{AccountData[1]}";
            string line2 = $"{AccountData[2]}|{AccountData[3]}";
            string line3 = $"{AccountData[4]}";

            string[] newLines = {line1, line2, line3};

            File.WriteAllLines(FilePath, newLines);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
        string oldname = OldAccountNumber;
        string newname = AccountData[0];
        File.Move(oldname, newname);
    }
}