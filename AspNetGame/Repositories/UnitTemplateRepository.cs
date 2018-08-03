using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Units;
using AspNetGame.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace AspNetGame.Repositories
{
    public class UnitTemplateRepository: GameRepository<UnitTemplate>
    {
        public UnitTemplateRepository() : base() { }

        protected override Expression<Func<UnitTemplate, object>>[] DefaultIncludedProperties()
        {
            return new Expression<Func<UnitTemplate, object>>[] {
                e => e.ExtractedResource,
                e => e.StoredResource,
                e => e.ResourceCosts.Select(c => c.Resource),
                e => e.AvailableBuildings
            };
        }
    }
}