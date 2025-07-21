public class EqualSignOpperator : Opperator
{
    public EqualSignOpperator() : base("EQUALS") { }
    public override void AddChild(EquationElement child)  //Overrides to impliment fact that an equal sign can have only up to 2 children (chinese?).
    {
        if (_children.Count() < 2)
        {
            base.AddChild(child);
        }
        else
        {
            throw new Exception("Cannot add more than 2 children to an equal sign.");
        }
    }

    public override void Simplify()  //Simplify each side of the equal sign.
    {
        if (_children.Count() > 0)
        {
            _children[0].Simplify();
            if (_children[0].GetChildren().Count() == 1)  //If an opperator only has one child, discard the opperator, and raise the child up a level
            {
                EquationElement singleChild = _children[0].GetChildren()[0];
                if (_children[0].GetElementType() == "ADD")
                {
                    if (_children[0].IsReciprocal()) { singleChild.Reciprocate(); }
                }
                _children[0] = singleChild;
            }
        }
        if (_children.Count() > 1)
        {
            _children[1].Simplify();
            if (_children[1].GetChildren().Count() == 1)  //dido. I'm getting tired of writing comments.
            {
                EquationElement singleChild = _children[1].GetChildren()[0];
                if (_children[1].GetElementType() == "ADD")
                {
                    if (_children[1].IsReciprocal()) { singleChild.Reciprocate(); }
                }
                _children[1] = singleChild;
            }
        }
    }
    public override string GetDisplayFormat()  //If there are less than 2 children, then one or both sides equals '0'
    {
        string formattedString = "";

        int totalChildren = _children.Count();

        if (totalChildren == 0) { formattedString = "0=0"; }
        else
        {
            formattedString += _children[0].IsNegative() ? "-" : "";
            formattedString += _children[0].IsReciprocal() ? "1/" : "";
            formattedString += _children[0].GetDisplayFormat() + "=";
        }

        if (totalChildren == 1) { formattedString += "0"; }
        else if (totalChildren == 2)
        {
            formattedString += _children[1].IsNegative() ? "-" : "";
            formattedString += _children[1].IsReciprocal() ? "1/" : "";
            formattedString += _children[1].GetDisplayFormat();
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
    public override bool IsEqualTo(EquationElement element)
    {
        return false;
    }
}