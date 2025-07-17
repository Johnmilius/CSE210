using System.ComponentModel;
using System.Diagnostics.Tracing;

public class GameManager
{
    private PlayerProfile _player1;
    private PlayerProfile _player2;
    private Sensi _npcSensi;

    // Track round wins for each player: List of (element, color) tuples
    private List<(ElementType element, CardColor color)> _player1Wins = new List<(ElementType, CardColor)>();
    private List<(ElementType element, CardColor color)> _opponentWins = new List<(ElementType, CardColor)>();

    // Player vs Player constructor
    public GameManager(PlayerProfile player1, PlayerProfile player2)
    {
        _player1 = player1;
        _player2 = player2;
        _npcSensi = null;
    }

    // Player vs Sensei constructor
    public GameManager(PlayerProfile player1, BeltRank sensiBeltRank)
    {
        _player1 = player1;
        _player2 = null;
        _npcSensi = new Sensi($"{sensiBeltRank}Sensi", sensiBeltRank);
    }

    public void StartPlayerVSPlayerGame() { /* ...use _player1 and _player2... */ }

    public void PlayRound() { /* ... */ }

    public void ChallengeSensei()
    {
        bool didWin = false;
        bool gameRunning = true;

        _player1.GetHand().RefillPlayableHand();
        _npcSensi.GetHand().RefillPlayableHand();
        while (gameRunning)
        {
            int player1CardChoice = _player1.PlayCard();
            int npcSensiCardChoice = _npcSensi.PlayCard();

            int whoWon = GameMechanics.CompareCards(player1CardChoice, npcSensiCardChoice);

            if (whoWon == 1)
            {
                // player1 won logic
                var card = CardDatabase.GetCardById(player1CardChoice);
                _player1Wins.Add((card.GetElement(), card.GetColor()));
                Console.WriteLine($"You won the round with {card.GetElement()} ({card.GetColor()})!");
            }
            else if (whoWon == -1)
            {
                // sensi win logic
                var card = CardDatabase.GetCardById(npcSensiCardChoice);
                _opponentWins.Add((card.GetElement(), card.GetColor()));
                Console.WriteLine($"Sensei won the round with {card.GetElement()} ({card.GetColor()})!");
            }
            else
            {
                // tie logic
                Console.WriteLine("It's a tie!");
            }

            // Reset Hands and Check if someone won
            _player1.GetHand().RefillPlayableHand();
            _npcSensi.GetHand().RefillPlayableHand();

            DisplayRoundStanding();
            this.CheckWinner();
        }
    }

    // Displays the current round standing for both players
    private void DisplayRoundStanding()
    {
        Console.WriteLine("\n--- Round Standing ---");
        Console.WriteLine($"Player Wins: {_player1Wins.Count}");
        Console.WriteLine($"Sensei Wins: {_opponentWins.Count}");
        Console.WriteLine("Player Element Wins:");
        DisplayElementColorWins(_player1Wins);
        Console.WriteLine("Sensei Element Wins:");
        DisplayElementColorWins(_opponentWins);
        Console.WriteLine("----------------------\n");
    }

    // Helper to display which elements/colors have been won
    private void DisplayElementColorWins(List<(ElementType element, CardColor color)> wins)
    {
        var elementGroups = wins.GroupBy(w => w.element);
        foreach (var group in elementGroups)
        {
            var colors = string.Join(", ", group.Select(w => w.color.ToString()).Distinct());
            Console.WriteLine($"  {group.Key}: {colors}");
        }
        if (!wins.Any())
            Console.WriteLine("  None");
    }

    public void CheckWinner() { /* ... */ }

    public void SetTextColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void ResetTextColor()
    {
        Console.ResetColor();
    }

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
                string player1FileName = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\playerFiles\player1.json";
                string player2FileName = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\playerFiles\player2.json";
                _player1 = PlayerProfile.LoadPlayerProfile(player1FileName);
                _player2 = PlayerProfile.LoadPlayerProfile(player2FileName);
                _npcSensi = null;
                StartPlayerVSPlayerGame();
            }
            else if (inputStr == 2)
            {
                string player1FileName = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\playerFiles\player1.json";
                _player1 = PlayerProfile.LoadPlayerProfile(player1FileName);
                _player2 = null;
                BeltRank nextBeltRank = (BeltRank)((int)_player1.GetBeltRank() + 1);
                _npcSensi = new Sensi($"{nextBeltRank}Sensi", nextBeltRank);

                Console.Write($"You are currently a {_player1.GetBeltRank()} Belt.\nDo you wish to challenge the {nextBeltRank} Belt Sensi? (Yes y/ No n) > ");
                string userSensiDecision = Console.ReadLine();
                if (userSensiDecision.ToLower() == "y")
                {
                    ChallengeSensei();
                }
                else
                {
                    Console.WriteLine("Returning to Menu...");
                }
            }
            else if (inputStr == 3)
            {
                Console.WriteLine("Showing player stats...");
                string player1FileName = @"C:\Users\jwmil\OneDrive\Desktop\BYU-I Spring 2025\CSE210\final\FinalProject\playerFiles\player1.json";
                _player1 = PlayerProfile.LoadPlayerProfile(player1FileName);
                _player1.GetProfileSummary();
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
