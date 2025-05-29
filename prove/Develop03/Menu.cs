using System;

class Menu
{
    private List<string> _validInputs = new List<string> { "u", "r", "q", "\n" };

    public int promptUser()
    {
        Console.WriteLine("\nMenu Options:\n\tq -> Quit\n\tu -> Undo\n\tr -> Redo\n\tReturn -> Erase more words.\n");
        Console.Write("Please enter your choice >>> ");
        while (true)
        {
            string userResponse = Console.ReadLine();
            switch (userResponse)
            {
                case "q":
                    return 0;
                case "u":
                    return 1;
                case "r":
                    return 2;
                case "":
                    return 3;
                default:
                    Console.Write("Invalid Entry. Try Again >>> ");
                    break;
            }
        }
        
    }
}