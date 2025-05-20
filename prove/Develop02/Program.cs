using System;

// The creative addition that I included in this project
// is the Journal Class tracking whether it is saved or not,
// and the main program alerting the user when they are going
// to overwrite data. This allows a user friendly and flexible
// system that doesn't require the user to keep in mind when
// they are working on an unsaved or saved journal.

// Examples of how this system is user friendly and flexible:
//   - Users can write entries without having previously loaded
//     a journal file. 
//   - If the user requests to load a journal file, or to quit
//     the program, they are prompted if they would like to save
//     their unsaved changes. If there are no unsaved changes,
//     no prompt is shown.
//   - When a user loads a journal from a file, the Journal Class
//     saves the file location, and when the user saves the file,
//     it is saved to that file location.
//   - When a user saves a journal that was not loaded from a
//     journal file, they are prompted for a file name. If the
//     file already exists, then the entries they entered are
//     appended to the end of the file. If the file doesn't
//     exist, a new file is created.

class Program
{
    static Menu _mainMenu = new Menu();
    static Menu _saveOrNotMenu = new Menu();
    static Journal _currentJournal = new Journal();
    static Prompt _prompts = new Prompt();
    static DateTime _currentDate = DateTime.Now;

    static void Main(string[] args)
    {
        _saveOrNotMenu._menuOptions = new List<string> { "1: Save", "2: Discard Changes" };
        _saveOrNotMenu._validInputs = new List<int> { 1, 2 };
        bool running = true;
        int userInput;
        List<string> userResponse;

        Console.WriteLine("Welcome to the RIC Journal Editor\n\n");

        while (running)
        {
            userInput = _mainMenu.GetInput();

            switch (userInput)
            {
                case 1:
                    userResponse = _prompts.GetResponse();
                    _currentJournal.InsertEntry(_currentDate.ToShortDateString(), userResponse[0], userResponse[1]);
                    break;
                case 2:
                    if (!_currentJournal._saved) // Check for unsaved changes. Exceeds Requirements
                    {
                        Console.WriteLine("!! You have unsaved Changes !!");
                        int toSave = _saveOrNotMenu.GetInput();
                        if (toSave == 1)
                        {
                            _currentJournal.Save();
                        }
                    }
                    Console.WriteLine("(file to load from)");
                    _currentJournal.Load();
                    break;
                case 3:
                    _currentJournal.Save();
                    break;
                case 4:
                    _currentJournal.Print();
                    break;
                case 5:
                    if (!_currentJournal._saved) // Check for unsaved changes. Exceeds Requirements
                    {
                        Console.WriteLine("!! You have unsaved Changes !!");
                        int toSave = _saveOrNotMenu.GetInput();
                        if (toSave == 1)
                        {
                            _currentJournal.Save();
                        }
                    }
                    running = false;
                    break;
            }
        }
    }
}