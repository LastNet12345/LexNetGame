using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexNetGame.ConsoleGame.Entities.Creatures
{
    internal class Creature : IDrawable
    {
        private Cell cell;
        public string Symbol { get; }
        public ConsoleColor Color { get; protected set; } = ConsoleColor.Green;
        public int Health { get; }
        public Cell Cell 
        {
            get => cell;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                cell = value;
            }
        }

        public Creature(Cell cell, string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException($"'{nameof(symbol)}' cannot be null or whitespace.", nameof(symbol));
            }

            ArgumentNullException.ThrowIfNull(cell, nameof(cell));

            this.cell = cell;
            Symbol = symbol;
        }

    }
}
