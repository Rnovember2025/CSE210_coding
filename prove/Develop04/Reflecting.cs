using System;
using System.Timers;

public class Reflecting : Activity
{
    private string _filePath = "";
    private int _previousPromptIndex;
    private List<string> _dataToWrite = new List<string>();
    private int _thinkingTime = 10;
    private Random rand = new Random();
    private List<string> _prompts = new List<string>{"Think of a time you did something really difficult.",
                                             "Think of a time you showed courage.",
                                             "Think of a moment you pressed on when tempted to quit.",
                                             "Think of a time when you stood up for someone else.",
                                             "Think of a time when you helped someone in need.",
                                             "Think of a time when you did something truly selfless." };
    private List<string> _questions = new List<string>{"Why was this experience meaningful to you?",
                                                 "Have you ever done anything like this before?",
                                                 "How did you get started?",
                                                 "How did you feel when it was complete?",
                                                 "What made this time different than other times when you were not as successful?",
                                                 "What is your favorite thing about this experience?",
                                                 "What could you learn from this experience that applies to other situations?",
                                                 "What did you learn about yourself through this experience?",
                                                 "How can you keep this experience in mind in the future?" };
    public Reflecting() : base("Reflecting",
    "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _filePath = Environment.CurrentDirectory + "/previous.txt";
        string[] lines = System.IO.File.ReadAllLines(_filePath);
        foreach (string line in lines)
        {
            string[] lineData = line.Split(':');
            if (lineData[0] == "Reflecting")
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
        Console.WriteLine("Consider the following Prompt:");
        int i;
        do
        {
            i = rand.Next(0, _prompts.Count());
        } while (i == _previousPromptIndex);
        WriteToFile(i);
        Console.WriteLine($"  === {_prompts[i]} ===");
        Console.WriteLine("\nWhen you are ready, press enter.");
        Console.ReadLine();
        Console.WriteLine("\nNow ponder each of the following questions about your experience.");
        ShowProgress(5);
        Console.Clear();

        List<int> indexesUsed = new List<int>();

        while (_elapsedTime < _duration)
        {
            if (indexesUsed.Count() == _questions.Count())
            {
                Console.WriteLine("\nThat is the end of the questions.");
                break;
            }

            int j = rand.Next(0, _questions.Count());
            if (indexesUsed.Contains(j))
            {
                continue;
            }

            indexesUsed.Add(j);
            Console.WriteLine($" > {_questions[j]}");
            ShowProgress(_thinkingTime);
            _elapsedTime += _thinkingTime;
        }
    }
    private void WriteToFile(int index)
    {
        using (StreamWriter saveFile = new StreamWriter(_filePath, false))
        {
            foreach (string line in _dataToWrite)
            {
                saveFile.WriteLine(line);
            }
            saveFile.WriteLine($"Reflecting:{index}");
        }
    }
}