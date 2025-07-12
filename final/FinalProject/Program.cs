/*
Forms an equation with a tree structer that looks like this:

                            =
                           / \
                          /   +<r>
                         /   / \
                        /   x   2
                       /
            ----------*------------------
           /    \      \   \          \  \
          /      +<r>   x   pi<n><r>   2  3
         +      / \
        / \    x   3
       x   1<n>

where <n> is a negative attribute and <r> is a reciprocal attribute,

Then display it in a user friendly fashion.
*/

class Program
{
    static void Main(string[] args)
    {
        EquationElement root = new EqualSignOpperator();        //Create equal sign that is the root of the tree

        EquationElement piece1 = new AdditionOpperator();       //Create an addition between 'x' and '-1'
        piece1.AddChild(new Atom("x"));
        piece1.AddChild(new Atom(1, true, false));              //Syntax for Atom<> is Atom(value, isNegative, isReciprocal)

        EquationElement piece2 = new AdditionOpperator();       //Create an addition between 'x' and '3'
        piece2.AddChild(new Atom("x"));
        piece2.AddChild(new Atom(3));
        piece2.Reciprocate();                                   //Changes to reciprocal, '1/(x+3)' instead of 'x+3'

        EquationElement piece3 = new MultiplicationOpperator(); //Create multiplication between piece1, piece2, 'x', '-1/pi', '2', and '3'
        piece3.AddChild(piece1);
        piece3.AddChild(piece2);
        piece3.AddChild(new Atom("x"));
        piece3.AddChild(new Atom("pi", true, true));
        piece3.AddChild(new Atom(2));
        piece3.AddChild(new Atom(3));

        EquationElement piece4 = new AdditionOpperator();       //Creaete addition between 'x', and '2'
        piece4.AddChild(new Atom("x"));
        piece4.AddChild(new Atom(2));
        piece4.Reciprocate();

        root.AddChild(piece3);                                  //Fill in both sides of equation to form final tree
        root.AddChild(piece4);

        Console.WriteLine(root.GetDisplayFormat());             //Display to user
    }
}