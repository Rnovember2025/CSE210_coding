using System;

class Word
{
    private string _word;
    private bool _shown;
    private int _depthWhenHidden;
    public Word(string word) {
        _word = word;
        _shown = true;
        _depthWhenHidden = 0;
    }
    public string getWord() {
        if (_shown) {return _word;}
        else {return new string('_', _word.Count());}
    }
    public void hide(int depth) {
        _shown = false;
        _depthWhenHidden = depth;
    }
    public void unHide(int depth) {
        if (depth == _depthWhenHidden)
        {
            _shown = true;
        }
    }
    public void reHide(int depth)
    {
        if (depth == _depthWhenHidden)
        {
            _shown = false;
        }
    }
    public bool isShown()
    {
        return _shown;
    }
}