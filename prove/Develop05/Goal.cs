public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _basePoints;
    protected bool _done;
    public Goal(string name, string description, int basePoints, bool done)
    {
        _name = name;
        _description = description;
        _basePoints = basePoints;
        _done = done;
    }
    public virtual string GetGoalStringView()
    {
        char[] check = { ' ', '#' };
        return $"[{check[Convert.ToInt32(_done)]}] {_name} ({_description})";
    }
    public abstract string GetGoalStringSave();
    public abstract int AccomplishGoal();
    public bool IsDone()
    {
        return _done;
    }
}