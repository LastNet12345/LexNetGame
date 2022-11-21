using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexNetGame.ConsoleGame.Entities.Creatures
{
    public class Creature : IDrawable
    {
        private Cell cell;
        private int health;
        private ConsoleColor color;
        private string name => this.GetType().Name;

        public string Symbol { get; }
        public ConsoleColor Color 
        {
            get => IsDead ? ConsoleColor.Gray : color;
            protected set => color = value; 

        }
        public int Health 
        { 
            get => health < 0 ? 0 : health;
            set => health = value >= MaxHealth ? MaxHealth : value;
        }

        public bool IsDead => health <= 0;
        public int Damage { get; protected set; } = 50;
        public int MaxHealth { get; }

        public Action<string> AddToLog { get; set; } = default!;
        public Cell Cell 
        {
            get => cell;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                cell = value;
            }
        }

        public Creature(Cell cell, string symbol, int maxHealth)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException($"'{nameof(symbol)}' cannot be null or whitespace.", nameof(symbol));
            }

            ArgumentNullException.ThrowIfNull(cell, nameof(cell));

            this.cell = cell;
            Symbol = symbol;
            MaxHealth = maxHealth;
            Health = maxHealth;
            color = ConsoleColor.Green;
        }


        public void Attack(Creature target)
        {
            //AddToLog?.Invoke($"Message to messageLog {creature.Cell.Position.X}");
            if(target.IsDead || this.IsDead) return;

            var attacker = this.name;

            target.Health -= Damage;

            AddToLog?.Invoke($"The {attacker} attacks the {target.name} for {this.Damage}");

            if (target.IsDead)
                AddToLog?.Invoke($"The {target.name} is dead");

        }

    }
}
