public class PowerCard : Card
{
    private PowerCardEffectType _effectType;

    public PowerCard(int cardId, string name, ElementType element, int value, CardColor color, string imageUrl, string description, PowerCardEffectType effectType)
        : base(cardId, name, element, value, color, imageUrl, description)
    {
        _effectType = effectType;
    }
    public override void DisplayCardStats()
    {
        string cardDisplay = $"PowerCard: {_cardId} | Name: {_name} | Element: {_element} | Color: {_color} | Effect: {_effectType}";

        Console.WriteLine(cardDisplay);
    }
}