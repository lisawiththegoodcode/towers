using System;
using System.Collections.Generic;
using System.Threading;

namespace towers_of_hanoi
{
    class Game
    {
        public Dictionary<string, Tower> Towers = new Dictionary<string, Tower>();
        public int Moves { get; set; }

        public Game(List<Block> startingBlocks, int moves)
        {
            Towers["A"] = new Tower(new Stack<Block>(startingBlocks));
            Towers["B"] = new Tower(new Stack<Block>());
            Towers["C"] = new Tower(new Stack<Block>());

            this.Moves = moves;
        }

        public void PrintBoard()
        {
            System.Console.WriteLine("Move: " + Moves);
            foreach (KeyValuePair<string, Tower> kvp in Towers)
            {
                Stack<Block> blocks = new Stack<Block>();

                while(kvp.Value.Blocks.Count !=0)
                {
                    blocks.Push(kvp.Value.Blocks.Pop());
                }

                System.Console.Write(kvp.Key + ": ");
                foreach (Block block in blocks)
                {
                    System.Console.Write(block.Weight.ToString());
                }

                System.Console.WriteLine();

                while(blocks.Count!=0)
                {
                    kvp.Value.Blocks.Push(blocks.Pop());
                }
            }
            Moves++;
            System.Console.WriteLine();
            Thread.Sleep(1000);
        }

        public void MovePiece(string towerFrom, string towerTo)
        {
            Stack<Block> toPop = new Stack<Block>();
            Stack<Block> toPush = new Stack<Block>();

            foreach (KeyValuePair<string, Tower> kvp in Towers)
            {
                if(kvp.Key.ToString() == towerFrom)
                {
                   toPop = kvp.Value.Blocks;
                }
                else if (kvp.Key.ToString() == towerTo)
                {
                    toPush = kvp.Value.Blocks;
                }
            }
            if(IsLegal(toPop, toPush))
            {
                toPush.Push(toPop.Pop());

            }
            else
            {
                System.Console.WriteLine("Sorry, that's not a legal Move");
            }
        }

        public bool IsLegal(Stack<Block> stackFrom, Stack<Block> stackTo)
        {
            if (stackFrom.Count != 0 && stackTo.Count != 0)
            {
                Block blockFrom = (Block)stackFrom.Peek();
                Block blockTo = (Block)stackTo.Peek();
                
                if (blockFrom.Weight >= blockTo.Weight)
                {
                    return false;
                }
            }
            else if(stackFrom.Count==0)
            {
                return false;
            }

            return true;
        }

        public bool WinDetected()
        {
            foreach (KeyValuePair<string, Tower> kvp in Towers)
            { 
                if(kvp.Value.Blocks.Count==Program.startingBlocks.Count && (kvp.Key == "B" || kvp.Key == "C"))
                {
                    return true;
                }
            }
            return false;
        }

        public void ComputerPlays(int totalBlocks, Stack<Block> fromStack, Stack<Block> toStack, Stack<Block> otherStack)
        {
            if (totalBlocks == 1)
            {
                toStack.Push(fromStack.Pop());
                PrintBoard();
                return;
            }

            ComputerPlays(totalBlocks - 1, fromStack, otherStack, toStack);
            
            toStack.Push(fromStack.Pop());
            PrintBoard();

            ComputerPlays(totalBlocks -1, otherStack, toStack, fromStack);
        }
    }
}
