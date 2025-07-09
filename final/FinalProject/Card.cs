public abstract class Card
{
    private int _cardId;
    private string _name;
    private string _element;
    private int _value;
    private string _color;
    private string _imageUrl;
    private string _description;

    public Card()
    {

    }

    public Card(int cardId, string name, string element, int value, string color, string effect, string imageUrl, string description)
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