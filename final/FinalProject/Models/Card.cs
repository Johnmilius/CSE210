using System.Drawing;
using System.Runtime.CompilerServices;

public abstract class Card
{
    protected int _cardId { get; }
    protected string _name { get; }
    protected ElementType _element { get; }
    protected int _value { get; }
    protected CardColor _color { get; }
    protected string _description { get; }

    public Card(int cardId, string name, ElementType element, int value, CardColor color, string description)
    {
        _cardId = cardId;
        _name = name;
        _element = element;
        _value = value;
        _color = color;
        _description = description;
    }

    public abstract string DisplayCardStats();

    public int GetCardId() => _cardId;
    public string GetName() => _name;
    public ElementType GetElement() => _element;
    public int GetValue() => _value;
    public CardColor GetColor() => _color;
    public string GetDescription() => _description;
    public abstract PowerCardEffectType GetPowerCardEffectType();
}