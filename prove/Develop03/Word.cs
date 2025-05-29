using System;
using System.Runtime.CompilerServices;

public class Word
{
    private string _word;
    private bool _shown;
    private int _depthWhenHidden;
    public Word(string word) {
        _word = word;
        _shown = true;
        _depthWhenHidden = 0;
    }
    public string GetWord() {
        if (_shown) {return _word;}
        else {return new string('.', _word.Count());}
    }
    public void Hide(int depth) {
        _shown = false;
        _depthWhenHidden = depth;
    }
    public void UnHide(int depth) {
        if (depth == _depthWhenHidden)
        {
            _shown = true;
        }
    }
    public void ReHide(int depth)
    {
        if (depth == _depthWhenHidden)
        {
            _shown = false;
        }
    }
    public bool IsShown()
    {
        return _shown;
    }
}