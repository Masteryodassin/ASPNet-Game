using AspNetGame.Models.Game.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Core
{
    public abstract class SpaceShip : Unit, Mobile
    {

        public abstract void Move(Planet destination);

        public bool IsMoving()
        {
            throw new NotImplementedException();
        }
    }
}