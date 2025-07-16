public class RegularCard : Card
{
    public RegularCard(int cardId, string name, ElementType element, int value, CardColor color, string imageUrl, string description)
        : base(cardId, name, element, value, color, imageUrl, description)
    {
        // No additional fields for RegularCard
    }
    public override string DisplayCardStats()
    {
        string cardDisplay = $"Regular Card: {_cardId} | Name: {_name} | Value : {_value} | Element: {_element} | Color: {_color}";
        return cardDisplay;
    }
}