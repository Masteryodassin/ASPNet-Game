using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Contracts;
using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Units
{
    public class UnitTemplate : DisplayableEntity<long>
    { 
        public Abilities Abilities { get; set; }

        // IAttacker
        public long? AttackPoint { get; set; }

        // IMobile
        public long? Speed { get; set; }

        // IExtractor
        public Resource ExtractedResource { get; set; }

        public long? ExtractionCapacity { get; set; }
        
        // IBuilder
        public List<UnitTemplate> AvailableBuildings { get; set; }

        public float? BuildingSpeedRatio { get; set; }

        // IStorage
        public Resource StoredResource { get; set; }
        
        public long? StorageCapacity { get; set; }

        // IResearch
        // ...

        // General stats
        [Range(0, long.MaxValue)]
        [DisplayName("Maximum health")]
        public long MaxHealth { get; set; }

        [Range(0, long.MaxValue)]
        [DisplayName("Building delay")]
        public long BuildingDelay { get; set; }

        [DisplayName("Cost")]
        public virtual List<Cost> ResourceCosts { get; set; }
    }
}