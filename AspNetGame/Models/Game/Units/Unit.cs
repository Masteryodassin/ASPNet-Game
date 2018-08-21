using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AspNetGame.Models.Game.Units
{
    public class Unit : BaseEntity<long>
    {
        public Planet Planet { get; set; }

        public long PlanetId { get; set; }

        public UnitTemplate UnitTemplate { get; set; }

        public long UnitTemplateId { get; set; }
        
    }
}