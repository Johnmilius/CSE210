using System.Text.Json;
using System.Text.Json.Nodes;
using System.IO;

public static class CardDatabase
{
    public static Dictionary<int, Card> AllCards { get; private set; }

    public static void LoadAllCards(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var cardsArray = JsonNode.Parse(json).AsArray();
        var allCards = new Dictionary<int, Card>();

        foreach (var cardNode in cardsArray)
        {
            int cardId = cardNode["cardId"].GetValue<int>();
            string name = cardNode["name"]?.GetValue<string>() ?? string.Empty;
            ElementType element = Enum.Parse<ElementType>(cardNode["ElementType"].GetValue<string>());
            int value = cardNode["value"].GetValue<int>();
            CardColor color = Enum.Parse<CardColor>(cardNode["CardColor"].GetValue<string>());
            string imageUrl = cardNode["imageUrl"]?.GetValue<string>() ?? string.Empty;
            string description = cardNode["description"]?.GetValue<string>() ?? string.Empty;

            if (cardNode["PowerCardEffectType"] != null)
            {
                PowerCardEffectType effectType = Enum.Parse<PowerCardEffectType>(cardNode["PowerCardEffectType"].GetValue<string>());
                allCards[cardId] = new PowerCard(cardId, name, element, value, color, imageUrl, description, effectType);
            }
            else
            {
                allCards[cardId] = new RegularCard(cardId, name, element, value, color, imageUrl, description);
            }
        }
        AllCards = allCards;
    }
}