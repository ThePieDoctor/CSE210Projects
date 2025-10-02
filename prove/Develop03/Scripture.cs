using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer;
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        int wordsToActuallyHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToActuallyHide; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }
    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public Reference GetReference()
    {
        return _reference;
    }
}