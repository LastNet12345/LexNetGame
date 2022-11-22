using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexNetGame.ConsoleGame.Extensions
{
    //public static class TestExtensions
    //{
    //    public static IGetMapSize Implementation { private get; set; } = new GetMapSize();  
    //    public static int GetMapSizeFor(this IConfiguration config, string value)
    //    {
    //        return Implementation.GetMapSizeFor(config, value);
    //    }
    //}

    //public class GetMapSize : IGetMapSize
    //{
    //    public int GetMapSizeFor(IConfiguration config, string value)
    //    {
    //        var section = config.GetSection("game:mapsettings");
    //        return int.TryParse(section[value], out int result) ? result : 0;
    //    }
    //}

    //public interface IGetMapSize
    //{
    //    int GetMapSizeFor(IConfiguration config, string value);
    //}


    public static class ExtensionTestFunc
    {
        public static Func<IConfiguration, string, int> Implementation { private get; set; } =
            (config, value) =>
            {
                var section = config.GetSection("game:mapsettings");
                return int.TryParse(section[value], out int result) ? result : 0;

            };

        public static int GetMapSizeFor(this IConfiguration config, string value)
        {
            return Implementation(config, value);
        }

    }

}
