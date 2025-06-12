using System;
using System.ComponentModel.DataAnnotations;

public class ProgressBar
{
    private int _length;
    private string _description;
    public ProgressBar(string description, int length)
    {
        _description = description;
        _length = length;
    }
    public void ShowProgress(double percentage)
    {
        int filledLength = (int)(_length * percentage);
        if (filledLength > _length) { filledLength = _length; }
        string fullPortion = new string('#', filledLength);
        string emptyPortion = new string('.', _length - filledLength);
        Console.Write($"{_description}: [{fullPortion}{emptyPortion}]");
    }
    public void Remove()
    {
        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
    }
}