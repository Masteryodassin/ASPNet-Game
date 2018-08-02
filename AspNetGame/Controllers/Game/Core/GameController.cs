using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game.Units;
using AspNetGame.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetGame.Controllers.Game.Core
{
    
    public abstract class GameController<TEntity> : BaseController<TEntity, long>
        where TEntity: BaseEntity<long>, new()
    {
        public GameController(IRepository<TEntity, long> repository) : 
            base(repository)
        {
        }

    }
}