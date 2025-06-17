public class Square : Shape
{
    private double _sideLength;
    public Square(string color, double sideLength) : base(color, "Square")
    {
        _sideLength = sideLength;
    }
    public override double GetArea()
    {
        return _sideLength * _sideLength;
    }
}