public abstract class EquationElement
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
    public bool ToOtherSide(EquationElement element)
    {
        return false;
    }
    public bool FactorOut(EquationElement element)
    {
        return false;
    }
    public bool DistributeIn(EquationElement element)
    {
        return false;
    }
    public virtual void AddChild(EquationElement child) { }
    public virtual void RemoveChild(EquationElement child) { }
    public abstract string GetDisplayFormat();
    public abstract string GetElementType();
    public abstract void Negate();
    public abstract bool IsNegative();
    public abstract void Reciprocate();
    public abstract bool IsReciprocal();
    public abstract List<int> GetHitBox();
}