public class PowerCard : Card
{
    private PowerCardEffectType _effectType;

    public PowerCard(int cardId, string name, ElementType element, int value, CardColor color, string description, PowerCardEffectType effectType)
        : base(cardId, name, element, value, color, description)
    {
        _effectType = effectType;
    }
    public override string DisplayCardStats()
    {
        string cardDisplay = $"Power Card:   {_cardId,-3} | Name: {_name,-20} | Value : {_value,-1} | Element: {_element,-5} | Color: {_color,-6} | Effect: {_effectType}";
        return cardDisplay;
    }

    public override PowerCardEffectType GetPowerCardEffectType()
    {
        return _effectType;
    }
}