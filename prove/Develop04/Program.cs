using System;
using System.ComponentModel.Design;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        Menu _menu = new Menu(new List<string>{"Quit", "Breathing Activity", "Reflecting Activity", "Listing Activity"},
                              new List<char> {'1','2','3','4'});

        int userInput = 1;
        while (userInput!=0)
        {
            userInput = _menu.PromptUser();
            switch (userInput)
            {
                case 1:
                    Breathing breathingActivity = new Breathing();
                    breathingActivity.Intro();
                    breathingActivity.RunActivity();
                    breathingActivity.Outro();
                    break;
                case 2:
                    Reflecting reflectingActivity = new Reflecting();
                    reflectingActivity.Intro();
                    reflectingActivity.RunActivity();
                    reflectingActivity.Outro();
                    break;
                case 3:
                    Listing listingActivity = new Listing();
                    listingActivity.Intro();
                    listingActivity.RunActivity();
                    listingActivity.Outro();
                    break;
                default:
                    break;
            }
        }
    }
}