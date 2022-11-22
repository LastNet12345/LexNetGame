using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexNetGame.ConsoleGame.Extensions
{
    internal static class MapExtensions
    {
        public static IDrawable CreataureAtExtension(this List<Creature> creatures, Cell cell)
        {
            //IDrawable result = cell;

            //foreach (var creature in creatures)
            //{
            //    if (creature.Cell == cell)
            //    {
            //        result = creature;
            //        break;
            //    }
            //}

            //return result;
            return creatures.FirstOrDefault(creature => creature.Cell == cell) ?? cell as IDrawable;
        }
        
        public static IDrawable? CreataureAtExtension2(this List<Creature> creatures, Cell cell)
        {
            //IDrawable? result = null;

            //foreach (var creature in creatures)
            //{
            //    if (creature.Cell == cell)
            //    {
            //        result = creature;
            //        break;
            //    }
            //}

            //return result;
            return creatures.FirstOrDefault(creature => creature.Cell == cell);
        }

        //public static int GetMapSizeFor(this IConfiguration config, string value)
        //{
        //    var section = config.GetSection("game:mapsettings");
        //    return int.TryParse(section[value], out int result) ? result : 0;
        //}
    }
}
