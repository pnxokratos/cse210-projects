using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
//This is the code for my W02 Assignment CSE210
//Author: Jorge Leonardo Hernandez Gutierrez
namespace JournalApp 
{
//Main class
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Journal App");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                string choiceStr = Console.ReadLine();
                if (!int.TryParse(choiceStr, out int choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    continue;
                }
                //Option menu
                switch (choice)
                {
                    case 1:
                        journal.AddEntry();
                        break;
                    case 2:
                        journal.DisplayEntries();
                        break;
                    case 3:
                        journal.SaveJournal();
                        break;
                    case 4:
                        journal.LoadJournal();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }
    }
// Journal class
    class Journal
    {
        private List<Entry> entries = new List<Entry>();
        private string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        //Entry input by user
        public void AddEntry()
        {
            Console.WriteLine("New Entry:");
            Console.WriteLine(GetRandomPrompt());
            Console.Write("> ");
            string response = Console.ReadLine();
            Entry entry = new Entry(GetRandomPrompt(), response, DateTime.Now);
            entries.Add(entry);
            Console.WriteLine("Entry saved.");
        }
        //It displays the entries and adds date
        public void DisplayEntries()
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine($"[{entry.Date}] {entry.Prompt}");
                Console.WriteLine(entry.Response);
                Console.WriteLine();
            }
        }
        //Generates JSON file
        public void SaveJournal()
        {
            Console.Write("Enter filename: ");
            string filename = Console.ReadLine();

            try
            {
                using (FileStream stream = File.Create(filename))
                {
                    JsonSerializer.SerializeAsync<List<Entry>>(stream, entries).Wait();
                }
                Console.WriteLine($"Journal saved to {filename}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving journal: {ex.Message}");
            }
        }
        //Loanding JSON
        public void LoadJournal()
        {
            Console.Write("Enter filename: ");
            string filename = Console.ReadLine();
            try
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    entries = JsonSerializer.DeserializeAsync<List<Entry>>(stream).Result;
                }
                Console.WriteLine($"Journal loaded from {filename}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error loading journal: {ex.Message}");
            }
        }
        // Prompt generator
        private string GetRandomPrompt()
        {
            Random random = new Random();
            return prompts[random.Next(prompts.Length)];
        }
    }
// Entry class
    class Entry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public DateTime Date { get; set; }
        public Entry(string prompt, string response, DateTime date)
        {
            Prompt = prompt;
            Response = response;
        }
    }
}