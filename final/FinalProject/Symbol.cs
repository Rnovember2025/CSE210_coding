public class Symbol : Atom
{
    private string _symbol;
    public Symbol(string symbol, bool isNegative, bool isInverse) : base("SYMBOL", isNegative, isInverse)
    {
        _symbol = symbol;
    }
    public Symbol(string symbol) : base("SYMBOL", false, false)
    {
        _symbol = symbol;
    }
    public override string GetDisplayFormat()
    {
        return _symbol;
    }
}