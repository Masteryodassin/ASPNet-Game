using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Repositories.Core
{
    public abstract class GameRepository<TEntity> : BaseRepository<TEntity, long>
        where TEntity : BaseEntity<long>
    {
        protected GameRepository() : base(IoC.Resolve<GameDbContext>()) { }
    }
}