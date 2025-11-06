using System;
using System.Runtime.CompilerServices;

public class Word
{
    private string _word;
    private bool _shown;
    public Word(string word) {
        _word = word;
        _shown = true;
    }
    public string GetWord() {
        if (_shown) {return _word;}
        else {return new string('.', _word.Count());}
    }
    public void Hide() {
        _shown = false;
    }
    public void UnHide() {
        _shown = true;
    }
    public bool IsShown()
    {
        return _shown;
    }
}