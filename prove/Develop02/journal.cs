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
        Console.WriteLine("\n--- Journal Entries ---");
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
        }
        else
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
        Console.WriteLine("-----------------------\n");
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
    }
    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _prompt = parts[1],
                    _response = parts[2]
                };
                _entries.Add(entry);
            }
        }
    }
}