using System;

public class Character
{
    private string _playerName;
    private BeltRank _beltRank; // You level up when you beat the sensi at that belt rank. 
    public Character(string playerName) // new player
    {
        _playerName = playerName;
        _beltRank = White;
        _level = 0;
        _experiencePoints = 0;
    }

    public Character(string playerName, BeltRank beltRank, int level, int experiencePoints) //player with stats saved somewhere. 
    {
        _playerName = playerName;
        _beltRank = beltRank;
        _level = level;
        _experiencePoints = experiencePoints;
    }
}
