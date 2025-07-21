public abstract class Opperator : EquationElement
{
    private string _opperatorType;
    protected List<EquationElement> _children = new List<EquationElement>();

    public Opperator(string opperatorType) : base()
    {
        _opperatorType = opperatorType;
    }
    public override void AddChild(EquationElement child)  // link child into tree
    {
        _children.Add(child);
        child.SetParent(this);
    }
    public override void AddChildren(List<EquationElement> children)  //more fancier even than <AddChild>...
    {
        foreach (EquationElement child in children)
        {
            _children.Add(child);
            child.SetParent(this);
        }
    }
    public override void RemoveChild(EquationElement child)  //Program no longer following doctrines of christianity
    {
        _children.Remove(child);
    }
    public override List<EquationElement> GetChildren()
    {
        return _children.ToList();
    }
    public override string GetElementType()  //This is used for identifying types when searching through the tree. Also used in switch statements for getting the display format
    {
        return _opperatorType;
    }
}