using System;

// ! NOTICE ! YOU MAY NEED TO CHANGE FILE PATHS
// The Program would only work for me with full file paths. 
// You will need to change the file paths to match your own system.
// The card_Data and playerFiles folders should be in the FinalProject folder.
// Note you will need to change the file paths in the program class -> On lines 15, 19 and 20. 
// and in the GameManager class -> On Lines 100 and 102.
// 


class Program
{
    static void Main(string[] args)
    {
        string cardsFilePath = @"card_Data\cj_fakeAllCards.json";
        CardDatabase.LoadAllCards(cardsFilePath);

        // PvP
        string player1File = @"playerFiles\player1.json";
        string player2File = @"playerFiles\player2.json";
        PlayerProfile player1 = PlayerProfile.LoadPlayerProfile(player1File);
        PlayerProfile player2 = PlayerProfile.LoadPlayerProfile(player2File);

        var gm = new GameManager(player1, player2);
        gm.Run();
    }
}