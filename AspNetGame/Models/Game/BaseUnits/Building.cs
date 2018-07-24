using AspNetGame.Models.Game.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Core
{
    public abstract class Building : Unit, Terrestrial
    {

        private Planet planet;

        public Planet Planet
        {
            get { return planet; }
            set { planet = value; }
        }

        abstract public void LevelUp();

    }
}