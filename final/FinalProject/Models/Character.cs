using System;

public class Character
{
    protected string _playerName { get; set; }
    protected BeltRank _beltRank { get; set; } // You level up when you beat the sensi at that belt rank. 
    protected Deck _hand { get; set; }            // The player's current hand/deck for the game
    public Character(string playerName) // new player
    {
        _playerName = playerName;
        _beltRank = BeltRank.White;
    }

    public Character(string playerName, BeltRank beltRank) //player with stats saved somewhere. 
    {
        _playerName = playerName;
        _beltRank = beltRank;
    }
    
    public Deck GetHand()
    {
        return _hand;
    }
}
