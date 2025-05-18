using System;
using System.IO;

class Journal {
    public List<Entry> _journalEntries = new List<Entry>();
    public Prompt _whichFile = new Prompt();
    public string _filePath = ""; // Saves file path. Exceeds Requirements
    public bool _saved = true; // Tracks saved status. Exceeds Requirements.
    
    public Journal() {
        _whichFile._allPrompts = new List<string>{"Enter the File Path:"};
    }

    public void InsertEntry(string dateString, string promptString, string response) {
        Entry newEntry = new Entry();
        newEntry._date = dateString;
        newEntry._prompt = promptString;
        newEntry._response = response;
        _journalEntries.Add(newEntry);

        _saved = false;

    }

    public void Load() {
        _journalEntries.Clear();

        _filePath = "/home/wizard/Documents/Journal/"+_whichFile.GetResponse()[1]; 
        string[] lines = System.IO.File.ReadAllLines(_filePath);
        
        int number_of_lines = lines.Count();
        int pointer = 0;

        Entry newEntry = new Entry();

        while (pointer < number_of_lines) {
            if (lines[pointer] == "~") {
                pointer++;
                if (newEntry._date != "") {
                    _journalEntries.Add(newEntry);
                }
                newEntry = new Entry();
                newEntry._date = lines[pointer++];
                newEntry._prompt = lines[pointer++];
            }
            else {
                string split_char = "";
                if (newEntry._response != "") {
                    split_char = "\n";
                }
                newEntry._response += split_char + lines[pointer++];
                if (pointer == number_of_lines) {
                    _journalEntries.Add(newEntry);
                }
            }
        }

        _saved = true;
    }

    public void Save() {
        bool append_to_file = false;
        if (_filePath == "") {
            append_to_file = true;
            _filePath = "/home/wizard/Documents/Journal/"+_whichFile.GetResponse()[1];
        }

        if (!File.Exists(_filePath)) {
            append_to_file = false;
            File.Create(_filePath);
        }
        
        using (StreamWriter saveFile = new StreamWriter(_filePath, append_to_file)) {
            foreach (Entry e in _journalEntries) {
                saveFile.WriteLine("~");
                saveFile.WriteLine($"{e._date}\n{e._prompt}\n{e._response}");
                
            }
        }

        _saved = true;
    }
    public void Print() {
        foreach (Entry e in _journalEntries) {
            e.PrintEntry();
        }
    }
}