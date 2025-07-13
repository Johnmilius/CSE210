using System.Drawing;
using System.Runtime.CompilerServices;

public abstract class Card
{
    protected int _cardId { get; }
    protected string _name { get; }
    protected ElementType _element { get; }
    protected int _value { get; }
    protected CardColor _color { get; }
    protected string _imageUrl { get; }
    protected string _description { get; }

    public Card(int cardId, string name, ElementType element, int value, CardColor color, string imageUrl, string description)
    {
        _cardId = cardId;
        _name = name;
        _element = element;
        _value = value;
        _color = color;
        _imageUrl = imageUrl;
        _description = description;
    }

    public abstract void DisplayCardStats();
    public ElementType GetEffectivenessAgainst(int CardID)
    {
        // unfinished
        return ElementType.Snow;
    }
}