using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game
{
    /// <summary>
    /// Represents a planet
    /// </summary>
    public class Planet : DisplayableEntity<long>
    {

        /// <summary>
        /// The player that owns the planet
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// The player Id of the owner (technical property for EF)
        /// </summary>
        public long PlayerId { get; set; }

        // Base resources stock

        // Building list

            /// <summary>
            /// List of Unit types built on this planet
            /// </summary>
        public List<UnitTemplate> Units { get; set; }


        public Planet()
        {
            this.Units = new List<UnitTemplate>();
        }

    }
}