using AspNetGame.Models.Game.Contracts;
using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Factories
{
    public class SpaceShipyard : Builder
    {
        public override List<Type> CanBuild()
        {
            return new List<Type>()
            {
                typeof(Scout), typeof(Cruiser), typeof(Striker), typeof(Destroyer)
            };
        }

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

        public override void LevelUp()
        {
            throw new NotImplementedException();
        }
    }
}