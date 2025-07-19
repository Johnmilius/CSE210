public enum PowerCardEffectType
{
    None,
    NextCardValueUp2User,
    NextCardValueDown2Opponent,

    LowerValueCardWins,

    // scored effects
    DiscardRandomFireCardOpponent,
    DiscardRandomWaterCardOpponent,
    DiscardRandomSnowCardOpponent,

    DiscardRandomRedCardOpponent,
    DiscardAllRedOpponentCards,

    DiscardRandomBlueCardOpponent,
    DiscardAllBlueOpponentCards,

    DiscardRandomYellowCardOpponent,
    DiscardAllYellowOpponentCards,

    DiscardRandomGreenCardOpponent,
    DiscardAllGreenOpponentCards,

    DiscardRandomOrangeCardOpponent,
    DiscardAllOrangeOpponentCards,

    DiscardRandomPurpleCardOpponent,
    DiscardAllPurpleOpponentCards,
    BlockFireNextTurnOpponent,
    BlockWaterNextTurnOpponent,
    BlockSnowNextTurnOpponent,

    // played effects
    ChangeFireToSnowThisTurnOpponent,
    ChangeSnowToWaterThisTurnOpponent,
    ChangeWaterToFireThisTurnOpponent,

    //currently isnt in the game
    PowerReverse
}
