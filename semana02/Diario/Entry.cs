using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;

    public Entry(string date, string promptText, string entryText, string mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} | Mood: {_mood} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine();
    }
}
