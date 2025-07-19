public class RegularCard : Card
{
    public RegularCard(int cardId, string name, ElementType element, int value, CardColor color, string description)
        : base(cardId, name, element, value, color, description)
    {
        // No additional fields for RegularCard
    }
    public override string DisplayCardStats()
    {
        string cardDisplay = $"Regular Card: {_cardId,-3} | Name: {_name,-20} | Value : {_value,-1} | Element: {_element,5} | Color: {_color,6}";
        return cardDisplay;
    }

    public override PowerCardEffectType GetPowerCardEffectType()
    {
        return PowerCardEffectType.None;
    }
}