using System.Collections.Generic;

public class Deck
{
    private List<int> _hand;
    private List<int> _playableHand = new List<int>();

    public Deck(List<int> cardIds)
    {
        _hand = new List<int>(cardIds);
    }

    public Deck()
    {
        _hand = new List<int>();
    }

    public void ShuffleDeck()
    {
        // unfinished
    }

    public int GetRandomCardID()
    {
        // unfinished
        int cardID = 0;
        return cardID;
    }

    public void RefillPlayableHand()
    {
        Random rand = new Random();

        while (_playableHand.Count() < 5)
        {
            int randomIndex = rand.Next(_hand.Count);
            int randomCard = _hand[randomIndex];

            if (!_playableHand.Contains(randomCard))
            {
                _playableHand.Add(randomCard);
            }
        }
    }

    public string DisplayPlayableHand()
    {
        string formatedSTR = "";
        int cardIndex = 1;
        foreach (int cardID in _playableHand)
        {
            formatedSTR += $"  {cardIndex}. {CardDatabase.AllCards[cardID].DisplayCardStats()}\n";
            cardIndex++;
        }
        return formatedSTR;
    }

    public void PlayCard() { }

    public List<int> GetPlayableHand()
    {
        return _playableHand;
    }

    public void RemoveCardFromPlayableHand(int cardID)
    {
        this._playableHand.Remove(cardID);
    }

    public void ClearPlayableHand()
    {
        _playableHand.Clear();
    }
}
