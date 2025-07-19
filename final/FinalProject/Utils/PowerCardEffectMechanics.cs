using System.Drawing;

public static class PowerCardEffectMechanics
{
    public static void PlayedPowerCardEffect(Card playedCard, Card opponentCard, ref ElementType opponentElement)
    {
        switch (playedCard.GetPowerCardEffectType())
        {
            case PowerCardEffectType.ChangeFireToSnowThisTurnOpponent:
                if (opponentCard.GetElement() == ElementType.Fire)
                {
                    opponentElement = ElementType.Snow;
                }
                break;
            case PowerCardEffectType.ChangeWaterToFireThisTurnOpponent:
                if (opponentCard.GetElement() == ElementType.Water)
                {
                    opponentElement = ElementType.Fire;
                }
                break;
            case PowerCardEffectType.ChangeSnowToWaterThisTurnOpponent:
                if (opponentCard.GetElement() == ElementType.Snow)
                {
                    opponentElement = ElementType.Water;
                }
                break;
        }
    }

    public static void ScoredPowerCardEffect(Card playedCard, Character user, Character opponent)
    {
        switch (playedCard.GetPowerCardEffectType())
        {
            case PowerCardEffectType.DiscardRandomFireCardOpponent:
                DiscardRandomCardOfElement(opponent, ElementType.Fire);
                break;
            case PowerCardEffectType.DiscardRandomWaterCardOpponent:
                DiscardRandomCardOfElement(opponent, ElementType.Water);
                break;
            case PowerCardEffectType.DiscardRandomSnowCardOpponent:
                DiscardRandomCardOfElement(opponent, ElementType.Snow);
                break;
            case PowerCardEffectType.DiscardRandomRedCardOpponent:
                DiscardRandomCardOfColor(opponent, CardColor.Red);
                break;
            case PowerCardEffectType.DiscardAllRedOpponentCards:
                DiscardAllCardsOfColor(opponent, CardColor.Red);
                break;
            case PowerCardEffectType.DiscardRandomBlueCardOpponent:
                DiscardRandomCardOfColor(opponent, CardColor.Blue);
                break;
            case PowerCardEffectType.DiscardAllBlueOpponentCards:
                DiscardAllCardsOfColor(opponent, CardColor.Blue);
                break;
            case PowerCardEffectType.DiscardRandomYellowCardOpponent:
                DiscardRandomCardOfColor(opponent, CardColor.Yellow);
                break;
            case PowerCardEffectType.DiscardAllYellowOpponentCards:
                DiscardAllCardsOfColor(opponent, CardColor.Yellow);
                break;
            case PowerCardEffectType.DiscardRandomGreenCardOpponent:
                DiscardRandomCardOfColor(opponent, CardColor.Green);
                break;
            case PowerCardEffectType.DiscardAllGreenOpponentCards:
                DiscardAllCardsOfColor(opponent, CardColor.Green);
                break;
            case PowerCardEffectType.DiscardRandomOrangeCardOpponent:
                DiscardRandomCardOfColor(opponent, CardColor.Orange);
                break;
            case PowerCardEffectType.DiscardAllOrangeOpponentCards:
                DiscardAllCardsOfColor(opponent, CardColor.Orange);
                break;
            case PowerCardEffectType.DiscardRandomPurpleCardOpponent:
                DiscardRandomCardOfColor(opponent, CardColor.Purple);
                break;
            case PowerCardEffectType.DiscardAllPurpleOpponentCards:
                DiscardAllCardsOfColor(opponent, CardColor.Purple);
                break;
            case PowerCardEffectType.BlockFireNextTurnOpponent:
                // Implement block fire logic
                break;
            case PowerCardEffectType.BlockWaterNextTurnOpponent:
                // Implement block water logic
                break;
            case PowerCardEffectType.BlockSnowNextTurnOpponent:
                // Implement block snow logic
                break;
            case PowerCardEffectType.NextCardValueUp2User:
                // Implement next card value up logic
                break;
            case PowerCardEffectType.NextCardValueDown2Opponent:
                // Implement next card value down logic
                break;
        }
    }

    public static void DiscardRandomCardOfElement(Character opponent, ElementType element)
    {
        opponent.GetHand().RemoveRandomCardOfElement(element);
    }
    public static void DiscardAllCardsOfColor(Character opponent, CardColor color)
    {
        opponent.GetHand().RemoveAllCardsOfColor(color);
    }
    public static void DiscardRandomCardOfColor(Character opponent, CardColor color)
    {
        opponent.GetHand().RemoveRandomCardOfColor(color);
    }
}
