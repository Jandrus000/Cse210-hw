using System.ComponentModel;
using System.Diagnostics.Metrics;

public class Game{
    protected List<Player> _players = new List<Player>();
    protected int _player1Index =-1;
    protected Deck _player1Cards;
    private bool _playersLoaded = false;    
    protected bool _win = false;



    public Game()
    {
        Deck newDeck = new Deck();
        newDeck.Shuffle();
        _player1Cards = newDeck;
        System.Console.WriteLine("\nBefore we start...");
        _player1Index = PlayerPicker();

    }

    public void ReadySetGo()
    {
        System.Console.WriteLine();
        System.Threading.Thread.Sleep(1000); 
        System.Console.WriteLine("Ready");    
        System.Threading.Thread.Sleep(1000); 
        System.Console.WriteLine("Set");  
        System.Threading.Thread.Sleep(1000); 
        System.Console.WriteLine("Go!");    
        System.Threading.Thread.Sleep(1000);  
    }
    public int PlayerPicker()
    {
        System.Console.WriteLine("Player List:");
        if(!_playersLoaded)
        {
            LoadPlayers();
            _playersLoaded = true;
        }
        
        DisplayPlayers();
        System.Console.WriteLine();
        bool invalidChoice = true;
        string playerChoice = "";
        int playerIndex = -1;
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
                if(choiceIndex == _player1Index)
                {
                    System.Console.WriteLine($"{_players[_player1Index]} has already been chosen");
                }
                if(choiceIndex > -1 && choiceIndex <= _players.Count() && choiceIndex != _player1Index)
                {
                    
                    System.Console.WriteLine($"Welcome {_players[choiceIndex].GetName()}!");
                    playerIndex = choiceIndex;
                    invalidChoice = false;
                }
        
                

            }catch{
                System.Console.WriteLine("Invalid choice, try again");
            }

         }
        

         return playerIndex;
    }

    public virtual void DisplayTurn()
    {

    }


    public virtual void NextTurn()
    {

    }

    public virtual void GameOver()
    {
        
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