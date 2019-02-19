using System;

namespace towers_of_hanoi
{
    class Block
    {
        public int Weight { get; private set; }

        public Block(int weight)
        {
            this.Weight = weight;   
        }
    }
}
