using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game.Timeloop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game
{
    /// <summary>
    /// Represents a player in the game. Player is only available
    /// in the GameDbContext, and makes the association with the IdentityUser.
    /// </summary>
    public class Player : DisplayableEntity<long>, ITickable
    {
        /// <summary>
        /// The username of the IdentityUser used to log in the application
        /// </summary>
        [MaxLength(256)]
        public string Username { get; set; }

        /// <summary>
        /// The nickname of the player
        /// </summary>
        [MaxLength(256)]
        public string Nickname { get; set; }

        public virtual List<ResourceAmount> Resources { get; set; }

        public void Tick(long count)
        {
            if (Name != "admin")
            {
                System.Diagnostics.Debug.WriteLine("Le joueur " + Nickname + " gagne " + count + "X des resources");
            }
            
        }
    }



    /// <summary>
    /// A Model for creating a new planet for newer users.
    /// </summary>
    public class NewPlanetModel
    {
        /// <summary>
        /// The nickname chosen by the new player
        /// </summary>
        [Required]
        [MinLength(4)]
        public string Nickname { get; set; }

        /// <summary>
        /// The name of its new planet
        /// </summary>
        [Required]
        [MinLength(4)]
        public string PlanetName { get; set; }
    }
}