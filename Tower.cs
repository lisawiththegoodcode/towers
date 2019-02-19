using System;
using System.Collections.Generic;

namespace towers_of_hanoi
{
    class Tower
    {
        public Stack<Block> Blocks { get; set; }
        public Tower(Stack<Block> blocks)
        {
            this.Blocks = blocks;
        }

    }
}
