public class ChecklistGoal : Goal
{
    protected int _bonusPoints;
    protected int _necessarySuccesses;
    protected int _progress;
    public ChecklistGoal(string name, string description, int basePoints, int necessarySuccesses, int progress, int bonusPoints) : base(name, description, basePoints, progress>=necessarySuccesses)
    {
        _bonusPoints = bonusPoints;
        _necessarySuccesses = necessarySuccesses;
        _progress = progress;
    }
    public override string GetGoalStringSave()
    {
        char t = Constants.TypeSplitChar;
        char i = Constants.InfoSplitChar;
        return $"{Constants.ChecklistGoalID}{t}{_name}{i}{_description}{i}{_basePoints}{i}{_necessarySuccesses}{i}{_progress}{i}{_bonusPoints}";
    }
    public override string GetGoalStringView()
    {
        return base.GetGoalStringView() + $" -- Completed {_progress}/{_necessarySuccesses}";
    }
    public override int AccomplishGoal()
    {
        if (++_progress == _necessarySuccesses)
        {
            _done = true;
            return _basePoints + _bonusPoints;
        }
        else
        {
            return _basePoints;
        }
    }
}