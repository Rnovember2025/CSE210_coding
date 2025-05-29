using System;

public class Menu
{
    private List<string> _validInputs = new List<string> { "u", "r", "q", "\n" };

    public int PromptUser()
    {
        Console.WriteLine("\nMenu Options:\n\tq -> Quit\n\tu -> Undo\n\tr -> Redo\n\tReturn -> Erase more words.\n");
        Console.Write("Please enter your choice >>> ");
        while (true)
        {
            System.ConsoleKey userResponse = Console.ReadKey().Key;
            switch (userResponse)
            {
                case ConsoleKey.Q:
                    return 0;
                case ConsoleKey.U:
                    return 1;
                case ConsoleKey.R:
                    return 2;
                case ConsoleKey.Enter:
                    return 3;
                default:
                    Console.Write("Invalid Entry. Try Again >>> ");
                    break;
            }
        }

    }
}