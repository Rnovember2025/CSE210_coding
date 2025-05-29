using System;
using System.Security.Cryptography;

class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _reference;
    private int _currentDepth = 0;
    private int _maxDepthReached = 0;
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
    public string getScripture()
    {
        List<string> scriptureWords = new List<string>();
        foreach (Word w in _words)
        {
            scriptureWords.Add(w.getWord());
        }
        return _reference.getReference() + "\n" + string.Join(" ", scriptureWords);
    }
    public void hideWords()
    {
        if (_currentDepth >= _maxDepthReached)
        {
            _maxDepthReached++;
            _currentDepth++;
            int successes = 0;
            while ((successes < 3) & (!wordsAllHidden()))
            {
                int index = _rand.Next(0, _words.Count());
                if (_words[index].isShown())
                {
                    _words[index].hide(_maxDepthReached);
                    successes++;
                }
            }
            //showState();
        }
        else
        {
            Redo();
        }
    }
    public bool wordsAllHidden()
    {
        foreach (Word w in _words)
        {
            if (w.isShown())
            {
                return false;
            }
        }
        return true;
    }
    public void Undo()
    {
        foreach (Word w in _words)
        {
            w.unHide(_currentDepth);
        }
        if (_currentDepth > 0)
        {
            _currentDepth--;
        }
        //showState();
    }
    public void Redo()
    {
        if (_currentDepth < _maxDepthReached)
        {
            _currentDepth++;
            foreach (Word w in _words)
            {
                w.reHide(_currentDepth);
            }
        }
        //showState();
    }
    private void showState()
    {
        Console.WriteLine(_currentDepth);
        Console.WriteLine(_maxDepthReached);
        Console.ReadLine();
    }
}