using AspNetGame.Models.Game.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Core
{
    public abstract class Building : Unit, Terrestrial
    {

        protected List<BuildingJob> buildingStack = new List<BuildingJob>();

        public Planet Planet { get; set; }

        public List<BuildingJob> BuildingStack
        {
            get
            {
                return (this is Builder) ? buildingStack.Where(job => !job.IsFinished()).ToList() : new List<BuildingJob>();
            }

            set
            {
                if (this is Builder)
                {
                    buildingStack = value;
                }
            }
        }

        abstract public void LevelUp();

    }
}