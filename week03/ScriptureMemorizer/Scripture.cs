using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> unhiddenWords = new List<Word>();
       
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                unhiddenWords.Add(word);
            }
        }

        Random random = new Random();

        for (int i = 0; i < numberToHide && unhiddenWords.Count > 0; i++)
        {
            int index = random.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            unhiddenWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "\n";
        
        for (int i = 0; i < _words.Count; i++)
        {
            displayText += _words[i].GetDisplayText() + " ";
        }

        return displayText.Trim(); 
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
