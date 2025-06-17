using System;
using System.Runtime.InteropServices;

public class Breathing : Activity
{
    public Breathing() : base("Breathing",
    "This activity will help you to practice breathing in and out in a slow, controlled manner, to help you relax. Enjoy!")
    {

    }
    public void RunActivity()
    {
        Console.WriteLine("Breath in...");
        ShowProgress(3);
        Console.WriteLine("Breath out...");
        ShowProgress(4);

        _elapsedTime = 7;
        while (_elapsedTime < _duration)
        {
            Console.WriteLine("\nBreath in...");
            ShowProgress(4);
            Console.WriteLine("Breath out...");
            ShowProgress(6);
            _elapsedTime += 10;
        }
    }
}