using System.ComponentModel;
using System.Data.SqlTypes;
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
    public GameManager(PlayerProfile player1)
    {
        _player1 = player1;
        _player2 = null;
        _npcSensi = new Sensi($"{(BeltRank)((int)this._player1.GetBeltRank() + 1)} Sensi", (BeltRank)((int)this._player1.GetBeltRank() + 1));
    }

    public void StartPlayerVSPlayerGame() { /* ...use _player1 and _player2... */ }

    public bool ChallengeSensei()
    {
        bool gameRunning = true;

        _player1.GetHand().RefillPlayableHand();
        _npcSensi.GetHand().RefillPlayableHand();
        while (gameRunning)
        {
            int player1CardChoice = _player1.PlayCard();
            int npcSensiCardChoice = _npcSensi.PlayCard();

            GameVisuals.LoadingSpinner(3);
            Console.WriteLine($"{_player1.GetName()} Played: {CardDatabase.GetCardById(player1CardChoice).DisplayCardStats()}\n\n{_npcSensi.GetName()} Played: {CardDatabase.GetCardById(npcSensiCardChoice).DisplayCardStats()}");
            GameVisuals.LoadingSpinner(3);

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

            int winner = this.CheckWinner();

            if (winner == 1)
            {
                Console.WriteLine($"{_player1.GetName()} has Won!");
                gameRunning = false;
                Console.WriteLine($"{_player1.GetName()} Since you have beat the me the, {_npcSensi.GetBeltRank()} Sensi, you now recieve the {_npcSensi.GetBeltRank()} Belt");
                return true;
            }
            else if (winner == -1)
            {
                Console.WriteLine($"{_npcSensi.GetName()} has Won!");
                gameRunning = false;
                Console.WriteLine($"{_player1.GetName()} Since you have did not beat the me the, {_npcSensi.GetBeltRank()} Sensi, you do not recieve the {_npcSensi.GetBeltRank()} Belt try again...");
                return false;
            }
            DisplayRoundStanding();
        }
        return false;
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

    public int CheckWinner()
    {
        // Check player
        if (HasWinningSet(_player1Wins))
            return 1;
        // Check opponent
        if (HasWinningSet(_opponentWins))
            return -1;
        return 0;
    }

    private bool HasWinningSet(List<(ElementType element, CardColor color)> wins)
    {
        // Check for 3 different elements
        var uniqueElements = wins.Select(w => w.element).Distinct().ToList();
        if (uniqueElements.Count >= 3)
            return true;

        // Check for 3 different colors of the same element
        var elementGroups = wins.GroupBy(w => w.element);
        foreach (var group in elementGroups)
        {
            if (group.Select(w => w.color).Distinct().Count() >= 3)
                return true;
        }
        return false;
    }

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
        bool gameRunning = true;
        while (gameRunning)
        {
            string menuSTR = $"What would you like to do?\n  1. Player vs Player\n  2. Player vs Sensi\n  3. See {_player1.GetName()} stats";
            if (!(_player2 is null))
            {
                menuSTR += $"\n   4. See ${_player2.GetName()} stats\n  5. Quit";
            }
            else
            {
                menuSTR += "\n  4. Load 2nd Player\n  5. Quit";
            }
            menuSTR += "\nEnter your Choice: ";
            Console.WriteLine(menuSTR);
            int inputStr = int.Parse(Console.ReadLine());

            if (inputStr == 1) // PvP
            {
                StartPlayerVSPlayerGame();
            }
            else if (inputStr == 2) // PvE
            {

                BeltRank nextBeltRank = (BeltRank)((int)_player1.GetBeltRank() + 1);
                _npcSensi = new Sensi($"{nextBeltRank}Sensi", nextBeltRank);

                Console.Write($"You are currently a {_player1.GetBeltRank()} Belt.\nDo you wish to challenge the {nextBeltRank} Belt Sensi? (Yes y/ No n) > ");
                string userSensiDecision = Console.ReadLine();
                if (userSensiDecision.ToLower() == "y")
                {
                    bool results = ChallengeSensei();
                    if (results == true)
                    {
                        _player1.UpgradeBeltRank();
                        _npcSensi.UpgradeBeltRank();
                    }
                }
                else
                {
                    Console.WriteLine("Returning to Menu...");
                }
            }
            else if (inputStr == 3)
            {
                Console.WriteLine("Showing player stats...");
                _player1.GetProfileSummary();
            }
            else if ((inputStr == 4) && (!(_player2 is null)))
            {
                Console.WriteLine("Showing player stats...");
                _player2.GetProfileSummary();
            }
            else if ((inputStr == 4) && (_player2 is null))
            {
                Console.WriteLine("Enter Player 2's FilePath");
                string prePlayer2FilePath = Console.ReadLine();
                string player2FilePath = @$"{prePlayer2FilePath}";

                _player2 = PlayerProfile.LoadPlayerProfile(player2FilePath);
                Console.WriteLine($"{_player2.GetName()} has been loaded.");
            }

            else if (inputStr == 5)
            {
                Console.WriteLine("Exiting game. Goodbye!");
                gameRunning = false;
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1, 2, 3, 4, or 5.");
            }
        }
    }
}
