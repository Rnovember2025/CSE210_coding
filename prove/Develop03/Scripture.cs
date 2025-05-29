using System;

public class Scripture
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
        if (_currentDepth >= _maxDepthReached)
        {
            _maxDepthReached++;
            _currentDepth++;
            int successes = 0;
            while ((successes < 3) & (!WordsAllHidden()))
            {
                int index = _rand.Next(0, _words.Count());
                if (_words[index].IsShown())
                {
                    _words[index].Hide(_maxDepthReached);
                    successes++;
                }
            }
        }
        else
        {
            Redo();
        }
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

    public double GetProgress()
    {
        double percentage = 0;
        if (_currentDepth != 0)
        {
            percentage = _currentDepth / ((float)_words.Count() / 3);
            if (percentage > 100) { percentage = 100; }
        }
        return percentage;
    }
    public void Undo()
    {
        if (_currentDepth > 0)
        {
            foreach (Word w in _words)
            {
                w.UnHide(_currentDepth);
            }
            _currentDepth--;
        }
    }
    public void Redo()
    {
        if (_currentDepth < _maxDepthReached)
        {
            _currentDepth++;
            foreach (Word w in _words)
            {
                w.ReHide(_currentDepth);
            }
        }
    }
}