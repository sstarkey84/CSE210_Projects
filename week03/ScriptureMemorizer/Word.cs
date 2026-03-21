class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }
    public void Hide()
    {
        _hidden = true;
    }
    public bool IsHidden()
    {
        return _hidden;
    }
    public string GetDisplayText()
    {
        if (_hidden == true)
        {
            string result = " ";
            foreach (char c in _text)
            {
                if (char.IsLetter(c))
                {
                    result = result + "_";
                }
                else
                {
                    result = result + c;
                }
            }
            return result;
        }
        else
        {
            return _text;
        }
    }
}