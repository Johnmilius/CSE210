using System.Dynamic;
using System.Numerics;
using System.Runtime.CompilerServices;

public class Scripture
{
    private List<Verse> _scripture;
    private string reference;
    private int _numOfVerses;

    public Scripture(string input_reference, List<string> verseList)
    {
        reference = input_reference;

        this._scripture = new List<Verse>();

        foreach (string verse in verseList)
        {
            Verse v = new Verse(verse);
            _scripture.Add(v);
        }
        _numOfVerses = _scripture.Count;

    }

    public void renderScripture()
    {
        Console.Write($"{reference} ");
        foreach (Verse verse in this._scripture)
        {
            foreach (Word word in verse.getWords())
            {
                if (word.getVisibility() == true)
                {
                    Console.Write($"{word.getWord()}");
                }
                else // Could move to the getWord()
                {
                    int numOfUnderscores = word.getWord().Length;
                    for (int i = 0; i < numOfUnderscores; i++)
                    {
                        Console.Write("_");
                    }
                }
                Console.Write(" ");
            }


        }
    }
    public int getNumOfVerses()
    {
        return _numOfVerses;
    }
    public int getNumOfWordsInScripture()
    {
        int totalWords = 0;

        foreach (Verse verse in _scripture)
        {
            totalWords += verse.getNumOfWordInVerse();
        }

        return totalWords;
    }
    public int getNumOfHiddenWordsInScripture()
    {
        int totalHiddenWords = 0;
        foreach (Verse verse in _scripture)
        {
            foreach (Word word in verse.getWords())
            {
                if (!word.getVisibility())
                {
                    totalHiddenWords++;
                }
            }
        }
        return totalHiddenWords;
    }

    public Verse getRandomVerse()
    {
        Random rand = new Random();
        int randomIndex = rand.Next(_scripture.Count);
        Verse randomVerse = _scripture[randomIndex];
        return randomVerse;
    }
    public void hideThreeWords() //Infinite loop problems
    {
        int i = 0;
        int totalHiddenWords = this.getNumOfHiddenWordsInScripture();
        while (i < 3)
        {
            Word randomWord = this.getRandomVerse().getRandomWord();

            if (randomWord.getVisibility() == true)
            {
                randomWord.hideWord();
                i++;
                totalHiddenWords++;
            }

            if (totalHiddenWords == this.getNumOfWordsInScripture())
            {
                i = 4;
            }
        }

    }
}