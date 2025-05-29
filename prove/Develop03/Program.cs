using System;

class Program
{
    static Scripture _scripture = new Scripture("John 3:16-17", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life. For God sent not his Son into the world to condemn the world; but that the world through him might be saved.");
    static Menu _menu = new Menu();
    static void Main(string[] args)
    {
        int userInput = 1;
        while (userInput != 0)
        {
            Console.Clear();
            Console.WriteLine(_scripture.getScripture());
            userInput = _menu.promptUser();
            if (_scripture.wordsAllHidden()) { break; }
            switch (userInput)
            {
                case 1:
                    _scripture.Undo();
                    break;
                case 2:
                    _scripture.Redo();
                    break;
                case 3:
                    _scripture.hideWords();
                    break;
            }
        }
    }
}