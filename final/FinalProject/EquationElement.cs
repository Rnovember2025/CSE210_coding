public abstract class EquationElement  //Basicall outlines everything that an equation element needs to do to play nicely with the tree.
{
    private EquationElement _parent = null;
    public void SetParent(EquationElement parent)
    {
        _parent = parent;
    }
    public EquationElement GetParent()
    {
        return _parent;
    }
    // SOMETHING FOR FUTURE ME TO DO...
    // public bool ToOtherSide(EquationElement element)
    // {
    //     return false;
    // }
    // public bool FactorOut(EquationElement element)
    // {
    //     return false;
    // }
    // public bool DistributeIn(EquationElement element)
    // {
    //     return false;
    // }
    public virtual void AddChild(EquationElement child) { }
    public virtual void AddChildren(List<EquationElement> children) { }
    public virtual void RemoveChild(EquationElement child) { }
    public virtual List<EquationElement> GetChildren() { return new List<EquationElement>(); }
    public virtual void Simplify() { }
    public virtual bool Add(EquationElement element) { return false; }
    public virtual bool Multiply(EquationElement element) { return false; }
    public abstract string GetDisplayFormat();
    public abstract string GetElementType();
    public abstract void Negate();
    public abstract bool IsNegative();
    public abstract void Reciprocate();
    public abstract bool IsReciprocal();
    public abstract bool IsEqualTo(EquationElement element);
}