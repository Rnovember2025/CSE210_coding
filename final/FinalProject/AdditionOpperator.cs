public class AdditionOpperator : Opperator
{
    private bool _isReciprocal;
    public AdditionOpperator() : base("ADD") { }
    public override void Simplify()
    {
        List<EquationElement> combinedTerms = new List<EquationElement>();
        EquationElement element;

        while (_children.Count() > 0)  //Try to combine terms
        {
            element = _children[0];
            _children.RemoveAt(0);
            element.Simplify();

            if (element.GetChildren().Count() == 1)  //If things have simplified to the point that there is only one symbol, int, or opperator left, then remove the redundancy.
            {
                EquationElement singleChild = element.GetChildren()[0];
                if (element.GetElementType() == "ADD")
                {
                    if (element.IsReciprocal()) { singleChild.Reciprocate(); }
                }

                element = singleChild;
            }

            if (element.GetElementType() == "SYMBOL")  //Handles adding symbols by creating a new multiplication of '1' and the symbol, and adding that way.
            {
                EquationElement newElement = new MultiplicationOpperator();
                newElement.AddChildren(new List<EquationElement> { new Number(1), new Symbol(element.GetDisplayFormat()) });
                if (element.IsNegative()) { newElement.Negate(); }
                if (element.IsReciprocal()) { newElement.Reciprocate(); }
                element = newElement;
            }

            combinedTerms.Add(element);
            List<EquationElement> piecesToRemove = new List<EquationElement>();
            foreach (EquationElement child in _children)  //this loop adds all like terms by looping through all children, attempting to add each to element, and if successful, removes the child. Then it picks a new child to be the next element, and repeats.
            {
                EquationElement childToAdd = child;
                if (child.GetElementType() == "SYMBOL")
                {
                    EquationElement newChild = new MultiplicationOpperator();
                    newChild.AddChildren(new List<EquationElement> { new Number(1), new Symbol(child.GetDisplayFormat()) });
                    if (child.IsNegative()) { newChild.Negate(); }
                    if (child.IsReciprocal()) { newChild.Reciprocate(); }
                    childToAdd = newChild;

                }
                if (element.Add(childToAdd) == true)
                {
                    piecesToRemove.Add(child);
                }
            }
            foreach (EquationElement piece in piecesToRemove)
            {
                _children.Remove(piece);
            }
        }
        this.AddChildren(combinedTerms);  //Now that everything is simplified, add it back as children.
    }
    public override bool Add(EquationElement element)  //Adding an addition opperator to another addition opperator simply means append all the children to this addition opperator.
    {
        if (element.GetElementType() == "ADD")
        {
            this.AddChildren(element.GetChildren());
        }
        else { this.AddChild(element); }

        this.Simplify();
        return true;
    }
    public override bool Multiply(EquationElement element)  //This would impliment the distributive property, but that isn't helpful yet, so just leaving it blank for now.
    {
        return false;
    }
    public override string GetDisplayFormat()
    {
        string formattedString = "";
        foreach (EquationElement element in _children)
        {
            switch (element.GetElementType())
            {
                case "SYMBOL":
                case "NUMBER":
                    formattedString += element.IsNegative() ? "-" : "+";
                    formattedString += element.IsReciprocal() ? "1/" : "";
                    formattedString += element.GetDisplayFormat();
                    break;
                case "MULTIPLY":
                    formattedString += element.IsNegative() ? "-" : "+";
                    formattedString += element.GetDisplayFormat();
                    break;
            }
        }
        formattedString = formattedString[0] == '+' ? formattedString.Substring(1, formattedString.Count() - 1) : formattedString;
        return $"({formattedString})";
    }
    public override void Negate()  //negating an addition requries negating each component.
    {
        foreach (EquationElement element in _children)
        {
            element.Negate();
        }
    }
    public override bool IsNegative()  //Since each component remembers if it's negative, then the only return type needed here is false.
    {
        return false;
    }
    public override void Reciprocate()
    {
        _isReciprocal = !_isReciprocal;
    }
    public override bool IsReciprocal()
    {
        return _isReciprocal;
    }
    public override bool IsEqualTo(EquationElement element)  //make sure that each of this opperator's children has a match in the elements children with no duplicates.
    {
        List<EquationElement> elementChildren = element.GetChildren();
        foreach (EquationElement selfChild in _children)
        {
            bool foundMatch = false;
            foreach (EquationElement elementChild in elementChildren)
            {
                if (selfChild.IsEqualTo(elementChild))
                {
                    foundMatch = true;
                    elementChildren.Remove(elementChild);
                    break;
                }
            }
            if (!foundMatch) { return false; }
        }
        if (elementChildren.Count() > 0) { return false; }  //I said no duplicates!!

        return true;
    }
}