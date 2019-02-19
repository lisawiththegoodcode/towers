using System;
using System.Collections.Generic;

namespace towers_of_hanoi
{
    class Program
    {
        public static List<Block> startingBlocks = new List<Block>();

        static void Main(string[] args)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("WELCOME TO TOWERS OF HANOI!!!");
            System.Console.WriteLine();
            System.Console.WriteLine("Would you like to (1)play or (2)watch?");
            string playOrSolve = Console.ReadLine();
            System.Console.WriteLine("Great! How many blocks would you like to use? Please enter a number 1-10.");
            int numBlocks = Convert.ToInt32(Console.ReadLine());
            blockCreator(numBlocks);
            System.Console.WriteLine();

            Game game = new Game(startingBlocks, 0);

            if(playOrSolve=="2")
            {
                game.PrintBoard();
                System.Console.WriteLine("Which tower would you like to move the stacks to? B or C?");
                string toTower = Console.ReadLine().ToUpper();
                string otherTower = toTower == "B" ? "C" : "B";
                System.Console.WriteLine();

                Stack<Block> from = game.Towers["A"].Blocks;
                Stack<Block> to = game.Towers[toTower].Blocks;
                Stack<Block> other = game.Towers[otherTower].Blocks;
                int totalBlocks = startingBlocks.Count;

                game.ComputerPlays(totalBlocks, from, to, other);
                System.Console.WriteLine("That's it! Thanks for watching!");
                System.Console.WriteLine();
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
        public static void blockCreator(int numBlocks)
        {
            for (int i = numBlocks; i > 0; i--)
            {
                startingBlocks.Add(new Block(i));
            }
        }
    }
}
