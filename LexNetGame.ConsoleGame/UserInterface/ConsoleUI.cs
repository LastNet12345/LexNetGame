using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexNetGame.ConsoleGame.UserInterface
{
    internal class ConsoleUI
    {
        //internal static ConsoleKey GetKey()
        //{
        //    return Console.ReadKey(intercept: true).Key;
        //} 
        
        internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;
        
    }
}
