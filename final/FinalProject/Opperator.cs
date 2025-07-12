public abstract class Opperator : EquationElement
{
    private string _opperatorType;
    protected List<EquationElement> _children = new List<EquationElement>();

    public Opperator(string opperatorType) : base()
    {
        _opperatorType = opperatorType;
    }

    public override void AddChild(EquationElement child)
    {
        _children.Add(child);
    }
    public override void RemoveChild(EquationElement child)
    {
        _children.Remove(child);
    }
    public override string GetElementType()
    {
        return _opperatorType;
    }
}