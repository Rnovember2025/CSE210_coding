/*
Equation has a tree structure that looks like this:

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

Where <n> is a negative attribute and <r> is a reciprocal attribute,
*/

public class Program
{
    static Dictionary<string, EquationElement> keyWords = new Dictionary<string, EquationElement>();
    static void Main(string[] args)
    {
        //Test();

        Console.WriteLine("=============================\nWelcome to Ronan Nashematica!\n=============================");
        PrintHelp();

        string[] userInput;
        bool running = true;

        keyWords.Add("root", new EqualSignOpperator());

        while (running)
        {
            Console.Write(">>> ");
            userInput = Console.ReadLine().Split(" ");
            try
            {
                if (userInput[0] == "new")
                {
                    if (userInput[1] == "addition")
                    {
                        keyWords.Add(userInput[2], new AdditionOpperator());
                    }
                    else if (userInput[1] == "multiplication")
                    {
                        keyWords.Add(userInput[2], new MultiplicationOpperator());
                    }
                    else if (userInput[1] == "symbol")
                    {
                        keyWords.Add(userInput[2], new Symbol(userInput[3]));
                    }
                    else if (userInput[1] == "number")
                    {
                        if (userInput[2][0] == '-')
                        {
                            Console.WriteLine("Please enter a positive value, then use the negate command.");
                            continue;
                        }
                        keyWords.Add(userInput[2], new Number(userInput[3]));
                    }
                    else { Console.WriteLine("Invalid Type"); }
                }
                else if (userInput[0] == "append")
                {
                    keyWords[userInput[1]].AddChild(keyWords[userInput[2]]);
                    Console.WriteLine(userInput[1] + " : " + keyWords[userInput[1]].GetDisplayFormat());
                }
                else if (userInput[0] == "negate")
                {
                    keyWords[userInput[1]].Negate();
                    Console.WriteLine(userInput[1] + " : " + keyWords[userInput[1]].GetDisplayFormat());
                }
                else if (userInput[0] == "reciprocate")
                {
                    keyWords[userInput[1]].Reciprocate();
                    Console.WriteLine(userInput[1] + " : " + keyWords[userInput[1]].GetDisplayFormat());
                }
                else if (userInput[0] == "simplify")
                {
                    keyWords["root"].Simplify();
                    Console.WriteLine("RESULT : " + keyWords["root"].GetDisplayFormat());
                    running = false;
                }
                else if (userInput[0] == "show")
                {
                    Console.WriteLine(userInput[1] + " : " + keyWords[userInput[1]].GetDisplayFormat());
                }
                else if (userInput[0] == "restart")
                {
                    keyWords.Clear();
                    keyWords.Add("root", new EqualSignOpperator());
                    Console.Clear();
                    PrintHelp();
                }
                else if (userInput[0] == "help")
                {
                    PrintHelp();
                }
                else { Console.WriteLine("Invalid Command."); }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid Syntax");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Can't use a name that has not been defined yet");
            }
            catch { Console.WriteLine("Something went wrong."); }
        }
    }

    static void PrintHelp()
    {
        Console.WriteLine("Commands:");
        Console.WriteLine("\t-new <type>: create new opperator, symbol, or number.");
        Console.WriteLine("\t-append <base-name> <item-name>: append an item (opperator, symbol, or number) as child to a base opperator.");
        Console.WriteLine("\t-negate <item-name>: negate an item.");
        Console.WriteLine("\t-reciprocate <item-name: reciprocate an item.");
        Console.WriteLine("\t-show <item-name>: print out an item");
        Console.WriteLine("\t-simplify: simplify equation.");
        Console.WriteLine("\t-restart: clear everything, restart");
        Console.WriteLine("\t-help: show this help");
        Console.WriteLine("Types:");
        Console.WriteLine("\t-addition <name>: an addition opperator (can have any number of children).");
        Console.WriteLine("\t-multiplication <name>: a multiplication opperator (can have any number of children).");
        Console.WriteLine("\t-symbol <name> <symbol-string>: something like 'x' or 'pi'.");
        Console.WriteLine("\t-number <name> <value>: an integer or fraction)");
        Console.WriteLine("Built In Names:");
        Console.WriteLine("\t-root: base equal sign (can have 2 children).");
        Console.WriteLine("Example:");
        Console.WriteLine("\t>>> new addition add1");
        Console.WriteLine("\t>>> new symbol x1 x");
        Console.WriteLine("\t>>> new symbol x2 x");
        Console.WriteLine("\t>>> append add1 x1");
        Console.WriteLine("\t>>> append add1 x2");
        Console.WriteLine("\t>>> append root add1");
        Console.WriteLine("\t>>> simplify");
        Console.WriteLine("\tRESULT : 2x=0\n");
    }

    static void Test()
    {
        EquationElement add1 = new AdditionOpperator();         //Create an addition between 'x' and '1' and '1/2'
        add1.AddChildren(new List<EquationElement> { new Symbol("x"), new Number(1), new Number(1, 2) });

        EquationElement add2 = new AdditionOpperator();         //Create an addition between '2' and '1/3' and '-3'
        add2.AddChildren(new List<EquationElement> { new Number(2), new Number(1, 3), new Number(3, true) });
        add2.Reciprocate();                                     //Changes to reciprocal, '1/(x+3)' instead of 'x+3'

        EquationElement mult1 = new MultiplicationOpperator();  //Create multiplication between add1, add2, 'x', '-1/4', '-8', and '-1/3'
        mult1.AddChildren(new List<EquationElement> { add1, add2, new Symbol("x"), new Number(1, 4, true), new Number(8, true), new Number(1, 3, true) });

        EquationElement mult2 = new MultiplicationOpperator();  //Creat a multiplication between '2', 'x', and 'y'
        mult2.AddChildren(new List<EquationElement> { new Number(2), new Symbol("x"), new Symbol("y") });

        EquationElement mult3 = new MultiplicationOpperator();  //Creat a multiplication between '5', 'y', and 'x'
        mult3.AddChildren(new List<EquationElement> { new Number(5), new Symbol("y"), new Symbol("x") });

        EquationElement add3 = new AdditionOpperator();         //create '1'/( addition between '5yx', '2xy', '2', and '-1/4' )
        add3.AddChildren(new List<EquationElement> { mult3, mult2, new Number(2), new Number(1, 4, true) });
        add3.Reciprocate();

        EquationElement root = new EqualSignOpperator();        //Create equal sign that is the root of the tree
        root.AddChildren(new List<EquationElement> { mult1, add3 });  //Fill in both sides of equation to form final tree

        Console.WriteLine(root.GetDisplayFormat());             //Display to user

        root.Simplify();

        Console.WriteLine("\n" + root.GetDisplayFormat());      //Display to user
    }
}