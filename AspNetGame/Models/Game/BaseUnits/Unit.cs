using AspNetGame.Models.Game.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Core
{
    public abstract class Unit : BaseEntity<long>
    {
        protected long attackPoint = 0;

        public long AttackPoint {
            get
            {
                return attackPoint;
            }
            set
            {
                if (this is Attacker)
                {
                    attackPoint = value;
                }
            }

        }

        public Planet Position { get; set; }

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