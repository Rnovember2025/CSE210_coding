public class UndoStack
{
    private Stack<List<Word>> _stack = new Stack<List<Word>>();

    public void Do(List<Word> items)
    {
        foreach (Word word in items)
        {
            word.Hide();
        }
        _stack.Push(items);
    }
    public List<Word> Undo()
    {
        if (_stack.Count() == 0) { return new List<Word>(); }
        List<Word> items = _stack.Pop();
        foreach (Word word in items)
        {
            word.UnHide();
        }
        return items;
    }
}