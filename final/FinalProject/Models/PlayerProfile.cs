using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Xml.Serialization;
using System.Text.Json;
using System.IO;

public class PlayerProfile : Character
{
    private List<int> _cardCollection { get; set; } // All cards the player owns
    private int _MMR { get; set; }  // Level based upon playing and winning against other players. Win ++ Lose --
    private int _level { get; set; } // level is not correlated with belt ranks, you get xp when you play a game and / or win. 
    private int _experiencePoints { get; set; } // Associated with level when you hit x amount of xp then you level up. 

    public PlayerProfile(string playerName) : base(playerName) // new player empty hands etc.
    {
        _MMR = 1000;
        _level = 1;
        _experiencePoints = 0;
    }

    public PlayerProfile(string playerName, BeltRank beltrank, Deck hand, List<int> cardCollection, int mmr, int level, int experiencePoints)
        : base(playerName, beltrank)
    {
        _hand = hand;
        _cardCollection = cardCollection;
        _MMR = mmr;
        _level = level;
        _experiencePoints = experiencePoints;
    }

    public void GetProfileSummary()
    {
        string profileSummary = $"    Player Name: {_playerName}\n    Belt Rank: {_beltRank}\n    MMR: {_MMR}\n    Level: {_level}";
        Console.WriteLine(profileSummary);
    }

    public static PlayerProfile LoadPlayerProfile(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        using (JsonDocument doc = JsonDocument.Parse(jsonString))
        {
            var root = doc.RootElement;

            string playerName = root.GetProperty("playerName").GetString();
            BeltRank beltRank = Enum.Parse<BeltRank>(root.GetProperty("beltRank").GetString());

            // Hand
            List<int> handList = new List<int>();
            foreach (var h in root.GetProperty("hand").EnumerateArray())
                handList.Add(h.GetInt32());
            Deck hand = new Deck(handList); // Adjust if your Deck constructor is different

            // Card Collection
            List<int> cardCollection = new List<int>();
            foreach (var c in root.GetProperty("cardCollection").EnumerateArray())
                cardCollection.Add(c.GetInt32());

            int mmr = root.GetProperty("mmr").GetInt32();
            int level = root.GetProperty("level").GetInt32();
            int experiencePoints = root.GetProperty("experiencePoints").GetInt32();

            return new PlayerProfile(playerName, beltRank, hand, cardCollection, mmr, level, experiencePoints);
        }
    }

    public override int PlayCard()
    {
        Console.WriteLine(this.GetHand().DisplayPlayableHand());
        Console.Write("Select Card by CardID: ");
        int cardChoice = int.Parse(Console.ReadLine());

        this.GetHand().RemoveCardFromPlayableHand(cardChoice);
        return cardChoice;
    }

    public void AlterMMR(bool didWin)
    {
        Random ran = new Random();
        int mmrIncrement = ran.Next(9, 12); // 9, 10, or 11
        if (didWin)
        {
            _MMR += mmrIncrement;
        }
        else
        {
            _MMR -= mmrIncrement;
        }
    }

    public int GetXPForNextLevel()
    {
        int baseXP = 100;
        double levelMultiplier = 1.2;
        return (int)(baseXP * Math.Pow(levelMultiplier, _level - 1));
    }

    public void AddExperiancePoints()
    {
        Random rand = new Random();
        int amount = rand.Next(30, 61);
        _experiencePoints += amount;
        while (_experiencePoints >= GetXPForNextLevel())
        {
            _experiencePoints -= GetXPForNextLevel();
            _level++;
            Console.WriteLine($"Level up! You are now level {_level}!");
        }
    }

    public void SaveToFile(string filePath)
    {
        this._hand.ClearPlayableHand();
        var playerData = new
        {
            playerName = _playerName,
            beltRank = _beltRank.ToString(),
            hand = _hand.GetHand(),
            cardCollection = _cardCollection,
            mmr = _MMR,
            level = _level,
            experiencePoints = _experiencePoints
        };
        string json = JsonSerializer.Serialize(playerData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}