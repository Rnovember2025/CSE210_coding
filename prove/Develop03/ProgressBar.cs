using System;
using System.ComponentModel.DataAnnotations;

public class ProgressBar
{
    public void ShowProgress(double percentage, int length)
    {
        int filledLength = (int)(length * percentage);
        if (filledLength > length) { filledLength = length; }
        string fullPortion = new string('#', filledLength);
        string emptyPortion = new string('.', length - filledLength);
        Console.WriteLine($"Progress: [{fullPortion}{emptyPortion}]");
    }
}