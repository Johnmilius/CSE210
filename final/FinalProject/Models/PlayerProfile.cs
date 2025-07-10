using System.Collections.Generic;

public class PlayerProfile : Character
{
    private List<int> _cardCollection; // All cards the player owns
    private Deck _hand;            // The player's current hand/deck for the game
    private int _MMR; // Level based upon playing and winning against other players. Win ++ Lose --
    private int _level; // level is not correlated with belt ranks, you get xp when you play a game and / or win. 
    private int _experiencePoints; // Associated with level when you hit x amount of xp then you level up. 

    public PlayerProfile(string playerName) : base(playerName) // new player empty hands etc.
    { }

    public PlayerProfile(string playerName, BeltRank beltrank, Deck hand, List<int> cardCollection, int mmr, int level, int experiencePoints)
        : base(playerName, beltrank)
    {
        _hand = hand;
        _cardCollection = cardCollection;
        _MMR = mmr;
        _level = level;
        _experiencePoints = experiencePoints;
    }

}
