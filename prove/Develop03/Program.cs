using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        Console.Clear();
        Console.WriteLine(scripture.GetFullText());

        while (true)
        {
            Console.WriteLine("Press ENTER to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWord();
            Console.Clear();
            Console.WriteLine(scripture.GetHiddenText());

            if (scripture.AllWordsHidden())
            {
                break;
            }
        }
    }
}

class Scripture
{
    private string reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.words = new List<Word>();

        string[] verses = text.Split(new string[] { ".", "!" }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string verse in verses)
        {
            string[] verseParts = verse.Split(' ');

            int verseNumber = 0;

            foreach (string part in verseParts)
            {
                if (part.Contains(":"))
                {
                    string[] referenceParts = part.Split(':');
                    int.TryParse(referenceParts[1], out verseNumber);
                }
                else
                {
                    words.Add(new Word(part, verseNumber));
                }
            }
        }
    }

    public void HideRandomWord()
    {
        List<Word> unhiddenWords = GetUnhiddenWords();
        Random random = new Random();
        int randomIndex = random.Next(0, unhiddenWords.Count);
        unhiddenWords[randomIndex].Hide();
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    public string GetFullText()
    {
        string fullText = reference + "\n\n";

        foreach (Word word in words)
        {
            fullText += word.GetText() + " ";
        }

        return fullText.Trim();
    }

    public string GetHiddenText()
    {
        string hiddenText = reference + "\n\n";

        foreach (Word word in words)
        {
            if (word.IsHidden())
            {
                hiddenText += "_____ ";
            }
            else
            {
                hiddenText += word.GetText() + " ";
            }
        }

        return hiddenText.Trim();
    }

    private List<Word> GetUnhiddenWords()
    {
        List<Word> unhiddenWords = new List<Word>();

        foreach (Word word in words)
        {
            if (!word.IsHidden())
            {
                unhiddenWords.Add(word);
            }
        }

        return unhiddenWords;
    }
}

class Reference
{
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(int chapter, int startVerse, int endVerse = 0)
    {
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetFormattedReference()
    {
        if (endVerse > 0)
        {
            return "Proverbs " + chapter + ":" + startVerse + "-" + endVerse;
        }
        else
        {
            return "Proverbs " + chapter + ":" + startVerse;
        }
    }
}

class Word
{
    private string text;
    private int verseNumber;
    private bool isHidden;

    public Word(string text, int verseNumber)
    {
        this.text = text;
        this.verseNumber = verseNumber;
        this.isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetText()
    {
        return text;
    }
}
