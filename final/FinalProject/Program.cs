using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");

        string cardsFilePath = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\card_Data\cj_allCards.json";
        CardDatabase.LoadAllCards(cardsFilePath);

        // foreach ((int id, Card card) in CardDatabase.AllCards)
        // {
        //     card.DisplayCardStats();
        // }

        // string player1FileName = @"final\FinalProject\playerFiles\player1.json";
        // PlayerProfile.LoadPlayerProfile(player1FileName);

        // string player2FileName = @"final\FinalProject\playerFiles\player2.json";
        // PlayerProfile.LoadPlayerProfile(player2FileName);

        GameManager game = new GameManager();
        game.Run();

    }
}