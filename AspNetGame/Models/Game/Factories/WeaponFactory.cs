using AspNetGame.Models.Game.Contracts;
using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game.Defence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Factories
{
    public class WeaponFactory : Builder
    {
        public override List<Type> CanBuild()
        {
            return new List<Type>()
            {
                typeof(LaserTower), typeof(MissileLauncher), typeof(PowerShield)
            };
        }

    public class WeaponFactory : Building
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
    }
}
