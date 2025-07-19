using System.Dynamic;
using System.Xml.XPath;

public static class GameMechanics
{
    public static int CompareCards(Card player1Card, Card player2Card)
    {

        ElementType p1Element = player1Card.GetElement();
        ElementType p2Element = player2Card.GetElement();

        if (player1Card.GetPowerCardEffectType() != PowerCardEffectType.None)
        {
            PowerCardEffectMechanics.PlayedPowerCardEffect(player1Card, player2Card, ref p2Element);
        }
        if (player2Card.GetPowerCardEffectType() != PowerCardEffectType.None)
        {
            PowerCardEffectMechanics.PlayedPowerCardEffect(player2Card, player1Card, ref p1Element);
        }

        if (CompareElements(p1Element, p2Element))
            return 1; // player 1 wins by element
        if (CompareElements(p2Element, p1Element))
            return -1; // player 2 wins by element

        // If elements are equal or neither wins, compare values
        if (player1Card.GetValue() > player2Card.GetValue())
            return 1;
        if (player2Card.GetValue() > player1Card.GetValue())
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