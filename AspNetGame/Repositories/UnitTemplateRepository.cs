using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace AspNetGame.Repositories
{
    public class UnitTemplateRepository: BaseRepository<UnitTemplate, long>
    {
        public UnitTemplateRepository() : base(new GameDbContext()) { }

        protected override Expression<Func<UnitTemplate, object>>[] DefaultIncludedProperties()
        {
            return new Expression<Func<UnitTemplate, object>>[] {
                e => e.ExtractedResource,
                e => e.StoredResource,
                e => e.ResourceCosts.Select(c => c.Resource),
                e => e.AvailableBuildings
            };
        }



        /*protected override string[] DefaultIncludedProperties()
        {
            return new string[] {
                "ExtractedResource", "AvailableBuildings", "StoredResource", "ResourceCosts.Resource"
            };
        }*/

        /*public async override Task<IEnumerable<UnitTemplate>> GetAll()
        {
            return Context.Set<UnitTemplate>()
                .Include("ResourceCosts.Resource")
                .Include("ExtractedResource")
                .Include("StoredResource")
                .Include("AvailableBuildings")
                .AsEnumerable();
        }*/
    }
}