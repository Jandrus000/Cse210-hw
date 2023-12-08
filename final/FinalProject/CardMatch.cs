using System.Dynamic;
using System.Xml;

public class CardMatch: Game
{

    //get rid of matched cards
    private Deck _matchedCards = new Deck(new List<Card>());

    public CardMatch()
    {
        System.Console.WriteLine("                                                                                                            ,---,");         
        System.Console.WriteLine("                                                                                                          ,`--.' |");            
        System.Console.WriteLine("                                                          ____                ___                ,---,    |   :  :");            
        System.Console.WriteLine("                                   ,---,                ,'  , `.            ,--.'|_            ,--.' |    '   '  ;");            
        System.Console.WriteLine("                        __  ,-.  ,---.'|             ,-+-,.' _ |            |  | :,'           |  |  :    |   |  |");            
        System.Console.WriteLine("                      ,' ,'/ /|  |   | :          ,-+-. ;   , ||            :  : ' :           :  :  :    '   :  ;");            
        System.Console.WriteLine("   ,---.     ,--.--.  '  | |' |  |   | |         ,--.'|'   |  || ,--.--.  .;__,'  /     ,---.  :  |  |,--.|   |  '");            
        System.Console.WriteLine("  /     \\   /       \\ |  |   ,',--.__| |        |   |  ,', |  |,/       \\ |  |   |     /     \\ |  :  '   |'   :  |");            
        System.Console.WriteLine(" /    / '  .--.  .-. |'  :  / /   ,'   |        |   | /  | |--'.--.  .-. |:__,'| :    /    / ' |  |   /' :;   |  ;");            
        System.Console.WriteLine(".    ' /    \\__\\/: . .|  | ' .   '  /  |        |   : |  | ,    \\__\\/: . .  '  : |__ .    ' /  '  :  | | |`---'. |");            
        System.Console.WriteLine("'   ; :__   ,\" .--.; |;  : | '   ; |:  |        |   : |  |/     ,\" .--.; |  |  | '.'|'   ; :__ |  |  ' | : `--..`;");            
        System.Console.WriteLine("'   | '.'| /  /  ,.  ||  , ; |   | '/  '        |   | |`-'     /  /  ,.  |  ;  :    ;'   | '.'||  :  :_:,'.--,_   ");            
        System.Console.WriteLine("|   :    :;  :   .'   \\---'  |   :    :|        |   ;/        ;  :   .'   \\ |  ,   / |   :    :|  | ,'    |    |`.");            
        System.Console.WriteLine(" \\   \\  / |  ,     .-./       \\   \\  /          '---'         |  ,     .-./  ---`-'   \\   \\  / `--''      `-- -`, ;");           
        System.Console.WriteLine("  `----'   `--`---'            `----'                          `--`---'                `----'               '---`\" ");           
        System.Console.WriteLine();

        ReadySetGo();                                                                                                                    

                                                                                                                                
    }


    public override void DisplayTurn()
    {
        System.Console.Clear();
        int beg=0;
        int end=13;
        System.Console.WriteLine("       A          B          C          D          E          F          G          H          I          J          K          L          M     ");
        for(int i=0;i<4;i++)
        {
            for (int l=0; l<9 ; l++)
            {
                for (int c=beg; c<end;c++)
                {
                    if(c==0 || c%13 == 0)
                    {
                        if(l == 4)
                        {
                            System.Console.Write($"{i+1} ");
                        }
                        else
                        {
                            System.Console.Write("  ");
                        }
                    }
                    if(_player1Cards.GetCards()[c].GetRevealed())
                    {   
                        System.Console.Write(_player1Cards.GetCards()[c].GetDisplay()[l]);
                    }
                    else{
                        System.Console.Write(_player1Cards.GetCards()[c].GetBackDisplay()[l]);
                    }
                    
                }
                System.Console.WriteLine();
                
            }
            beg+=13;
            end+=13;
        }
        
        
    }

    public int CardChoice()
    {
        bool notValid = true;
        int cardChoiceIndex=-1;
        while(notValid)
        { 
            try{
                
                string input = Console.ReadLine();
                string[] parts = {input.Substring(0, 1), input.Substring(1, 1)};
                int numChoice = Int32.Parse(parts[1]);
                if( numChoice < 1 || numChoice > 4)
                {
                    throw new Exception("Number is outside of range");
                }

                if(parts[0] == "A" || parts[0] == "a")
                {
                    cardChoiceIndex = 0;
                }
                else if(parts[0] == "B" || parts[0] == "b")
                {
                    cardChoiceIndex = 1;
                }
                else if(parts[0] == "C" || parts[0] == "c")
                {
                    cardChoiceIndex = 2;
                }
                else if(parts[0] == "D" || parts[0] == "d")
                {
                    cardChoiceIndex = 3;
                }
                else if(parts[0] == "E" || parts[0] == "e")
                {
                    cardChoiceIndex = 4;
                }
                else if(parts[0] == "F" || parts[0] == "f")
                {
                    cardChoiceIndex = 5;
                }
                else if(parts[0] == "G" || parts[0] == "g")
                {
                    cardChoiceIndex = 6;
                }
                else if(parts[0] == "H" || parts[0] == "h")
                {
                    cardChoiceIndex = 7;
                }
                else if(parts[0] == "I" || parts[0] == "i")
                {
                    cardChoiceIndex = 8;
                }
                else if(parts[0] == "J" || parts[0] == "j")
                {
                    cardChoiceIndex = 9;
                }
                else if(parts[0] == "K" || parts[0] == "k")
                {
                    cardChoiceIndex = 10;
                }
                else if(parts[0] == "L" || parts[0] == "l")
                {
                    cardChoiceIndex = 11;
                }
                else if(parts[0] == "M" || parts[0] == "m")
                {
                    cardChoiceIndex = 12;
                }
                else{
                    throw new Exception("The letter entered is outside of the range");
                }
                
                cardChoiceIndex+= (numChoice-1)*13;

                notValid = false;
            }catch (Exception ex)
            {
                System.Console.WriteLine($"{ex}");
                System.Console.Write("Invalid input, try again ");
            }
        }
        return cardChoiceIndex;
    }
    
    public int GetCardToReveal(int cardChoice, string message)
    {
        while(true)
        {
            System.Console.Write(message);
            cardChoice = CardChoice();
            if(!_player1Cards.GetCards()[cardChoice].GetRevealed())
            {
                _player1Cards.GetCards()[cardChoice].SetRevealed(true);
                DisplayTurn();
                break;
            }else{
                System.Console.WriteLine("Invalid card, try again");
            }
        }
        return cardChoice;
    }
    public virtual void NextTurn()
    {
        
        int cardChoice1 = -1;
        int cardChoice2 = -1;
        cardChoice1 = GetCardToReveal(cardChoice1, "\nEnter card to reveal (for example A1): ");
        cardChoice2 = GetCardToReveal(cardChoice2, "\nEnter card to compare (for example A1): ");
        var cardsToChange = _player1Cards.GetCards();
        if(_player1Cards.GetCards()[cardChoice1].GetFace() == _player1Cards.GetCards()[cardChoice2].GetFace())
        {
            System.Console.WriteLine("\nYou got a match!");
            cardsToChange[cardChoice1].ChangeToEmpty();
            cardsToChange[cardChoice2].ChangeToEmpty();
            System.Threading.Thread.Sleep(1500);
        }else{
            System.Console.Write("\nYou did not get a match, press enter to continue");
            System.Console.ReadLine();
            cardsToChange[cardChoice1].SetRevealed(false);
            cardsToChange[cardChoice2].SetRevealed(false);
        }
        _player1Cards.SetCards(cardsToChange);
    }

    public override void GameOver()
    {
        bool over = true;
        foreach(var card in _player1Cards.GetCards())
        {
            if(!card.GetRevealed())
            {
                over=false;
            }
        }
        
        if(over){
            _players[_player1Index].IncrementWins();
            System.Console.Clear();
            System.Console.WriteLine($"\nCongrats {_players[_player1Index].GetName()}! You won!\nYou now have {_players[_player1Index].GetWins()} wins!");
            base.GameOver();
        }
    }




}