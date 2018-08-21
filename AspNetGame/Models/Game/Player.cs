using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game.Timeloop;
using AspNetGame.Repositories;
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

        public async void Tick(long count)
        {
            if (Name != "admin")
            {
                var PlayerRepository = IoC.Resolve<PlayerRepository>();
                foreach (var amount in Resources)
                {
                    amount.Amount += count * (Constants.BASE_PRODUCTION_DELAY +
                        (await PlayerRepository.GetProductionCapacity(this, amount.Resource.Id)));
                    
                }
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