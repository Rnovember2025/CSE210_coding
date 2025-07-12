using System.Linq.Expressions;

public class AdditionOpperator : Opperator
{
    private bool _isInverse;
    public AdditionOpperator() : base("ADD") { }
    public override string GetDisplayFormat()
    {
        string formattedString = "";
        foreach (EquationElement element in _children)
        {
            switch (element.GetElementType())
            {
                case "SYMBOL":
                case "INT":
                    formattedString += element.IsNegative() ? "-" : "+";
                    formattedString += element.IsReciprocal() ? "1/" : "";
                    formattedString += element.GetDisplayFormat();
                    break;
                case "MULTIPLY":
                    formattedString += element.IsNegative() ? "-" : "+";
                    formattedString += element.GetDisplayFormat();
                    break;
                default:
                    break;
            }
        }
        formattedString = formattedString[0] == '+' ? formattedString.Substring(1, formattedString.Count() - 1) : formattedString;
        return $"({formattedString})";
    }
    public override void Negate()
    {
        foreach (EquationElement element in _children)
        {
            element.Negate();
        }
    }
    public override bool IsNegative()
    {
        return false;
    }
    public override void Reciprocate()
    {
        _isInverse = !_isInverse;
    }
    public override bool IsReciprocal()
    {
        return _isInverse;
    }
    public override List<int> GetHitBox()
    {
        return new List<int>();
    }
}