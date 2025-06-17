public class Shape
{
    private string _color;
    private string _name;
    public Shape(string color, string name)
    {
        _color = color;
        _name = name;
    }
    public void SetCol(string color)
    {
        _color = color;
    }
    public string GetCol()
    {
        return _color;
    }
    public string GetName()
    {
        return _name;
    }
    public virtual double GetArea()
    {
        return 0;
    }
}