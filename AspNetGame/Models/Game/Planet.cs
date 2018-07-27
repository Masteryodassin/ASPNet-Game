using AspNetGame.Models.Game.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Core
{
    /// <summary>
    /// A planet, with an amount of stocked resources, a name and a reference to the player
    /// if the planet is occupied.
    /// </summary>
    public class Planet : BaseEntity<long>
    {
        /// <summary>
        /// The planet name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The amount of iron available on the planet
        /// </summary>
        public long IronStock { get; set; }

        /// <summary>
        /// The amount of gold available on the planet
        /// </summary>
        public long GoldStock { get; set; }

        /// <summary>
        /// The amount of plutonium available on the planet
        /// </summary>
        public long PlutoniumStock { get; set; }

        /// <summary>
        /// The player that occupies the planet. 
        /// Null if the planet is free (ManyToOne)
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// The list of terrestrial units build on the planet (OneToMany)
        /// </summary>
        public List<Building> Buildings { get; set; }
    }
}