using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(" ");
        foreach (string part in parts)
        {
            Word word = new Word(part);
            _words.Add(word);
        }
    }
    public void HideRandomWords()
    {
        Random rand = new Random();
        int numberToHide = _words.Count * 20/100;
        if (numberToHide < 1)
        {
            numberToHide = 1;
        }
        int count = 0;
        while (count < numberToHide)
        {
            if (IsCompletelyHidden() == true)
            {
                break;
            }
            int index = rand.Next(_words.Count);
            if (_words[index].IsHidden() == false)
            {
                _words[index].Hide();
                count++;
            }        
        }
    }
    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            result = result + word.GetDisplayText() + " ";
        }
        return result;
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                return false;
            }
        }
        return true;
    }
}