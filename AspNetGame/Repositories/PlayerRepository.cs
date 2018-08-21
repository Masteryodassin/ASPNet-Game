using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Contracts;
using AspNetGame.Models.Game.Units;
using AspNetGame.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace AspNetGame.Repositories
{
    public class PlayerRepository : GameRepository<Player>
    {
        public PlayerRepository() : base()
        {

        }

        protected override Expression<Func<Player, object>>[] DefaultIncludedProperties()
        {
            return new Expression<Func<Player, object>>[]
            {
                player => player.Resources.Select(a => a.Resource)
            };
        }

        public async Task<long> GetProductionCapacity(Player player, long resourceId)
        {
            long amount = 0;

            PlanetRepository planetRepository = IoC.Resolve<PlanetRepository>();
            var planets = await planetRepository.FindAll(p => p.PlayerId.Equals(player.Id));

            foreach (var planet in planets)
            {
                Dictionary<UnitTemplate, int> counts = await planetRepository.GetBuildingsCount(planet);

                Dictionary<IAbilities, int> extractors = counts
                    .Where(p => AbilitiesHelper.IsExtractor(p.Key))
                    .ToDictionary(p => AbilitiesHelper.AsExtractor(p.Key), p => (int)p.Value);
          
                foreach (var extCount in extractors)
                {
                    Resource resource = extCount.Key.ExtractedResource;
                    if (resource.Id == resourceId)
                    {
                        long production = extCount.Key.ExtractionCapacity;
                        int count = extCount.Value;
                        amount += count * production;
                    }
                }

            }
            return amount;
        }
    }
}