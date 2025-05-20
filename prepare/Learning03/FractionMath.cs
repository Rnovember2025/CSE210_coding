using System;
using System.Globalization;

class FractionMath
{

    public Fraction AddFractions(Fraction fraction1, Fraction fraction2)
    {
        Fraction result = new Fraction();
        int num1 = fraction1.GetNumerator();
        int num2 = fraction2.GetNumerator();
        int den1 = fraction1.GetDenominator();
        int den2 = fraction2.GetDenominator();

        result.SetNumerator(num1 * den2 + num2 * den1);
        result.SetDenominator(den1 * den2);

        return result;
    }
}