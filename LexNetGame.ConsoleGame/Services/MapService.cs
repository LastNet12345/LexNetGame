﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexNetGame.ConsoleGame.Services
{
    public class MapService : IMapService
    {
        private readonly IConfiguration configuration;

        public MapService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public (int width, int height) GetMap()
        {
            return (width: configuration.GetMapSizeFor("x"), height: configuration.GetMapSizeFor("y"));
        }
    }
}
