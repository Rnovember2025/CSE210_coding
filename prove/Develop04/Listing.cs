using System;

public class Listing : Activity
{
    private string _filePath;
    private int _previousPromptIndex;
    private List<string> _dataToWrite = new List<string>();
    private Random rand = new Random();
    private List<string> _prompts = new List<string>{"Who are people that you appreciate?",
                                                     "What are personal strengths of yours?",
                                                     "Who are people that you have helped this week?",
                                                     "When have you felt the Holy Ghost this month?",
                                                     "Who are some of your personal heroes?"};
    public Listing() : base("Listing",
    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _filePath = Environment.CurrentDirectory + "/previous.txt";
        string[] lines = System.IO.File.ReadAllLines(_filePath);
        foreach (string line in lines)
        {
            string[] lineData = line.Split(':');
            if (lineData[0] == "Listing")
            {
                _previousPromptIndex = int.Parse(lineData[1]);
            }
            else
            {
                _dataToWrite.Add($"{lineData[0]}:{lineData[1]}");
            }
        }
    }
    public void RunActivity()
    {
        Console.WriteLine("List as many responses to the following prompt as you can.");
        int i;
        do
        {
            i = rand.Next(0, _prompts.Count());
        } while (i == _previousPromptIndex);
        WriteToFile(i);
        Console.WriteLine($"  === {_prompts[i]} ===");
        Console.WriteLine("\nBegin Brainstorming...");
        ShowProgress(8);

        DateTime _startTime = DateTime.Now;
        _elapsedTime = 5;
        int responses = 0;

        while (_elapsedTime < _duration)
        {
            Console.Write("\n > ");
            Console.ReadLine();
            responses++;
            _elapsedTime = 5 + (int)DateTime.Now.Subtract(_startTime).TotalSeconds;
        }
        Console.WriteLine($"\nYou entered {responses} responses to the question.");
    }
    private void WriteToFile(int index)
    {
        using (StreamWriter saveFile = new StreamWriter(_filePath, false))
        {
            foreach (string line in _dataToWrite)
            {
                saveFile.WriteLine(line);
            }
            saveFile.WriteLine($"Listing:{index}");
        }
    }
}