using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Units;
using AspNetGame.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using static AspNetGame.Models.Game.IoC;

namespace AspNetGame.Repositories
{
    public class PlanetRepository : GameRepository<Planet>, IInjectable
    {
        private UnitTemplateRepository UnitTemplateRepo;
        public PlanetRepository() : base() { }

        protected override Expression<Func<Planet, object>>[] DefaultIncludedProperties()
        {
            return new Expression<Func<Planet, object>>[]
            {
                planet => planet.Units,
                planet => planet.Player,
                planet => planet.Player.Resources,
                planet => planet.Player.Resources.Select(r => r.Resource)
            };
        }

        public async Task<List<UnitTemplate>> GetActiveUnitTemplates()
        {
            return (await UnitTemplateRepo.GetAll()).Where(u => u.Active == true).ToList();
        }

        public async Task<Dictionary<UnitTemplate, int>> GetBuildingsCount(Planet planet)
        { 
            var buildingsCount = new Dictionary<UnitTemplate, int>();

            foreach (UnitTemplate unitTemplate in await GetActiveUnitTemplates())
            {
                buildingsCount.Add(unitTemplate, planet.Units.Count(u => u.UnitTemplateId == unitTemplate.Id));
            }

            return buildingsCount;
        }

        public void SelfInitialize()
        {
            UnitTemplateRepo = IoC.Resolve<UnitTemplateRepository>();
        }
    }
}