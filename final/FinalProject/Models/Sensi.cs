using System.Xml.Serialization;

public class Sensi : Character
{
    string _difficulty; // might use this might not IDK yet. 
    public Sensi(string sensiName, BeltRank sensiBeltRank) : base(sensiName, sensiBeltRank)
    {
        GenerateDeck();
    }

    public void GenerateDeck()
    {
        // currently this doesnt account for power cards or regular cards just grabs random cards.
        // could add feature to make sure the sensi only gets x amount of power cards to makle the difficulty.
        // easier or harder. 

        Random ran = new Random();
        int carCount = CardDatabase.AllCards.Count();

        List<int> cardIDs = new List<int>();

        int i = 0;
        while (i < 30)
        {
            int randomCardID = ran.Next(1, carCount + 1);
            if (!cardIDs.Contains(randomCardID))
            {
                cardIDs.Add(randomCardID);
                i++;
            }
        }
        Deck newHand = new Deck(cardIDs);
        _hand = newHand;
    }

    public void GiveChallengeText()
    {
        // unfinished
    }

    public override int PlayCard()
    {
        Random ran = new Random();
        int randomIndex = ran.Next(this.GetHand().GetPlayableHand().Count);

        int cardChoice = this.GetHand().GetPlayableHand()[randomIndex];
        this.GetHand().RemoveCardFromPlayableHand(cardChoice);

        return cardChoice;
    }
    
}