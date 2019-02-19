using System;
using System.Collections;

namespace towers_of_hanoi
{
    class Tower
    {
        public Stack Blocks { get; set; }
        public Tower(Stack blocks)
        {
            this.Blocks = blocks;
        }

    }
}
