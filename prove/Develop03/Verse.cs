using System.Security;

public class Verse
{
    private List<Word> Words;
    private int _numOfWords;

    public Verse(string text)
    {
        string[] parts = text.Split();
        this.Words = new List<Word>();

        foreach (string part in parts)
        {
            Word word = new Word(part);
            Words.Add(word);
        }

        _numOfWords = Words.Count;
    }
    public List<Word> getWords()
    {
        return this.Words;
    }

    public Word getRandomWord()
    {
        Random rand = new Random();
        int randomIndex = rand.Next(Words.Count);

        Word randomWord = Words[randomIndex];

        return randomWord;
    }

    public int getNumOfWordInVerse()
    {
        return _numOfWords;
    }

}