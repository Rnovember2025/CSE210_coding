public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int basePoints, bool done) : base(name, description, basePoints, done)
    {
    }
    public override string GetGoalStringSave()
    {
        char t = Constants.TypeSplitChar;
        char i = Constants.InfoSplitChar;
        return $"{Constants.SimpleGoalID}{t}{_name}{i}{_description}{i}{_basePoints}{i}{_done}";
    }
    public override int AccomplishGoal()
    {
        _done = true;
        return _basePoints;
    }
}