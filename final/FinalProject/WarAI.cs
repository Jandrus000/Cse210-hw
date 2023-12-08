public class WarAI: War{
                

    public WarAI(){
        System.Console.WriteLine("                                                                                     ,-.----.");         
        System.Console.WriteLine("           .---.                                                            ,----..  \\    /  \\  ");            
        System.Console.WriteLine("          /. ./|                                                           /   /   \\ |   :    \\          ,--,");            
        System.Console.WriteLine("      .--'.  ' ;             __  ,-.                                      |   :     :|   |  .\\ :       ,'_ /|");            
        System.Console.WriteLine("     /__./ \\ : |           ,' ,'/ /|             .---.  .--.--.           .   |  ;. /.   :  |: |  .--. |  | :");            
        System.Console.WriteLine(" .--'.  '   \' .  ,--.--.  '  | |' |           /.  ./| /  /    '          .   ; /--` |   |   \\ :,'_ /| :  . |");            
        System.Console.WriteLine("/___/ \\ |    ' ' /       \\ |  |   ,'         .-' . ' ||  :  /`./          ;   | ;    |   : .   /|  ' | |  . . ");            
        System.Console.WriteLine(";   \\  \\;      :.--.  .-. |'  :  /          /___/ \\: ||  :  ;_            |   : |    ;   | |`-' |  | ' |  | |");  
        System.Console.WriteLine(" \\   ;  `      | \\__\\/: . .|  | '           .   \\  ' . \\  \\    `.         .   | '___ |   | ;    :  | | :  ' ; ");
        System.Console.WriteLine("  .   \\    .\\  ; ,\" .--.; |;  : |            \\   \\   '  `----.   \\        '   ; : .'|:   ' |    |  ; ' |  | '");
        System.Console.WriteLine("   \\   \\   ' \\ |/  /  ,.  ||  , ;             \\   \\    /  /`--'  /        '   | '/  ::   : :    :  | : ;  ; | ");
        System.Console.WriteLine("    :   '  |--\";  :   .'   \\---'               \\   \\ |'--'.     /         |   :    / |   | :    '  :  `--'   \\ ");          
        System.Console.WriteLine("     \\   \\ ;   |  ,     .-./                    '---\"   `--'---'           \\   \\ .'  `---'.|    :  ,      .-./ ");
        System.Console.WriteLine("      '---\"     `--`---'                                                    `---`      `---`     `--`----'");
           
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
        
        if(GetCardRank(player1Card.GetFace()) == GetCardRank(player2Card.GetFace()))
        {
            
            System.Console.WriteLine("Its a tie!");
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

            }
        

        }
        if(GetCardRank(player1Card.GetFace()) > GetCardRank(player2Card.GetFace()))
        {
            foreach (var card in _middlePile.GetCards())
            {
                _player1Cards.AddNew(card);
            }
            _middlePile.Clear();
            System.Console.WriteLine($"{_players[_player1Index].GetName()} won this round");
        }
        else if(GetCardRank(player1Card.GetFace()) < GetCardRank(player2Card.GetFace()))
        {
            foreach (var card in _middlePile.GetCards())
            {
                _player2Cards.AddNew(card);
            }
            _middlePile.Clear();
            System.Console.WriteLine($"CPU won this round");
        }
    }

    public void DisplayDraw()
    {
        System.Console.WriteLine($"Player 1: {_players[_player1Index].GetName().PadRight(42)} Player 2: CPU");
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
        System.Console.WriteLine($"Player 1: {_players[_player1Index].GetName().PadRight(42)} Player 2: CPU");
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
        if(_player1Cards.Count() == 52)
        {
            _players[_player1Index].IncrementWins();
            // System.Console.Clear();
            System.Console.WriteLine($"\nCongrats {_players[_player1Index].GetName()}! You won!\nYou now have {_players[_player1Index].GetWins()} wins!");
            base.GameOver();
        }
        if(_player2Cards.Count() == 52)
        {
            // System.Console.Clear();
            System.Console.WriteLine("You lost, better luck next time");
            base.GameOver();
        }
    }
}