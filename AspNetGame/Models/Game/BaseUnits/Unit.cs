using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Core
{
    public abstract class Unit : BaseEntity<long>
    {

        [Required] 
        [Range(0, long.MaxValue)]
        public int Level { get; set; }

        [Required]
        public long Health { get; set; }

        abstract public long GetConstructionDelay();

        abstract public long GetIronCost();

        abstract public long GetPlutoniumCost();

        abstract public long GetGoldCost();
    }
}