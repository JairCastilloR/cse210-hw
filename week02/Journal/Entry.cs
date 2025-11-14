public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    
    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public string Date => _date;
    
    public string PromptText => _promptText;
    public string EntryText => _entryText;
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }
}