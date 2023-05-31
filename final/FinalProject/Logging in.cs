using static System.Console;

class LoggingIn
{
    public void SetAccountData(string AccountNumber)
    {

    }
    public List<string> CreateAccount()
    {
        int intCreateAccountNumber;
        string CreateAccountPassword;
        while(true)
        {
            Write("What is your account number (ex: 1234): ");
            string CreateAccountNumber = ReadLine();
            if (int.TryParse(CreateAccountNumber, out   intCreateAccountNumber))
            {
                if (intCreateAccountNumber >= 1000)
                {
                    if (intCreateAccountNumber <= 9999)
                    {
                        break;
                    }
                    else
                    {
                        WriteLine("Sorry, that value is invalid. Please try again.");
                        Thread.Sleep(3000);
                    }
                }
                else
                {
                    WriteLine("Sorry, that value is invalid. Please try again.");
                    Thread.Sleep(3000);
                }
            }
            else
            {
                WriteLine("Sorry, that value is invalid. Please try again.");
                Thread.Sleep(3000);
            }
        }
        string AccountNumber = intCreateAccountNumber.ToString();

        Write("What is the Password to your account: ");
        CreateAccountPassword = ReadLine();
        
        string AccountPassword = CreateAccountPassword;

        Write("What is your First Name: ");
        string usernameFirst = ReadLine();

        Write("What is your Last Name: ");
        string usernameLast = ReadLine();

        List<string> AccountData = new List<string>();
        AccountData.Add(AccountNumber);
        AccountData.Add(AccountPassword);
        AccountData.Add(usernameFirst);
        AccountData.Add(usernameLast);
        List<string> NewData = new List<string>();

        using (StreamWriter sw = new StreamWriter(AccountNumber))
        {
            sw.WriteLine("File Created");
        }

        Library library = new Library();
        NewData = library.StartLibrary(AccountData);
        AccountData = NewData;
        string LibraryPassword = AccountData[4];

        using (StreamWriter sw = new StreamWriter(AccountNumber))
        {
            string line1 = $"{AccountNumber}|{AccountPassword}";
            sw.WriteLine(line1);
            string line2 = $"{usernameFirst}|{usernameLast}";
            sw.WriteLine(line2);
            string line3 = $"{LibraryPassword}";
            sw.WriteLine(line3);
        }

        NewData = LoggingInProcess(AccountNumber);

        WriteLine("Account successfully created.");
        Thread.Sleep(3000);
        return NewData;
    }

    public List<string> loginToAccount()
    {
        List<string> NewData = new List<string>();
        string AccountNumber;
        while(true)
        {
            Clear();
            //ask the user for their username and password.
            Write("Account Number: ");
            AccountNumber = ReadLine();
            Write("Password: ");
            string AccountPassword = ReadLine();

            //Check to see if it matches any files.
            if (CheckAccount(AccountNumber, AccountPassword, Environment.CurrentDirectory))
            {
                WriteLine("Logging in...");

                List<string> AccountInfo = LoggingInProcess(AccountNumber);
                UserInfo userinfo = new UserInfo();
                userinfo.SetFirstName(AccountInfo[2]);
                userinfo.SetLastName(AccountInfo[3]);

                string firstName = userinfo.GetFirstName();
                string lastName = userinfo.GetLastName();
                WriteLine("Login successful.");
                Thread.Sleep(1000);
                WriteLine($"Welcome back {firstName} {lastName}.");
                Thread.Sleep(3000);

                NewData = LoggingInProcess(AccountNumber);

                break;
            }
            else
            {
                WriteLine("Invalid Account Number or Password.");
                Thread.Sleep(3000);
            }
        }
        return NewData;
    }

    public bool CheckAccount(string AccountNumber, string AccountPassword, string directoryPath)
    {
        foreach (string filePath in Directory.GetFiles(directoryPath))
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length > 0 && lines[0] == $"{AccountNumber}|{AccountPassword}")
            {
                return true;
            }
        }
        return false;
    }

    public List<string> LoggingInProcess(string AccountNumber)
    {
        string filePath = Path.Combine(Environment.CurrentDirectory, AccountNumber);
        List<string> accountInfo = new List<string>();
        string[] lines = File.ReadAllLines(filePath);
        accountInfo.Add(lines[0].Split("|")[0]);
        accountInfo.Add(lines[0].Split("|")[1]);
        accountInfo.Add(lines[1].Split("|")[0]);
        accountInfo.Add(lines[1].Split("|")[1]);
        accountInfo.Add(lines[2].Split("|")[0]);
        return accountInfo;
    }
}