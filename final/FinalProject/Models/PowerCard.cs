public class PowerCard : Card
{
    private PowerCardEffectType _effectType;

    public PowerCard(int cardId, string name, ElementType element, int value, CardColor color, string imageUrl, string description, PowerCardEffectType effectType)
        : base(cardId, name, element, value, color, imageUrl, description)
    {
        _effectType = effectType;
    }
    public override string DisplayCardStats()
    {
        string cardDisplay = $"Power Card: {_cardId} | Name: {_name} | Value : {_value} | Element: {_element} | Color: {_color} | Effect: {_effectType}";
        return cardDisplay;
    }
}