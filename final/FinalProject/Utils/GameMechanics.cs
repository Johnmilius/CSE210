using System.Xml.XPath;

public static class GameMechanics
{

    public static int CompareCards(int player1CardId, int player2CardId)
    {
        var card1 = CardDatabase.AllCards[player1CardId];
        var card2 = CardDatabase.AllCards[player2CardId];

        if (CompareElements(card1.GetElement(), card2.GetElement()))
            return 1; // player 1 wins by element
        if (CompareElements(card2.GetElement(), card1.GetElement()))
            return -1; // player 2 wins by element

        // If elements are equal or neither wins, compare values
        if (card1.GetValue() > card2.GetValue())
            return 1;
        if (card2.GetValue() > card1.GetValue())
            return -1;

        return 0; // tie
    }


    public static bool CompareElements(ElementType elementA, ElementType elementB)
    {
        // Example rules: Fire beats Snow, Snow beats Water, Water beats Fire
        if (elementA == ElementType.Fire && elementB == ElementType.Snow)
            return true;
        if (elementA == ElementType.Snow && elementB == ElementType.Water)
            return true;
        if (elementA == ElementType.Water && elementB == ElementType.Fire)
            return true;
        return false;
    }

    public static int CompareValues(int value1, int value2)
    {
        if (value1 > value2)
            return 1;
        if (value2 > value1)
            return -1;
        return 0;
    }


    
}