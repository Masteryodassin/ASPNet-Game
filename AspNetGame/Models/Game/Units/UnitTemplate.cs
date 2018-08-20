using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetGame.Models.Game.Units
{
    /// <summary>
    /// Unit template is the representation of a kind of unit that
    /// can be created and used in the game by player.
    /// These objects are managed by application admin to define the game model
    /// before players can play.
    /// </summary>
    public class UnitTemplate : DisplayableEntity<long>
    {
        #region General Stats

        /// <summary>
        /// The abilities of this kind of unit
        /// </summary>
        public Abilities Abilities { get; set; }

        /// <summary>
        /// The maximum and nomimal amount of health point for this kind of unit
        /// </summary>
        [Range(0, long.MaxValue)]
        [DisplayName("Maximum health")]
        public long MaxHealth { get; set; }

        /// <summary>
        /// The delay in second required by this kind of unit to being built
        /// </summary>
        [Range(0, long.MaxValue)]
        [DisplayName("Building delay")]
        public long BuildingDelay { get; set; }

        /// <summary>
        /// The amount of resources required for creating this kind of unit
        /// </summary>
        [DisplayName("Cost")]
        public virtual List<ResourceAmount> ResourceCosts { get; set; }
        #endregion

        /// <summary>
        /// The amount of damage cause by this kind of unit
        /// </summary>
        public long? AttackPoint { get; set; }

        #region IMobile
        /// <summary>
        /// The speed of the mobile unit
        /// </summary>
        public long? Speed { get; set; }
        #endregion

        #region IExtractor
        /// <summary>
        /// The type of resource that th eunit can extract.
        /// </summary>
        public Resource ExtractedResource { get; set; }

        /// <summary>
        /// The amount of resource that this kind of unit can produces in a hour.
        /// </summary>
        public long? ExtractionCapacity { get; set; }
        #endregion

        #region IBuilder
        /// <summary>
        /// Lists of other kind of units that this can build (if it's a builder)
        /// </summary>
        public List<UnitTemplate> AvailableBuildings { get; set; }

        /// <summary>
        /// A ratio that can speed up the base building time of a building
        /// </summary>
        public float? BuildingSpeedRatio { get; set; }
        #endregion

        #region IStorage
        /// <summary>
        ///  The kind of resource that this kind of unit can store
        /// </summary>
        public Resource StoredResource { get; set; }
        
        /// <summary>
        /// The amount of resource that can be stored
        /// </summary>
        public long? StorageCapacity { get; set; }
        #endregion

        #region IResearcher
        // TODO Add specific properties to research able units
        #endregion
        
        /// <summary>
        /// List of planet where this unit Template is built
        /// </summary>
        public List<Planet> Planets { get; set; }

        /// <summary>
        /// Boolean setting the activity of the current UnitTemplate
        /// </summary>
        public bool isActive { get; set; }
    }
}