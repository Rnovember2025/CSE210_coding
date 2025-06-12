using System;
using System.Runtime.CompilerServices;

public class Menu
{
    private List<string> _menuOptions;
    private List<char> _validInputs;
    public Menu(List<string> menuOptions, List<char> validInputs)
    {
        _menuOptions = menuOptions;
        _validInputs = validInputs;
    }
    public int PromptUser()
    {
        Console.WriteLine("Menu Options:");
        int i = 0;
        foreach (string line in _menuOptions)
        {
            Console.WriteLine($"\t{++i}:{line}");
        }
        Console.Write("Please enter your choice >>> ");
        while (true)
        {
            char userResponse = Console.ReadKey().KeyChar;
            if (_validInputs.Contains(userResponse))
            {
                return _validInputs.IndexOf(userResponse);
            }
            else
            {
                Console.Write("\nInvalid Entry. Try again >>> ");
            }
        }

    }
}