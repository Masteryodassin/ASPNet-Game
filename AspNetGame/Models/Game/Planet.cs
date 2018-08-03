using AspNetGame.Models.Game.Core;
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
    }
}