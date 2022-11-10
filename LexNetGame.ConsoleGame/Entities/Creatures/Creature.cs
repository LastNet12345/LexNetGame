using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexNetGame.ConsoleGame.Entities.Creatures
{
    internal class Creature
    {
        public string Symbol { get; }
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
        public Cell Cell { get; }

        public Creature(Cell cell, string symbol)
        {
            Cell = cell;
            Symbol = symbol;
        }

    }
}
