using System.Data;

public class Atom : EquationElement
{
    private string _symbol;
    private int _value;
    private int _type; //0 for ascii symbol, 1 for integer.
    private bool _isInverse;
    private bool _isNegative;
    public Atom(string letter,  bool isNegative, bool isInverse) : base()
    {
        _symbol = letter;
        _type = 0;
        _isNegative = isNegative;
        _isInverse = isInverse;
    }
    public Atom(string letter) : base()
    {
        _symbol = letter;
        _type = 0;
        _isInverse = false;
        _isNegative = false;
    }
    public Atom(int value, bool isNegative, bool isInverse) : base()
    {
        _value = value;
        _type = 1;
        _isNegative = isNegative;
        _isInverse = isInverse;
    }
    public Atom(int value) : base()
    {
        _value = value;
        _type = 1;
        _isNegative = false;
        _isInverse = false;
    }
    public string GetSymbol()
    {
        switch (_type)
        {
            case 0:
                return _symbol;
            case 1:
                return _value.ToString();
            default:
                return "";
        }
    }
    public List<int> GetFactors()
    {
        return new List<int>();
    }
    public override string GetDisplayFormat()
    {
        switch (_type)
        {
            case 0:
                return _symbol;
            case 1:
                return _value.ToString();
            default:
                return "";
        }
    }
    public override string GetElementType()
    {
        if (_type == 0)
        {
            return "SYMBOL";
        }
        else
        {
            return "INT";
        }
    }
    public override void Negate()
    {
        _isNegative = !_isNegative;
    }
    public override bool IsNegative()
    {
        return _isNegative;
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