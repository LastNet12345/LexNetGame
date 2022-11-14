using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexNetGame.ConsoleGame.UserInterface
{
    internal class ConsoleUI
    {
        internal static void Clear()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        internal static void Draw(Map map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell? cell = map.GetCell(y, x);
                    ArgumentNullException.ThrowIfNull(cell, nameof(cell));
                    IDrawable drawable = cell;

                    drawable = map.Creatures.CreataureAtExtension(cell);

                    Console.ForegroundColor = drawable.Color;
                    Console.Write(drawable.Symbol);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        //internal static ConsoleKey GetKey()
        //{
        //    return Console.ReadKey(intercept: true).Key;
        //} 

        internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;
        
    }
}
