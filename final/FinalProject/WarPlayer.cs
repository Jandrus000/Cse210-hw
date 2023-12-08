using System.ComponentModel;
using Microsoft.VisualBasic;

public class WarPlayer: War{

    protected int _player2Index;
    public WarPlayer(){
        System.Console.WriteLine();
        System.Console.WriteLine("---Pick a second player---");
        _player2Index = PlayerPicker();
        SavePlayers();

        System.Console.WriteLine("                                                                          ,-.----.                                                     ");
        System.Console.WriteLine("           .---.                                                          \\    /  \\    ,--,                                            ");
        System.Console.WriteLine("          /. ./|                                                          |   :    \\ ,--.'|                                            ");
        System.Console.WriteLine("      .--'.  ' ;             __  ,-.                                      |   |  .\\ :|  | :                                    __  ,-. ");
        System.Console.WriteLine("     /__./ \\ : |           ,' ,'/ /|             .---.  .--.--.           .   :  |: |:  : '                                  ,' ,'/ /| ");
        System.Console.WriteLine(" .--'.  '   \' .  ,--.--.  '  | |' |           /.  ./| /  /    '          |   |   \\ :|  ' |     ,--.--.        .--,   ,---.  '  | |' | ");
        System.Console.WriteLine("/___/ \\ |    ' ' /       \\ |  |   ,'         .-' . ' ||  :  /`./          |   : .   /'  | |    /       \\     /_ ./|  /     \\ |  |   ,' ");
        System.Console.WriteLine(";   \\  \\;      :.--.  .-. |'  :  /          /___/ \\: ||  :  ;_            ;   | |`-' |  | :   .--.  .-. | , ' , ' : /    /  |'  :  /   ");
        System.Console.WriteLine(" \\   ;  `      | \\__\\/: . .|  | '           .   \\  ' . \\  \\    `.         |   | ;    '  : |__  \\__\\/: . ./___/ \\: |.    ' / ||  | '    ");
        System.Console.WriteLine("  .   \\    .\\  ; ,\" .--.; |;  : |            \\   \\   '  `----.   \\        :   ' |    |  | '.'| ,\" .--.; | .  \\  ' |'   ;   /|;  : |    ");
        System.Console.WriteLine("   \\   \\   ' \\ |/  /  ,.  ||  , ;             \\   \\    /  /`--'  /        :   : :    ;  :    ;/  /  ,.  |  \\  ;   :'   |  / ||  , ;    ");
        System.Console.WriteLine("    :   '  |--\";  :   .'   \\---'               \\   \\ |'--'.     /         |   | :    |  ,   /;  :   .'   \\  \\  \\  ;|   :    | ---'     ");
        System.Console.WriteLine("     \\   \\ ;   |  ,     .-./                    '---\"   `--'---'          `---'.|     ---`-' |  ,     .-./   :  \\  \\   \\  /           ");
        System.Console.WriteLine("      '---\"     `--`---'                                                    `---`             `--`---'        \\  ' ; `----'            ");
        System.Console.WriteLine("                                                                                                               `--`                    ");
        ReadySetGo(); 
    }

    public override void NextTurn()
    {
        Card player1Card = _player1Cards.GetCards()[0];
        Card player2Card = _player2Cards.GetCards()[0];

        _middlePile.AddNew(player1Card);
        _middlePile.AddNew(player2Card);
        _player1Cards.RemoveCardAt(0);
        _player2Cards.RemoveCardAt(0);

        int winnerIndex = -1;
        
        if(GetCardRank(player1Card.GetFace()) == GetCardRank(player2Card.GetFace()))
        {
            Thread.Sleep(750);
            System.Console.WriteLine("Its a tie!");
            Thread.Sleep(750);
            System.Console.WriteLine("That means war!");
            for(int i=0;i<3;i++)
            {
                
                if(_player1Cards.Count()>1){
                    _middlePile.AddNew(_player1Cards.GetCards()[0]);
                    _player1Cards.RemoveCardAt(0);
                }
                if(_player2Cards.Count()>1)
                {
                    _middlePile.AddNew(_player2Cards.GetCards()[0]);
                
                    _player2Cards.RemoveCardAt(0);
                }
                
                DisplayTurn();
                Thread.Sleep(500);
            }
        

        }
        else if(GetCardRank(player1Card.GetFace()) > GetCardRank(player2Card.GetFace()))
        {
            foreach (var card in _middlePile.GetCards())
            {
                _player1Cards.AddNew(card);
            }
            winnerIndex = _player1Index; 
        }
        else{
            foreach (var card in _middlePile.GetCards())
            {
                _player2Cards.AddNew(card);
            }
            winnerIndex = _player2Index;
        }
        if(GetCardRank(player1Card.GetFace()) > GetCardRank(player2Card.GetFace()) || GetCardRank(player1Card.GetFace()) < GetCardRank(player2Card.GetFace()))
        {
            _middlePile.Clear();
            System.Console.Write($"{_players[winnerIndex].GetName()} won this round");
            Thread.Sleep(1500);
        }
    }

    public void DisplayDraw()
    {
        System.Console.Clear();
        System.Console.WriteLine($"Player 1: {_players[_player1Index].GetName().PadRight(42)} Player 2: {_players[_player2Index].GetName()}");
        var p1CardCount = (_player1Cards.Count()-1).ToString();
        var p2CardCount = (_player2Cards.Count()-1).ToString();
        
        System.Console.WriteLine($"{p1CardCount.PadLeft(6).PadRight(37)}{_middlePile.Count().ToString().PadRight(31)}{p2CardCount}");
        for (int l=0; l<9 ; l++)
        {
            System.Console.Write(_player1Cards.GetCards()[0].GetBackDisplay()[l]);
            System.Console.Write(_player1Cards.GetCards()[0].GetDisplay()[l]);
            for (int i=0;i<10;i++)
            {
                System.Console.Write(" ");
            }
            if(_middlePile.Count()==0)
            {
                for(int i=0; i < 11;i++)
                {
                    System.Console.Write(" ");
                } 
            }
            else
            {
                System.Console.Write(_player1Cards.GetCards()[0].GetBackDisplay()[l]);
            }
            for (int i=0;i<10;i++)
            {
                System.Console.Write(" ");
            }
            System.Console.Write(_player2Cards.GetCards()[0].GetDisplay()[l]);
            System.Console.Write(_player2Cards.GetCards()[0].GetBackDisplay()[l]);
            System.Console.WriteLine();
        }
    }

    public override void DisplayTurn()
    {
        System.Console.Clear();
        System.Console.WriteLine($"Player 1: {_players[_player1Index].GetName().PadRight(42)} Player 2: {_players[_player2Index].GetName()}");
        var p1CardCount = _player1Cards.Count().ToString();
        var p2CardCount = _player2Cards.Count().ToString();
        var emptySpot = "           ";
        
        System.Console.WriteLine($"{p1CardCount.PadLeft(6).PadRight(37)}{_middlePile.Count().ToString().PadRight(31)}{p2CardCount}");
        for (int l=0; l<9 ; l++)
        {
            
            System.Console.Write(_player1Cards.GetCards()[0].GetBackDisplay()[l]);
            System.Console.Write(emptySpot);
            for (int i=0;i<10;i++)
            {
                System.Console.Write(" ");
            }
            if(_middlePile.Count()==0)
            {
                for(int i=0; i < 11;i++)
                {
                    System.Console.Write(" ");
                } 
                
            }
            else
            {
                System.Console.Write(_player1Cards.GetCards()[0].GetBackDisplay()[l]);
            }
            for (int i=0;i<10;i++)
            {
                System.Console.Write(" ");
            }
            System.Console.Write(emptySpot);
            System.Console.Write(_player2Cards.GetCards()[0].GetBackDisplay()[l]);
            System.Console.WriteLine();
        }
    }
    public override void GameOver()
    {
        int winningIndex = -1;
        if(_player1Cards.Count() == 52)
        {
            winningIndex = _player1Index;;
        }
        if(_player2Cards.Count() == 52)
        {
            winningIndex = _player2Index;
        }
        if(_player1Cards.Count() == 52 || _player2Cards.Count() == 52)
        {
            _players[winningIndex].IncrementWins();
            System.Console.Clear();
            System.Console.WriteLine($"\nCongrats {_players[winningIndex].GetName()}! You won!\nYou now have {_players[winningIndex].GetWins()} wins!");
            base.GameOver();
        }
        
    }

}

