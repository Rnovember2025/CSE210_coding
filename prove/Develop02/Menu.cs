using System;
using System.Reflection;

class Menu {
    public List<string> _menuOptions = new List<string>{"1: Write",
                                                        "2: Load",
                                                        "3: Save",
                                                        "4: View",
                                                        "5: Quit"};

    public List<int> _validInputs = new List<int>{1,2,3,4,5};

    public int GetInput() {
        int input = 0;
        while (input == 0) {
            Console.WriteLine("Menu Options. Please enter a number:");
            foreach (string s in _menuOptions) {
                Console.WriteLine(s);
            }
            Console.Write(">>> ");
            try {
                input = int.Parse(Console.ReadLine());
                if (_validInputs.Contains(input) == false) {
                    throw new Exception();
                }
            }
            catch {
                input = 0;
                Console.WriteLine("That is an invalid menu option. Chose again.\n\n");
            }
        }
        Console.Write("\n\n");

        return input;
    }
}