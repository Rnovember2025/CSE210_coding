public class EqualSignOpperator : Opperator
{
    public EqualSignOpperator() : base("EQUALS") { }
    public override string GetDisplayFormat()
    {
        string formattedString = "";

        switch (_children.Count())
        {
            case 0:
                formattedString = "0=0";
                break;
            case 1:
                formattedString += _children[0].IsNegative() ? "-" : "";
                formattedString += _children[0].IsReciprocal() ? "1/" : "";
                formattedString += _children[0].GetDisplayFormat() + "=0";
                break;
            case 2:
                formattedString += _children[0].IsNegative() ? "-" : "";
                formattedString += _children[0].IsReciprocal() ? "1/" : "";
                formattedString += _children[0].GetDisplayFormat() + "=";
                formattedString += _children[1].IsNegative() ? "-" : "";
                formattedString += _children[1].IsReciprocal() ? "1/" : "";
                formattedString += _children[1].GetDisplayFormat();
                break;
        }
        return formattedString;
    }
    public override void Negate() { }
    public override bool IsNegative()
    {
        return false;
    }
    public override void Reciprocate() { }
    public override bool IsReciprocal()
    {
        return false;
    }
    public override List<int> GetHitBox()
    {
        return new List<int>();
    }
}