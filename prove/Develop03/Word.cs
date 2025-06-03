public class Word
{
    private string word;
    private bool visable;

    public Word(string input_word)
    {
        word = input_word;
        visable = true;
    }
    public bool getVisibility()
    {
        return visable;
    }
    public string getWord()
    {
        return word;
    }
    public void hideWord()
    {
        visable = false;
    }

}