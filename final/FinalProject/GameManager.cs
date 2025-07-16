using System.ComponentModel;
using System.Diagnostics.Tracing;

public class GameManager
{
    public void StartPlayerVSPlayerGame(PlayerProfile player1, PlayerProfile player2) { /* ... */ }
    public void PlayRound() { /* ... */ }
    public void ChallengeSensei(PlayerProfile player1, BeltRank sensiBeltRank) { /* ... */ }
    public void DetermineWinner() { /* ... */ }

    public void Run()
    {


        string cardsFilePath = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\card_Data\cj_allCards.json";
        CardDatabase.LoadAllCards(cardsFilePath);

        bool gameRunning = true;
        while (gameRunning)
        {
            Console.WriteLine("What would you like to do? ");
            Console.WriteLine("  1. Player vs Player\n  2. Player vs Sensi\n  3. See player stats\n  4. Quit");
            Console.Write("Enter your choice: ");
            int inputStr = int.Parse(Console.ReadLine());


            if (inputStr == 1)
            {
                //player initializing
                string player1FileName = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\playerFiles\player1.json";
                string player2FileName = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\playerFiles\player2.json";
                PlayerProfile player1 = PlayerProfile.LoadPlayerProfile(player1FileName);
                PlayerProfile player2 = PlayerProfile.LoadPlayerProfile(player2FileName);

                StartPlayerVSPlayerGame(player1, player2); // Player vs Player

            }


            else if (inputStr == 2)
            {
                string player1FileName = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\playerFiles\player1.json";
                PlayerProfile player1 = PlayerProfile.LoadPlayerProfile(player1FileName);
                BeltRank nextBeltRank = (BeltRank)((int)player1.GetBeltRank() + 1);

                Console.WriteLine($"You are currently {player1.GetBeltRank()}, Do you wish to challenge the {nextBeltRank} Sensi?");

                ChallengeSensei(player1, nextBeltRank); // Player vs Sensi
            }


            else if (inputStr == 3)
            {
                // Show player stats (implement as needed)
                Console.WriteLine("Showing player stats...");

                string player1FileName = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\playerFiles\player1.json";
                PlayerProfile player1 = PlayerProfile.LoadPlayerProfile(player1FileName);

                player1.GetProfileSummary();
            }


            else if (inputStr == 4)
            {
                Console.WriteLine("Exiting game. Goodbye!");
                gameRunning = false;
                break;
            }


            else
            {
                Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
            }
        }
    }
}
