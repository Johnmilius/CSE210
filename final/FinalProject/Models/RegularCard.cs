public class RegularCard : Card
{
    public RegularCard(int cardId, string name, ElementType element, int value, CardColor color, string imageUrl, string description)
        : base(cardId, name, element, value, color, imageUrl, description)
    {
        // No additional fields for RegularCard
    }



    public override void DisplayCardStats()
    {
        string cardDisplay = $"Card: {_cardId} | Name: {_name} | Element: {_element} | Color: {_color}";

        Console.WriteLine(cardDisplay);
    }

}