public abstract class Atom : EquationElement
{
    private bool _isReciprocal;
    private bool _isNegative;
    private string _atomType;
    public Atom(string atomType, bool isNegative, bool isReciprocal) : base()
    {
        _atomType = atomType;
        _isNegative = isNegative;
        _isReciprocal = isReciprocal;
    }
    public Atom(string atomType) : base()
    {
        _atomType = atomType;
        _isNegative = false;
        _isReciprocal = false;
    }
    public override string GetElementType()  //This is used for identifying types when searching through the tree. Also used in switch statements for getting the display format
    {
        return _atomType;
    }
    public override void Negate()
    {
        _isNegative = !_isNegative;
    }
    public override bool IsNegative()
    {
        return _isNegative;
    }
    public override void Reciprocate()  //overwritten by <Number> class
    {
        _isReciprocal = !_isReciprocal;
    }
    public override bool IsReciprocal()  //overwritten by <Number> class
    {
        return _isReciprocal;
    }
    public override bool IsEqualTo(EquationElement element)  //if both are same type, have the same stuff, show the same attitude, and do the same gymastics, their friends.
    {
        if (element.GetElementType() == _atomType &&
            element.GetDisplayFormat() == this.GetDisplayFormat() &&
            element.IsNegative() == _isNegative &&
            element.IsReciprocal() == _isReciprocal)
        {
            return true;
        }
        return false;
    }
}