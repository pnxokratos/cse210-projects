using System;
using static System.Console;

class UserInfo
{
    private string _FirstName = "Null";
    private string _LastName = "Null";
    private string _AccountNumber = "Null";
    private string _Password = "Null";

    //getters
    public string GetFirstName()
    {
        return _FirstName;
    }
    public string GetLastName()
    {
        return _LastName;
    }
    public string GetAccountNumber()
    {
        return _AccountNumber;
    }
    public string GetPassword()
    {
        return _Password;
    }

    //Setters
    public void SetFirstName(string NewFirstName)
    {
        _FirstName = NewFirstName;
    }
    public void SetLastName(string NewLastName)
    {
        _LastName = NewLastName;
    }
    public void SetAccountNumber(string NewAccountNumber)
    {
        _AccountNumber = NewAccountNumber;
    }
    public void SetPassword(string NewPassword)
    {
        _Password = NewPassword;
    }
}