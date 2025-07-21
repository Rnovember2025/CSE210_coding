using System.Globalization;

public class MultiplicationOpperator : Opperator
{
    public MultiplicationOpperator() : base("MULTIPLY") { }
    public override void Simplify()
    {
        List<EquationElement> numeratorTerms = new List<EquationElement>();  //Accumulator Variables
        EquationElement coefficients = new Number(1);
        List<EquationElement> denominatorTerms = new List<EquationElement>();
        EquationElement element;

        while (_children.Count() > 0) //This loop searches children and sorts them into numerator , denominator , and coefficients variables. Also removes all from _children list.
        {
            element = _children[0];
            _children.RemoveAt(0);
            element.Simplify();  //Recursive call; make sure that all children are in simplest form before continuing.

            List<EquationElement> equationChildren = element.GetChildren();
            if (equationChildren.Count() == 1)  //If things have simplified to the point that there is only one symbol, int, or opperator left, then remove the redundancy.
            {
                EquationElement singleChild = equationChildren[0];
                if (element.GetElementType() == "ADD")
                {
                    if (element.IsReciprocal()) { singleChild.Reciprocate(); }
                }

                element = singleChild;
            }
            
            if (element.IsReciprocal())  //These if else block sorts elements into the accumulator and tracks negative signs
            {
                if (element.IsNegative())
                {
                    element.Negate();
                    coefficients.Multiply(new Number(1, true));
                }
                element.Reciprocate();
                denominatorTerms.Add(element);
            }
            else
            {
                if (element.GetElementType() == "NUMBER")
                {
                    coefficients.Multiply(element);
                }
                else
                {
                    if (element.IsNegative())
                    {
                        element.Negate();
                        coefficients.Multiply(new Number(1, true));
                    }
                    numeratorTerms.Add(element);
                }
            }
        }

        bool isNegative = coefficients.IsNegative();  //Determine if final result should be negative or not.
        if (isNegative) { coefficients.Negate(); }  //Make sure everything is positive. Negative will be added back on at the end.

        if (coefficients.GetDisplayFormat() != "1")  //Add the combined coefficients to the numerator parts list.
        {
            numeratorTerms.Add(coefficients);
        }

        for (int i = 0; i < denominatorTerms.Count(); i++)  //Check if anything in the denominator is also in the numerator, if so, remove it from both.
        {
            EquationElement elementD = denominatorTerms[0];
            foreach (EquationElement elementN in numeratorTerms)
            {
                if (elementD.IsEqualTo(elementN))
                {
                    numeratorTerms.Remove(elementN);
                    denominatorTerms.Remove(elementD);
                    break;
                }
            }
            if (denominatorTerms.Contains(elementD))  //Rotate list if elementD wasn't already removed, so that each element gets checked.
            {
                EquationElement first = denominatorTerms[0];
                denominatorTerms.RemoveAt(0);
                denominatorTerms.Add(first);
            }
        }

        if (numeratorTerms.Count() == 0 && denominatorTerms.Count() == 0)  //If everything has cancelled out, then this is simply a one.
        {
            numeratorTerms.Add(new Number(1));
        }

        this.AddChildren(numeratorTerms);  //Add the reduced form of the numerator back as children.
        this.AddChildren(denominatorTerms);  //Add the reduced form of the numerator back as children.

        if (isNegative) { this.Negate(); }  //Make negative if final result needs to be.
    }
    public override bool Add(EquationElement element)
    {
        EquationElement elementCoefficient = new Number(1);
        EquationElement selfCoefficient = new Number(1);
        foreach (EquationElement child in element.GetChildren())  //Find the coefficient of the parameter and seperate it
        {
            if (child.GetElementType() == "NUMBER")
            {
                elementCoefficient = child;
                element.RemoveChild(child);
                break;
            }
        }
        foreach (EquationElement child in _children)  //Find its own coefficient and seperate it
        {
            if (child.GetElementType() == "NUMBER")
            {
                selfCoefficient = child;
                this.RemoveChild(child);
                break;
            }
        }
        bool opperationSuccess = false;
        
        if (element.IsEqualTo(this))  //If the two terms are equal without the number coefficient they can be added.
        {
            selfCoefficient.Add(elementCoefficient);  //Combine coefficients
            opperationSuccess = true;
        }
        this.AddChild(selfCoefficient);  //Put the coefficients back on
        element.AddChild(elementCoefficient);

        return opperationSuccess;  //True if successfully added.
    }
    public override bool Multiply(EquationElement element)
    {
        if (element.GetElementType() == "MULTIPLY")  //Remove a level of depth from the tree you are multiplying this my another multiplication opperator
        {
            this.AddChildren(element.GetChildren());
        }
        else { this.AddChild(element); }

        this.Simplify();
        return true;
    }
    public override string GetDisplayFormat()
    {
        string numeratorString = "";  //variables to accumulate format strings
        string denominatorString = "";
        Number coefficients = new Number(1);

        foreach (EquationElement element in _children)  //recursive call to get each childs display string and add them to accumulator variables.
        {
            switch (element.GetElementType())
            {
                case "ADD":
                case "SYMBOL":
                    if (element.IsReciprocal())
                    {
                        denominatorString += element.GetDisplayFormat();
                    }
                    else
                    {
                        numeratorString += element.GetDisplayFormat();
                    }
                    break;
                case "NUMBER":
                    coefficients.Multiply(element);  //Combine all numerical values for better readability
                    break;
            }
        }
        string formattedString;
        string coefficientString = coefficients.GetDisplayFormat();
        if (coefficientString == "1") { coefficientString = ""; }  //No need to put a one on the numerator...

        formattedString = numeratorString == "" ? $"{coefficientString}" : $"{coefficientString}{numeratorString}";
        if (formattedString == "") { formattedString = "1"; }  //..unless there is nothing else on the numerator, then we need the one.

        formattedString += denominatorString != "" ? "/" + denominatorString : "";  //add denominator if it exists.

        return formattedString;
    }
        
    public override void Negate()  //Only need to negate one symbol to negate whole thing. Negating a symbol or Atom is first priority in order to keep simple
    {
        bool foundAtomToNegate = false;
        foreach (EquationElement element in _children)
        {
            string elementType = element.GetElementType();
            if (elementType == "SYMBOL" || elementType == "NUMBER")
            {
                element.Negate();
                foundAtomToNegate = true;
                break;
            }
        }
        if (!foundAtomToNegate)
        {
            _children[0].Negate();
        }
    }
    public override bool IsNegative()  //Negative if an odd number of terms are negative.
    {
        int negativeTally = 0;
        foreach (EquationElement element in _children)
        {
            if (element.IsNegative())
            {
                negativeTally++;
            }
        }
        return Convert.ToBoolean(negativeTally % 2);
    }
    public override void Reciprocate()  //To make a reciprocal, you need to reciprocate everything.
    {
        foreach (EquationElement element in _children)
        {
            element.Reciprocate();
        }
    }
    public override bool IsReciprocal()  //Since each element remenbers that they are reciprocal, they will be treated such on their own, so this can be considered never reciprocal.
    {
        return false;
    }
    public override bool IsEqualTo(EquationElement element)  //Loop through its own children, ensure they all have a match in the provided element's children
    {
        List<EquationElement> elementChildren = element.GetChildren();
        if (elementChildren.Count() != _children.Count()) { return false; }  //Check they have the same number of children.
        foreach (EquationElement selfChild in _children)
        {
            bool foundMatch = false;
            foreach (EquationElement elementChild in elementChildren)  //For each child of self, search element children for a match.
            {
                if (selfChild.IsEqualTo(elementChild))
                {
                    foundMatch = true;
                    elementChildren.Remove(elementChild);  //Remove it to avoid matching multiple of self children with a single child from element
                    break;
                }
            }
            if (!foundMatch) { return false; }  //If a match wasn't found return false
        }
        return true;  //If this has been reached, that means that they are equal, return true.
    }
}