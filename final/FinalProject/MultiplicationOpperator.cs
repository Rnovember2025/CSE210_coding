public class MultiplicationOpperator : Opperator
{
    public MultiplicationOpperator() : base("MULTIPLY") { }
    public override string GetDisplayFormat()
    {
        string numeratorString = "";
        int numeratorCoefficient = 1;
        string denominatorString = "";
        int denominatorCoefficient = 1;

        foreach (EquationElement element in _children)
        {
            switch (element.GetElementType())
            {
                case "SYMBOL":
                    if (element.IsReciprocal())
                    {
                        denominatorString += element.GetDisplayFormat();
                    }
                    else
                    {
                        numeratorString += element.GetDisplayFormat();
                    }
                    break;
                case "INT":
                    if (element.IsReciprocal())
                    {
                        denominatorCoefficient *= Convert.ToInt32(element.GetDisplayFormat());
                    }
                    else
                    {
                        numeratorCoefficient *= Convert.ToInt32(element.GetDisplayFormat());
                    }
                    break;
                case "ADD":
                    if (element.IsReciprocal())
                    {
                        denominatorString += $"{element.GetDisplayFormat()}";
                    }
                    else
                    {
                        numeratorString += $"{element.GetDisplayFormat()}";
                    }
                    break;
                default:
                    break;
            }
        }
        string formattedString = "";

        if (numeratorCoefficient > 1)
        {
            formattedString += numeratorString == "" ? $"{numeratorCoefficient}" : $"{numeratorCoefficient}{numeratorString}";
        }
        else
        {
            formattedString += numeratorString == "" ? "1" : $"{numeratorString}";
        }
        if (denominatorCoefficient > 1)
        {
            formattedString += "/" + denominatorString == "" ? $"{denominatorCoefficient}" : $"{denominatorCoefficient}{denominatorString}";
        }
        else
        {
            if (denominatorString != "")
            {
                formattedString += "/" + denominatorString;
            }
        }
        return formattedString;
    }
    public override void Negate()
    {
        bool foundAtomToNegate = false;
        foreach (EquationElement element in _children)
        {
            string elementType = element.GetElementType();
            if (elementType == "SYMBOL" || elementType == "INT")
            {
                element.Negate();
                foundAtomToNegate = true;
                break;
            }
        }
        if (!foundAtomToNegate)
        {
            _children[0].Negate();
        }
    }
    public override bool IsNegative()
    {
        int negativeTally = 0;
        foreach (EquationElement element in _children)
        {
            if (element.IsNegative())
            {
                negativeTally++;
            }
        }
        return Convert.ToBoolean(negativeTally % 2);
    }
    public override void Reciprocate()
    {
        foreach (EquationElement element in _children)
        {
            element.Reciprocate();
        }
    }
    public override bool IsReciprocal()
    {
        return false;
    }
    public override List<int> GetHitBox()
    {
        return new List<int>();
    }
}