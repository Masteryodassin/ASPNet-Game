using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Core
{
    /// <summary>
    /// Represents a player
    /// </summary>
    public class Player : BaseEntity<long>
    {
        /// <summary>
        /// The player's nickname
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// The player's email according to the corresponding User's one
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The list of planets occupied by the player (OneToMany)
        /// </summary>
        public List<Planet> planets { get; set; }
    }
}