using System;
using System.Security.Cryptography;

class Program
{

    


    static void Main(string[] args)
    {
        // Player p1 = new Player("Joe");
        // Player p2 = new Player("pearl");

        // p1.IncrementWins();
        // p1.IncrementWins();
        // p1.SavePlayer();
        // p2.SavePlayer();
        CardMatch myGame = new CardMatch();
        while(!myGame.GetWin())
        {
            myGame.DisplayTurn();
            myGame.NextTurn();
            myGame.GameOver();
        }
        

    }
}