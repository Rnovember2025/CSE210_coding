using System;

public class Activity
{
    private string _title;
    private string _intro;
    protected int _duration;
    protected int _elapsedTime = 0;
    private ProgressBar _progress;
    public Activity(string title, string intro)
    {
        _title = title;
        _intro = intro;
        _progress = new ProgressBar("Pausing", 10);
    }
    public string GetTitle()
    {
        return $"{_title} Activity";
    }
    public void Intro()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_title} Activity!\n");
        Console.WriteLine($"{_intro}\n");

        PromptForDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowProgress(5);
        Console.WriteLine("\n");

    }
    private void PromptForDuration()
    {
        Console.Write("Enter approximately how long (in seconds) you would like to do this activity for >>> ");
        while (true)
        {
            string response = Console.ReadLine();
            try
            {
                _duration = int.Parse(response);
                return;
            }
            catch
            {
                Console.Write("Invalid Response. Try again >>> ");
            }
        }
    }
    public void Outro()
    {
        Console.WriteLine("\nWell Done!\n");
        Console.WriteLine($"You have completed {_elapsedTime} seconds of the {_title} activity");
        ShowProgress(5);
        Console.Clear();
    }
    protected void ShowProgress(long time_duration)
    {
        _progress.ShowProgress(0);
        time_duration = time_duration * TimeSpan.TicksPerSecond;
        long startTime = DateTime.Now.Ticks;
        long elapsedTime;
        do
        {
            elapsedTime = DateTime.Now.Ticks - startTime;
            if (elapsedTime % (TimeSpan.TicksPerSecond / 50) == 0)
            {
                _progress.Remove();
                _progress.ShowProgress((double)elapsedTime / time_duration);
            }

        } while (elapsedTime < time_duration);
        _progress.Remove();
    }    
}