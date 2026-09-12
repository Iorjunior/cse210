using System;
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
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}~|~{entry._mood}");
            }
        }
        Console.WriteLine($"Journal saved successfully to {file}.\n");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File '{file}' not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            if (parts.Length >= 3)
            {
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];
                string mood = parts.Length > 3 ? parts[3] : "Unspecified";

                _entries.Add(new Entry(date, prompt, response, mood));
            }
        }

        Console.WriteLine($"Journal loaded successfully from {file}.\n");
    }
}
