using System.Collections.Generic;
using System.IO;
public class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (var entry in _entries)
            {
                outputFile.WriteLine($"{entry.Date}|{entry.PromptText}|{entry.EntryText}");
            }
            string message = "It's your new file";
            outputFile.WriteLine($"{message}");
        }
        Console.WriteLine($"Journal saved to {file}");
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                AddEntry(new Entry(parts[0], parts[1], parts[2]));
            }
        }
        Console.WriteLine($"{_entries.Count} entries loaded from {file}:");
        DisplayAll(); 
    }

    public void SaveToCsv(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (var entry in _entries)
            {
                string line = $"{EscapeForCsv(entry.Date)},{EscapeForCsv(entry.PromptText)},{EscapeForCsv(entry.EntryText)}";
                outputFile.WriteLine(line);
            }
        }
        Console.WriteLine($"Journal saved to CSV file: {file}");
    }

    public void LoadFromCsv(string file)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 3)
            {
                AddEntry(new Entry(parts[0], parts[1], parts[2]));
            }
        }

        Console.WriteLine($"{_entries.Count} entries loaded from CSV file: {file}:");
        DisplayAll();
    }

    private string EscapeForCsv(string value)
    {
        if (value.Contains("\""))
        {
            value = value.Replace("\"", "\"\"");
        }
        if (value.Contains(",") || value.Contains("\""))
        {
            value = $"\"{value}\"";
        }
        return value;
    }
}