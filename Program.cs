using System;
using System.Collections;

namespace towers_of_hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            System.Console.WriteLine("WELCOME TO TOWERS OF HANOI!!!");
            System.Console.WriteLine();
            System.Console.WriteLine("Would you like to (1)play or (2)watch?");

            if(Console.ReadLine()=="2")
            {
                Stack from = game.Towers["A"].Blocks;
                Stack to = game.Towers["B"].Blocks;
                Stack other = game.Towers["C"].Blocks;
                int blockWeight = ((Block)from.Peek()).Weight;

                game.ComputerPlays(blockWeight, from, to, other);
                game.PrintBoard();
            }
            else
            {
                do
                {
                    game.PrintBoard();

                    System.Console.WriteLine("from tower?");
                    string fromTower = Console.ReadLine().ToUpper();
                    System.Console.WriteLine("to tower?");
                    string toTower = Console.ReadLine().ToUpper();

                    game.MovePiece(fromTower, toTower);
                    
                } while (!game.WinDetected());

                System.Console.WriteLine("Congratulations! You Won!");
            }
        }
    }
}
