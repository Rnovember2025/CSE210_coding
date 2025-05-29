using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string reference)
    //Reference in form "John 3:16-17"
    {
        string[] parts = reference.Split([' ', ':', '-']);
        _book = parts[0];
        _chapter = int.Parse(parts[1]);
        _startVerse = int.Parse(parts[2]);
        _endVerse = int.Parse(parts.Last());
    }
    public string GetReference()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}