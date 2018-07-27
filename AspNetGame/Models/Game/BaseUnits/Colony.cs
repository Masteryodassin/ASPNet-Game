using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Core
{
    public class Colony : Building
    {
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

        public int GetWorkersCount()
        {
            return 2 + (int) Math.Floor(Level * 0.5);
        }
    }
}