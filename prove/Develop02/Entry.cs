using System;

class Entry {
    public string _date = "";
    public string _prompt = "";
    public string _response = "";

    public void PrintEntry() {
        Console.WriteLine(_date);
        Console.WriteLine(_prompt);
        Console.WriteLine(_response);
        Console.Write("\n\n");
    }
}