using static System.Console;

class Library
{
    List<string> items = new List<string>();
    private string AccountNumber;
    private string userFirstName;
    private string userLastName;
    private string LibraryPassword;

    public List<string> StartLibrary(List<string> AccountData)
    {
        List<string> NewData = new List<string>();
        AccountNumber = AccountData[0];
        userFirstName = AccountData[2];
        userLastName = AccountData[3];
        string filename = AccountNumber;
        
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length >= 3)
            {
                LibraryPassword = lines[2];
            }
            else
            {
                Random rnd = new Random();
                int password = rnd.Next(1000, 10000);
                LibraryPassword = password.ToString();
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine(LibraryPassword);
                }
            }
        }
        NewData.Add(AccountNumber);
        NewData.Add(AccountData[1]);
        NewData.Add(userFirstName);
        NewData.Add(userLastName);
        NewData.Add(LibraryPassword);

        return NewData;
    }
    public List<string> libraryMenu(List<string> AccountData)
    {
        string AccountNumber = AccountData[0];
        string LibraryPassword = AccountData[4];
        string filename = $"{AccountNumber}{LibraryPassword}0001";
        LoadFromFile(filename);
        List<string> NewData = new List<string>();
        NewData.Add(AccountData[0]);
        NewData.Add(AccountData[1]);
        NewData.Add(AccountData[2]);
        NewData.Add(AccountData[3]);
        NewData.Add(AccountData[4]);


        while(true)
        {
            SaveToFile(filename, items);
            Clear();
            string userChoice = "";
            WriteLine("Library Menu");
            WriteLine("-----------------");
            WriteLine("  1. Add Item.");
            WriteLine("  2. Remove Item.");
            WriteLine("  3. Display Items.");
            WriteLine("  0. Quit.");
            WriteLine("-----------------");
            userChoice = ReadLine();

            if(userChoice == "1")
            {
                //Add Item To list.
                string Item = Additem();
                items.Add(Item);
            }
            else if (userChoice == "2")
            {
                //Remove Item From list.
                RemoveItem(items);
            }
            else if (userChoice == "3")
            {
                DisplayItems(items);
                WriteLine("Press enter when done.");
                ReadLine();
            }
            else if (userChoice == "0")
            {
                break;
            }
            else
            {
                WriteLine("Sorry I don't understand that input. Please try again.");
            }
        }
        
        NewData.Add(AccountNumber);
        NewData.Add(AccountData[1]);
        NewData.Add(userFirstName);
        NewData.Add(userLastName);
        NewData.Add(LibraryPassword);
        return NewData;
    }
    private string Additem()
    {
        string Item;
        string userChoice;
        while(true)
        {
            Clear();
            WriteLine("What type of item is this:");
            WriteLine("  1. DVD.");
            WriteLine("  2. Book.");
            WriteLine("  3. Magazine.");
            userChoice = ReadLine();

            if (userChoice == "1")
            {
                string Type = "DVD";
                WriteLine("What is the Title of the DVD?");
                string Title = ReadLine();
                WriteLine("Who is the Author of the Movie?");
                string Author = ReadLine();
                WriteLine("How long is the move in minutes?");
                string Time = ReadLine();
                Item = $"{Type}|{Title}|{Author}|{Time}";
                return Item;
            }
            else if (userChoice == "2")
            {
                string Type = "Book";
                WriteLine("What is the Title of the Book?");
                string Title = ReadLine();
                WriteLine("Who is the Author of the Book?");
                string Author = ReadLine();
                WriteLine("How many pages are there in the Book?");
                string PageCount = ReadLine();
                Item = $"{Type}|{Title}|{Author}|{PageCount}";
                return Item;
            }
            else if (userChoice == "3")
            {
                string Type = "Magazine";
                WriteLine("What is the Title of the Magazine?");
                string Title = ReadLine();
                WriteLine("Who is the Author of the Magazine?");
                string Author = ReadLine();
                WriteLine("What is the issue number of the Magazine?");
                string issueNumber = ReadLine();
                Item = $"{Type}|{Title}|{Author}|{issueNumber}";
                return Item;
            }
        }
    }
    private void RemoveItem(List<string> items)
    {
        DisplayItems(items);

        Write("Enter the index number of the item you want to remove: ");
        int index = int.Parse(ReadLine()) - 1;

        items.RemoveAt(index);

        WriteLine("Item Reoved.");
        DisplayItems(items);
    }
    private void DisplayItems(List<string> items)
    {
        Clear();
        int index = 1;
        foreach(string item in items)
        {
            string[] parts = item.Split("|");
            string type = parts[0];
            string title = parts[1];
            string author = parts[2];
            string other = parts[3];
            if (type == "DVD")
            {
                WriteLine($"[{index}] Type: {type}, Title: {title}, Author: {author}, Length: {other}");
            }
            else if (type == "Book")
            {
                WriteLine($"[{index}] Type: {type}, Title: {title}, Author: {author}, Number of Pages: {other}");
            }
            else if (type == "Magazine")
            {
                WriteLine($"[{index}] Type: {type}, Title: {title}, Author: {author}, Issue Number: {other}");
            }
            index += 1;
        }
    }
    private void SaveToFile(string fileName, List<string> items)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (string item in items)
            {
                sw.WriteLine(item);
            }
        }
    }
    private void LoadFromFile(string fileName)
    {
        string line;
        if (!File.Exists(fileName))
        {
            File.Create(fileName).Close();
        }

        int index = 1;
        
        foreach (string l in File.ReadAllLines(fileName))
        {
            items.Add(l);
        }

        foreach (string item in items)
        {
            string[] parts = item.Split("|");
            string type = parts[0];
            string title = parts[1];
            string author = parts[2];
            string other = parts[3];
            if (IsDVD(item))
            {
                //Process DVD item
                line = $"[{index}] Type: {type}, Title: {title}, Author: {author}, Length: {other}";
            }
            else if (IsBook(item))
            {
                //Process book Item
                line = $"[{index}] Type: {type}, Title: {title}, Author: {author}, Number of Pages: {other}";
            }
            else if (IsMagazine(item))
            {
                //Process Magazine Item
                line = $"[{index}] Type: {type}, Title: {title}, Author: {author}, Issue Number: {other}";
            }
            else
            {
                line = "";
            }
            List<string> Items = new List<string>();
            Items.Add(line);
            index += 1;
        }
    }

    private bool IsDVD(string item)
    {
        string[] parts = item.Split("|");
        string type = parts[0];
        bool isdvd;
        if (type == "DVD")
        {
            isdvd = true;
        }
        else
        {
            isdvd = false;
        }
        return isdvd;
    }
    private bool IsBook(string item)
    {
        string[] parts = item.Split("|");
        string type = parts[0];
        bool isbook;
        if (type == "DVD")
        {
            isbook = true;
        }
        else
        {
            isbook = false;
        }
        return isbook;
    }
    private bool IsMagazine(string item)
    {
        string[] parts = item.Split("|");
        string type = parts[0];
        bool ismagazine;
        if (type == "DVD")
        {
            ismagazine = true;
        }
        else
        {
            ismagazine = false;
        }
        return ismagazine;
    }
}