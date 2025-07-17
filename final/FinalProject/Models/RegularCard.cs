public class RegularCard : Card
{
    public RegularCard(int cardId, string name, ElementType element, int value, CardColor color, string imageUrl, string description)
        : base(cardId, name, element, value, color, imageUrl, description)
    {
        // No additional fields for RegularCard
    }
    public override string DisplayCardStats()
    {
        string cardDisplay = $"Regular Card: {_cardId, -3} | Name: {_name, -20} | Value : {_value, -1} | Element: {_element, 5} | Color: {_color, 6}";
        return cardDisplay;
    }
}