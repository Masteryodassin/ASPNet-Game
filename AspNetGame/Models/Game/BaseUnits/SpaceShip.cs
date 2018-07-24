using AspNetGame.Models.Game.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Core
{
    public abstract class SpaceShip : Unit, Mobile
    {
        private Planet position;

        public Planet Position
        {
            get { return position; }
            set { position = value; }
        }

        private bool moving;

        public bool Moving
        {
            get { return moving; }
            set { }
        }

        public abstract void Move(Planet destination);
    }
}