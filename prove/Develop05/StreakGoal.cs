using System.Globalization;
public class StreakGoal : ChecklistGoal
{
    private DateTime _previousDate;
    private DateTime _currentDate = DateTime.Now;
    public StreakGoal(string name, string description, int basePoints, int necessarySuccesses, int progress, string dateString) : base(name, description, basePoints, necessarySuccesses, progress, 1)
    {
        _previousDate = DateTime.ParseExact(dateString, CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, null);
        if (_progress < _necessarySuccesses)
        {
            double timeDif = _currentDate.Subtract(_previousDate).Days;
            if (timeDif > 1)
            {
                _progress = 0;
            }
        }
    }
    public override string GetGoalStringSave()
    {
        char t = Constants.TypeSplitChar;
        char i = Constants.InfoSplitChar;
        return $"{Constants.StreakGoalID}{t}{_name}{i}{_description}{i}{_basePoints}{i}{_necessarySuccesses}{i}{_progress}{i}{_previousDate.ToShortDateString()}";
    }
    public override string GetGoalStringView()
    {
        return base.GetGoalStringView() + " -- {Streak Goal}";
    }
    public override int AccomplishGoal()
    {
        _previousDate = DateTime.Now;
        int pointsEarned = base.AccomplishGoal();
        if (pointsEarned > _basePoints) { return _basePoints; }
        else { return 0; }
    }
}