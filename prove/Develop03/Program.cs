using System;
/*
This program exceeds the requirements in the following ways:
    > The Menu class
    > The undo and redo menu options
    > The program only hides words not currently hidden (the stretch challenge)
    > The program responds to key presses, not line entries.
    > The progress bar

A note on the behaviour of the undo and redo menu options.
    > The scripture records the "depth" of layers it has hidden words to.
        > Basically it counts how many times you have pressed hide.
    > Each word remembers when it was hidden.
    > When the user presses undo, the words that were just previously hidden are unhidden.
        > Does nothing when all the words are hidden.
    > When the user presses redo, the words that were just previously reshown, are hidden again.
        > Does nothing when the point is reached where the origional undo was called.
    > When the user presses hide, more words are hidden.
        > If there are more changes to redo, redo is called. If not, then new words are hidden.
*/
class Program
{
    static Scripture _scripture = new Scripture("John 3:16-17", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life. For God sent not his Son into the world to condemn the world; but that the world through him might be saved.");
    static Menu _menu = new Menu();
    static ProgressBar _progress = new ProgressBar();
    static void Main(string[] args)
    {
        int userInput = 1;
        bool wordsAllHidden;
        while (userInput != 0)
        {
            Console.Clear();
            Console.WriteLine(_scripture.GetScripture() + '\n');
            _progress.ShowProgress(_scripture.GetProgress(), 16);

            userInput = _menu.PromptUser();

            wordsAllHidden = _scripture.WordsAllHidden();

            switch (userInput)
            {
                case 1:
                    _scripture.Undo();
                    break;
                case 2:
                    _scripture.Redo();
                    break;
                case 3:
                    _scripture.HideWords();
                    if (wordsAllHidden) { userInput = 0; }
                    break;
            }
        }
        Console.WriteLine("\n\nHave a great day!\n");
    }
}