using System;

class Program
{
    static void Main(string[] args)
    {
        string cardsFilePath = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\card_Data\cj_allCards.json";
        CardDatabase.LoadAllCards(cardsFilePath);



        // PvP
        // string player1File = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\playerFiles\player1.json";
        // string player2File = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\playerFiles\player2.json";
        // PlayerProfile player1 = PlayerProfile.LoadPlayerProfile(player1File);
        // PlayerProfile player2 = PlayerProfile.LoadPlayerProfile(player2File);

        // var gm = new GameManager(player1, player2);
        // gm.Run();


        //PvE
        string player1File = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\playerFiles\player1.json";
        PlayerProfile player1 = PlayerProfile.LoadPlayerProfile(player1File);

        var gm = new GameManager(player1, BeltRank.White); // or whatever rank
        gm.Run();

    }
}