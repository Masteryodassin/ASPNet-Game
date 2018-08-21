using AspNetGame.Models.Game.Units;
using AspNetGame.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AspNetGame.Repositories
{
    public class UnitRepository : GameRepository<Unit>
    {
        public UnitRepository() : base() { }

        protected override Expression<Func<Unit, object>>[] DefaultIncludedProperties()
        {
            return new Expression<Func<Unit, object>>[] {
       
            };
        }
    }
}