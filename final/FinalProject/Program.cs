using System;
using System.Security.Cryptography;

class Program
{

    


    static void Main(string[] args)
    {
        CardMatch myGame = new CardMatch();
        while(!myGame.GetWin())
        {
            myGame.DisplayTurn();
            myGame.NextTurn();
            myGame.GameOver();
        }
        

    }
}