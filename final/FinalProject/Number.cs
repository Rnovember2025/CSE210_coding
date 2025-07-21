public class Number : Atom
{
    private int _numerator;
    private int _denominator;
    public Number(int numerator, int denominator, bool isNegative) : base("NUMBER", isNegative, false)
    {
        _numerator = numerator;
        _denominator = denominator;
    }
    public Number(int numerator, int denominator) : base("NUMBER", false, false)
    {
        _numerator = numerator;
        _denominator = denominator;
    }
    public Number(int numerator, bool isNegative) : base("NUMBER", isNegative, false)
    {
        _numerator = numerator;
        _denominator = 1;
    }
    public Number(int numerator) : base("NUMBER", false, false)
    {
        _numerator = numerator;
        _denominator = 1;
    }
    public Number(string fraction, bool isNegative) : base("NUMBER", isNegative, false)
    {
        List<int> parts = SplitFractionString(fraction);
        _numerator = parts[0];
        _denominator = parts[1];
    }
    public Number(string fraction) : base("NUMBER", false, false)
    {
        List<int> parts = SplitFractionString(fraction);
        _numerator = parts[0];
        _denominator = parts[1];
    }
    private List<int> SplitFractionString(string fraction)  //Parse a string into 2 integers, numerator and denominator.
    {
        List<int> returnValues = new List<int>();

        fraction = fraction.Replace("(","");
        fraction = fraction.Replace(")", "");

        string[] parts = fraction.Split('/');
        returnValues.Add(Convert.ToInt32(parts[0]));
        if (parts.Count() == 2) { returnValues.Add(Convert.ToInt32(parts[1])); }
        else { returnValues.Add(1); }

        return returnValues;
    }
    public override void Simplify()  //Divide numerator and denominator by greatest common divisor.
    {
        int tempNumerator = _numerator;
        int tempDenominator = _denominator;

        while (tempNumerator != 0 && tempDenominator != 0)
        {
            if (tempNumerator > tempDenominator) { tempNumerator %= tempDenominator; }
            else { tempDenominator %= tempNumerator; }
        }
        int gcd = tempNumerator | tempDenominator;

        _numerator = _numerator / gcd;
        _denominator = _denominator / gcd;
    }
    public override bool Add(EquationElement element)  //Handle adding fractions. Always simplifies to simplest form (i'm not an english major ):
    {
        if (element.GetElementType() == "NUMBER")
        {
            List<int> elementParts = SplitFractionString(element.GetDisplayFormat());
            _numerator = _numerator * elementParts[1] * (this.IsNegative() ? -1 : 1) + _denominator * elementParts[0] * (element.IsNegative() ? -1 : 1);
            _denominator *= elementParts[1];

            if (_numerator < 0)
            {
                _numerator *= -1;
                if (!this.IsNegative())
                {
                    this.Negate();
                }
            }

            this.Simplify();
            return true;
        }
        return false;
    }
    public override bool Multiply(EquationElement element)  //Handle multiplying fractions. Also always simplifies.
    {
        if (element.GetElementType() == "NUMBER")
        {
            List<int> elementParts = SplitFractionString(element.GetDisplayFormat());
            _numerator *= elementParts[0];
            _denominator *= elementParts[1];

            this.Simplify();
            if (element.IsNegative()) { this.Negate(); }
            return true;
        }
        return false;
    }
    public override string GetDisplayFormat()
    {
        if (_denominator != 1)
        {
            return $"({_numerator}/{_denominator})";
        }
        else
        {
            return $"{_numerator}";
        }
    }
    public override void Reciprocate()  //swap numerator and denominator.
    {
        int temp = _numerator;
        _numerator = _denominator;
        _denominator = temp;
    }
    public override bool IsReciprocal()
    {
        return false;
    }
}