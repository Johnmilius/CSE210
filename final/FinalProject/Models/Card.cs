public abstract class Card
{
    private int _cardId;
    private string _name;
    private ElementType _element;
    private int _value;
    private CardColor _color;
    private string _imageUrl;
    private string _description;

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
}