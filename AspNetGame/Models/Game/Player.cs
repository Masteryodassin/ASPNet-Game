using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game
{
    public class Player : DisplayableEntity<long>
    {
        public string Username { get; set; }

        public virtual List<Planet> Planets { get; set; }
    }
}