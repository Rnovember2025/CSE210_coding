/*
Forms an equation with a tree structure that looks like this:

root ->                     =
                           / \
add3 ->                   /   +<r>
                         /   / \
                        /   x   2
                       /
mult1 ->    ----------*------------------
           /    \      \   \          \  \
add2 ->   /      +<r>   x   pi<n><r>   2  3
add1 ->  +      / \
        / \    x   3
       x   1<n>

Where <n> is a negative attribute and <r> is a reciprocal attribute,

Then display it in a user friendly fashion.
*/

class Program
{
    static void Main(string[] args)
    {
        EquationElement root = new EqualSignOpperator();        //Create equal sign that is the root of the tree

        EquationElement add1 = new AdditionOpperator();         //Create an addition between 'x' and '-1'
        add1.AddChild(new Atom("x"));
        add1.AddChild(new Atom(1, true, false));                //Syntax for Atom<> is Atom(value, isNegative, isReciprocal)

        EquationElement add2 = new AdditionOpperator();         //Create an addition between 'x' and '3'
        add2.AddChild(new Atom("x"));
        add2.AddChild(new Atom(3));
        add2.Reciprocate();                                     //Changes to reciprocal, '1/(x+3)' instead of 'x+3'

        EquationElement mult1 = new MultiplicationOpperator();  //Create multiplication between piece1, piece2, 'x', '-1/pi', '2', and '3'
        mult1.AddChild(add1);
        mult1.AddChild(add2);
        mult1.AddChild(new Atom("x"));
        mult1.AddChild(new Atom("pi", true, true));
        mult1.AddChild(new Atom(2));
        mult1.AddChild(new Atom(3));

        EquationElement add3 = new AdditionOpperator();         //Creaete addition between 'x', and '2'
        add3.AddChild(new Atom("x"));
        add3.AddChild(new Atom(2));
        add3.Reciprocate();

        root.AddChild(mult1);                                   //Fill in both sides of equation to form final tree
        root.AddChild(add3);

        Console.WriteLine(root.GetDisplayFormat());             //Display to user
    }
}