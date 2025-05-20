using System;
using System.Runtime.InteropServices;
//Encapsulation

class Program
{
    static void Main(string[] args)
    {
        Fraction myFraction = new Fraction();
        Console.WriteLine(myFraction.GetFractionString());
        Console.WriteLine(myFraction.GetFractionDecimal());
        myFraction.SetNumerator(5);
        Console.WriteLine(myFraction.GetFractionString());
        Console.WriteLine(myFraction.GetFractionDecimal());
        Fraction anotherFraction = new Fraction(3, 4);
        Console.WriteLine(anotherFraction.GetFractionString());
        Console.WriteLine(anotherFraction.GetFractionDecimal());
        anotherFraction.SetNumerator(1);
        anotherFraction.SetDenominator(3);
        Console.WriteLine(anotherFraction.GetFractionString());
        Console.WriteLine(anotherFraction.GetFractionDecimal());
        
    }
}