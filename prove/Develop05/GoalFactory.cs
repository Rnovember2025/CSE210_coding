public class GoalFactory
{
    private string _tempName;
    private string _tempDescription;
    private int _tempBasePoints;
    private int _tempNecessarySuccesses;
    private int _tempBonusPoints;
    private DateTime _date = DateTime.Now;
    public Goal MakeGoal(string goalType)
    {
        GetStandardGoalInfo();
        switch (goalType)
        {
            case "SIMPLE":
                return new SimpleGoal(_tempName, _tempDescription, _tempBasePoints, false);
            case "ETERNAL":
                return new EternalGoal(_tempName, _tempDescription, _tempBasePoints);
            case "CHECKLIST":
                GetChecklistGoalInfo();
                return new ChecklistGoal(_tempName, _tempDescription, _tempBasePoints, _tempNecessarySuccesses, 0, _tempBonusPoints);
            case "STREAK":
                GetStreakGoalInfo();
                return new StreakGoal(_tempName, _tempDescription, _tempBasePoints, _tempNecessarySuccesses, 0, _date.ToShortDateString());
            default:
                return new EternalGoal("Blank", "Blank", 0);
        }
    }
    private void GetStandardGoalInfo() {
        Console.Write("What is the name of your goal? >>> ");
        _tempName = Console.ReadLine();
        Console.Write("What is a short description of your goal? >>> ");
        _tempDescription = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? >>> ");
        _tempBasePoints = int.Parse(Console.ReadLine());
    }
    private void GetStreakGoalInfo()
    {
        Console.Write("How many days long is the streak? >>> ");
        _tempNecessarySuccesses = int.Parse(Console.ReadLine());
    }
    private void GetChecklistGoalInfo() {
        Console.Write("How many times does this goal need to be accomplished for a bonus? >>> ");
        _tempNecessarySuccesses = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? >>> ");
        _tempBonusPoints = int.Parse(Console.ReadLine());
    }
    public Goal MakeGoalFromString(string infoString)
    {
        string[] mainSegments = infoString.Split(Constants.TypeSplitChar);
        string[] parts = mainSegments[1].Split(Constants.InfoSplitChar);
        switch (mainSegments[0])
        {
            case Constants.SimpleGoalID:
                return new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
            case Constants.EternalGoalID:
                return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
            case Constants.ChecklistGoalID:
                return new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
            case Constants.StreakGoalID:
                return new StreakGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), parts[5]);
            default:
                throw new Exception("Specified goal type doesn't exist.");
        }
    }
}