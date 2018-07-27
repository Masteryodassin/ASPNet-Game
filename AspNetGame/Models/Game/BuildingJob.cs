using AspNetGame.Models.Game.Contracts;
using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game
{
    public class BuildingJob : BaseEntity<long>
    {
        /// <summary>
        /// A reference to the builder
        /// </summary>
        public Builder Builder { get; set; }

        /// <summary>
        /// The building that is being build
        /// </summary>
        public Building Building { get; set; }

        public DateTime BuildingStartTime { get; set; }

        public int WorkersCount { get; set; }

        public bool IsFinished()
        {
            return Utils.ConvertToUnixTime(BuildingStartTime) + Building.GetConstructionDelay() * (1 - (WorkersCount * 0.1)) < Utils.ConvertToUnixTime(DateTime.Now);
        }
    }
}