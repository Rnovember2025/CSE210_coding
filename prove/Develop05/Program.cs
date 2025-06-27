//My program exceeds requirements in the following ways:
//   - When recording an event, only goals that are incomplete are listed.
//     Goals you have previously accomplished are hidden.
//   - Functionality added to detect when there are unsaved changes, and
//     prompt the user if they want to save or not before data is lost.
//   - When the user loads goals from a file, the filepath is saved, and
//     when they save changes made to that data, it is saved to the same
//     filepath, without requiring them to enter the file path again.
//   - New type of goal added, the Streak Goal. This goal is similar to 
//     the checklist goal, but you have to complete it every day for a 
//     specified number of days to complete it. If you miss a day, your
//     progress is reset to zero. (Once you complete it your progress is
//     not reset to zero :-)  )
//   - The deliminating character in a save file is not an easily typable
//     one. This helps users avoid accidentaly corrupting their save file.




class Program
{
    static GoalFactory _goalFactory = new GoalFactory();
    static int _totalPoints = 0;
    static List<Goal> _goals = new List<Goal>();
    static Menu _mainMenu = new Menu(new List<string> { "List Goals", "Create Goal", "Save Goals", "Load Goals", "Record Event", "Quit" },
                                     new List<char> { '1', '2', '3', '4', '5', '6' });
    static Menu _goalTypeMenu = new Menu(new List<string> { "Simple Goal", "Eternal Goal", "Checklist Goal", "Streak Goal" },
                                         new List<char> { '1', '2', '3', '4' });
    static string _workingFile = "";
    static void Main(string[] args)
    {
        int userInput;
        bool running = true;
        while (true)
        {
            userInput = _mainMenu.PromptUser();
            switch (userInput)
            {
                case 0:
                    ListGoals();
                    break;
                case 1:
                    int goalType = _goalTypeMenu.PromptUser();
                    _goals.Add(_goalFactory.MakeGoal(Constants.GoalTypes[goalType]));
                    break;
                case 2:
                    Save();
                    break;
                case 3:
                    HandleUnsavedChanges();
                    Load();
                    break;
                case 4:
                    RecordEvent();
                    break;
                case 5:
                    HandleUnsavedChanges();
                    running = false;
                    break;
            }
            if (running == false) { break; }
            Console.WriteLine($"\n\nYou have {_totalPoints} points!\n");
        }
    }
    static void ListGoals()
    {
        if (_goals.Count() == 0)
        {
            Console.WriteLine("No goals to display. Create a goal to get started.");
        }
        else
        {
            foreach (Goal g in _goals)
            {
                Console.WriteLine(g.GetGoalStringView());
            }
        }
    }
    static void RecordEvent()
    {
        if (_goals.Count() == 0)
        {
            Console.WriteLine("No goals to display. Create a goal to get started.");
            return;
        }
        List<Goal> unfinishedGoals = new List<Goal>();
        List<string> menuOptions = new List<string>();
        List<char> validInputs = new List<char>();
        char input = 'A';
        foreach (Goal g in _goals)
        {
            if (!g.IsDone())
            {
                unfinishedGoals.Add(g);
                menuOptions.Add(g.GetGoalStringView());
                validInputs.Add(input);
                input++;
            }
        }
        Menu _recordEventMenu = new Menu(menuOptions, validInputs);
        _totalPoints += unfinishedGoals[_recordEventMenu.PromptUser()].AccomplishGoal();
    }
    static void Load()
    {
        Console.Write("Please enter a file to load from >>> ");
        _workingFile = Environment.CurrentDirectory + "/" + Console.ReadLine();
        _goals.Clear();

        List<string> lines = ReadDataFromFile();

        _totalPoints = int.Parse(lines[0]);

        foreach (string line in lines.Skip(1))
        {
            _goals.Add(_goalFactory.MakeGoalFromString(line));
        }
    }
    static void Save()
    {
        if (_workingFile == "")
        {
            Console.Write("Please enter a file to save to >>> ");
            _workingFile = Environment.CurrentDirectory + "/" + Console.ReadLine();
        }
        using (StreamWriter outputFile = new StreamWriter(_workingFile))
        {
            List<string> data = GetDataToSave();
            foreach (string s in data)
            {
                outputFile.WriteLine(s);
            }
        }
    }
    static List<string> GetDataToSave()
    {
        List<string> data = new List<string>();
        data.Add(Convert.ToString(_totalPoints));
        foreach (Goal g in _goals)
        {
            data.Add(g.GetGoalStringSave());
        }
        return data;
    }
    static List<string> ReadDataFromFile()
    {
        return new List<string>(System.IO.File.ReadAllLines(_workingFile));
    }
    static void HandleUnsavedChanges()
    {
        bool saved = true;
        if (_workingFile != "")
        {
            List<string> programData = GetDataToSave();
            List<string> savedData = ReadDataFromFile();
            if (!programData.SequenceEqual(savedData))
            {
                saved = false;
            }
        }
        else
        {
            List<string> programData = GetDataToSave();
            if (programData.Count() > 1)
            {
                saved = false;
            }
        }

        if (saved == false)
        {
            Console.Write("You have unsaved changes. Would you like to save? [y/n] >>> ");
            string save = Console.ReadLine();
            if (save == "y")
            {
                Save();
            }
        }
    }
}