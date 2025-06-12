using System;

/*
My program exceeds requirements in the following ways.
   > My code makes sure that no prompt is used more than once in a row.
   > My code will only use each question in the Reflecting Activity once, and if it runs out, it ends the activity.
   > My code uses exception handling to make sure that the user doesn't accidentaly crash the program.
   > My code displays the actual time the user spent on each activity, instead of the approximate time they entered.
      > The activities don't necessarily conclude exactly in the time frame the user specifies.
      > Example: The Listing activity will wait for at least one response, and if the user takes 5 minutes to enter a response, the program will display that time.
*/
class Program
{
    static void Main(string[] args)
    {
        Menu _menu = new Menu(new List<string> { "Quit", "Breathing Activity", "Reflecting Activity", "Listing Activity" },
                              new List<char> { '1', '2', '3', '4' });

        int userInput = 1;
        while (userInput != 0)
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
            }
        }
    }
}