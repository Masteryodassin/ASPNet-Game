using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Core
{
    public abstract class Unit : BaseEntity<long>
    {

        public int Level { get; set; }

        public long Health { get; set; }
        //public long PrimaryKey { get; set; }

        abstract public long GetConstructionDelay();

        abstract public long GetIronCost();

        abstract public long GetPlutoniumCost();

        abstract public long GetGoldCost();
    }
}