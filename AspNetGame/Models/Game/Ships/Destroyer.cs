using AspNetGame.Models.Game.Contracts;
using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Ships
{
    public class Destroyer : SpaceShip, Attacker
    {
        public long AttackPoint { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override long GetConstructionDelay()
        {
            throw new NotImplementedException();
        }

        public override long GetGoldCost()
        {
            throw new NotImplementedException();
        }

        public override long GetIronCost()
        {
            throw new NotImplementedException();
        }

        public override long GetPlutoniumCost()
        {
            throw new NotImplementedException();
        }

        public override void Move(Planet destination)
        {
            throw new NotImplementedException();
        }
    }
}