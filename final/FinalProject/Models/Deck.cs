using System.Collections.Generic;

public class Deck
{
    private List<int> _hand;

    public Deck(List<int> cardIds)
    {
        _hand = new List<int>(cardIds);
    }

    public Deck()
    {
        _hand = new List<int>();
    }

}
