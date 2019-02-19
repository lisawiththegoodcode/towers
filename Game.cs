using System;
using System.Collections;
using System.Collections.Generic;

namespace towers_of_hanoi
{
    class Game
    {
        public Dictionary<string, Tower> Towers = new Dictionary<string, Tower>();

        public ICollection startingBlocks = new List<Block>{new Block(4), new Block(3), new Block(2), new Block(1)};
        public Game()
        {
            Towers["A"] = new Tower(new Stack(startingBlocks));
            Towers["B"] = new Tower(new Stack());
            Towers["C"] = new Tower(new Stack());
        }

        public void PrintBoard()
        {
            foreach (KeyValuePair<string, Tower> kvp in Towers)
            {
                Stack blocks = new Stack();

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
            }
        }

        public void MovePiece(string towerFrom, string towerTo)
        {
            Stack toPop = new Stack();
            Stack toPush = new Stack();

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

        public bool IsLegal(Stack stackFrom, Stack stackTo)
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
                if(kvp.Value.Blocks.Count==4 && (kvp.Key == "B" || kvp.Key == "C"))
                {
                    return true;
                }
            }
            return false;
        }

        public void ComputerPlays(int blockWeight, Stack fromStack, Stack toStack, Stack otherStack)
        {
            if (blockWeight == 1)
            {
                toStack.Push(fromStack.Pop());
                return;
            }

            ComputerPlays(blockWeight - 1, fromStack, otherStack, toStack);

            toStack.Push(fromStack.Pop());

            ComputerPlays(blockWeight -1, otherStack, toStack, fromStack);
        
        }
    }
}
