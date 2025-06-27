public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int basePoints) : base(name, description, basePoints, false)
    {
    }
    public override string GetGoalStringSave()
    {
        char t = Constants.TypeSplitChar;
        char i = Constants.InfoSplitChar;
        return $"{Constants.EternalGoalID}{t}{_name}{i}{_description}{i}{_basePoints}";
    }
    public override int AccomplishGoal()
    {
        return _basePoints;
    }
}