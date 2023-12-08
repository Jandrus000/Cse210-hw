using System;
using System.Security.Cryptography;

class Program
{

    


    static void Main(string[] args)
    {
        int gameChoice = 0;
        System.Console.WriteLine("\nPlease pick a game:");
        System.Console.WriteLine("1. War with a friend");
        System.Console.WriteLine("2. War with CPU (speed war)");
        System.Console.WriteLine("3. Memory Match");

        while(!(gameChoice == 1 || gameChoice == 2 || gameChoice == 3 ))
        {
            System.Console.Write("Enter number of your choice: ");
            try{
                gameChoice = Int32.Parse(Console.ReadLine());
            }catch{
            }
        }
        
        if(gameChoice == 1)
        {
            WarPlayer warPlayer = new WarPlayer();
            while(!warPlayer.GetWin())
            {
                warPlayer.DisplayTurn();
                System.Console.Write("Press Enter to draw ");
                System.Console.ReadLine();
                warPlayer.DisplayDraw();
                warPlayer.NextTurn();
                warPlayer.GameOver();
            }
        }
        else if(gameChoice == 2)
        {
            WarAI warAI = new WarAI();
            while(!warAI.GetWin())
            {
                warAI.DisplayTurn();
                warAI.DisplayDraw();
                warAI.NextTurn();
                warAI.GameOver();
            }
        }
        else if(gameChoice == 3)
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
}