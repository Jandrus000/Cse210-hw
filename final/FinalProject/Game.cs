using System.ComponentModel;
using System.Diagnostics.Metrics;

public class Game{
    private List<Player> _players = new List<Player>();
    private int _player1Index;
    protected List<Card> _player1Cards;

    protected bool _win = false;


    public Game()
    {
        LoadPlayers();
        DisplayPlayers();
        System.Console.WriteLine();
        bool invalidChoice = true;
        string playerChoice = "";
        while(invalidChoice)
        {
            System.Console.Write("Which player would you like to choose? (Enter number) ");
            playerChoice = System.Console.ReadLine();
            try{
            int choiceIndex = Int32.Parse(playerChoice)-1;
            if(choiceIndex == _players.Count())
            {
                System.Console.Write("What's the name of the new player? ");
                string playerName = System.Console.ReadLine();
                Player newPlayer = new Player(playerName);
                _players.Add(newPlayer);
            }
            else{
                System.Console.WriteLine($"Welcome {_players[choiceIndex].GetName()}!");
                _player1Index = choiceIndex;
            }
            invalidChoice = false;

            }catch{
                System.Console.WriteLine("Invalid choice, try again");
            }
         }
        
    }


    public virtual void DisplayTurn()
    {

    }


    public virtual void NextTurn()
    {

    }

    public virtual void GameOver()
    {
        _players[_player1Index].IncrementWins();
        System.Console.Clear();
        System.Console.WriteLine($"\nCongrats {_players[_player1Index].GetName()}! You won!\nYou now have {_players[_player1Index].GetWins()} wins!");
        SavePlayers();
        _win = true;
    }

    public bool GetWin()
    {
        return _win;
    }

    public void SavePlayers()
    {
        using (var writer = new StreamWriter(@"players.txt"))
        {
            foreach(var player in _players)
            {
                writer.WriteLine($"{player.GetWins()},{player.GetName()}");
            }
            
            writer.Close();
        }
    }

    public void LoadPlayers()
    {
        string[] lines = System.IO.File.ReadAllLines("players.txt");
        for (int i =0; i < lines.Length; i++)
        {
            
            string[] playerInfo = lines[i].Split(",");
            Player player = new Player(playerInfo[1]);
            player.SetWins(Int32.Parse(playerInfo[0]));
            _players.Add(player);
        }
    }

    public void AddNewPlayer()
    {
        System.Console.Write("What is your player name? ");
        string newPlayer = Console.ReadLine();
        Player player = new Player(newPlayer);
        _players.Add(player);
        player.SavePlayer();

    }

    public void DisplayPlayers()
    {
        int counter = 1;
        foreach (var player in _players)
        {
            System.Console.WriteLine($"{counter}. {player.GetName()}");
            counter++;
        }
        System.Console.WriteLine($"{counter}. New player");
    }
}