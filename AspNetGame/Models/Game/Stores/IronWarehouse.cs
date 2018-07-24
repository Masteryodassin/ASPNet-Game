using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Stores
{
    public class IronWarehouse : Building, IIronStore
    {
        public long Capacity()
        {
            throw new NotImplementedException();
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