public static class CardDatabase
{
    public static Dictionary<int, Card> AllCards { get; private set; }

    public static void LoadAllCards(string filePath)
    {
        // Load cards from JSON and populate AllCards
    }
}