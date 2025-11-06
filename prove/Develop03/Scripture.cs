using System;
using System.Runtime.CompilerServices;

public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _reference;
    private UndoStack _undoStack = new UndoStack();
    private Stack<List<Word>> _redoStack = new Stack<List<Word>>();
    private Random _rand = new Random();
    public Scripture(string reference, string text)
    {
        _reference = new Reference(reference);
        string[] splitText = text.Split(' ');
        foreach (string s in splitText)
        {
            _words.Add(new Word(s));
        }

    }
    public string GetScripture()
    {
        List<string> scriptureWords = new List<string>();
        foreach (Word w in _words)
        {
            scriptureWords.Add(w.GetWord());
        }
        return _reference.GetReference() + "\n" + string.Join(" ", scriptureWords);
    }
    public void HideWords()
    {
        List<Word> shownWords = GetShownWords();
        int totalWordsToHide = (3 <= shownWords.Count) ? 3 : shownWords.Count;
        List<Word> wordsToHide = new List<Word>();

        for (int i = 0; i < totalWordsToHide; i++)
        {
            int r = _rand.Next(shownWords.Count);
            Console.WriteLine(r);
            wordsToHide.Add(shownWords[r]);
            shownWords.RemoveAt(r);
        }

        _undoStack.Do(wordsToHide);

    }
    public bool WordsAllHidden()
    {
        foreach (Word w in _words)
        {
            if (w.IsShown())
            {
                return false;
            }
        }
        return true;
    }

    public List<Word> GetShownWords()
    {
        List<Word> shownWords = new List<Word>();

        foreach (Word w in _words)
        {
            if (w.IsShown())
            {
                shownWords.Add(w);
            }
        }
        return shownWords;
    }

    public double GetProgress()
    {
        double percentage;
        List<Word> shownWords = new List<Word>();

        percentage = (_words.Count - shownWords.Count) / (float)_words.Count;
        return percentage;
    }
    public void Undo()
    {
        List<Word> words = _undoStack.Undo();
        if (words.Count() != 0)
        {
            _redoStack.Push(words);
        }
    }
    public void Redo()
    {
        try
        {
            List<Word> words = _redoStack.Pop();
            _undoStack.Do(words);
        }
        catch
        {
        }
    }
}