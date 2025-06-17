using System;

class Program
{
    static List<Shape> _shapes = new List<Shape>();
    static void Main(string[] args)
    {
        _shapes.Add(new Square("red", 10));
        _shapes.Add(new Rectangle("blue", 5, 7));
        _shapes.Add(new Circle("green", 3));

        foreach (Shape s in _shapes)
        {
            Console.WriteLine($"{s.GetCol()} {s.GetName()}: Area is {s.GetArea()}");
        }
    }
}