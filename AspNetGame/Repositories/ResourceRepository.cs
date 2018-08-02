using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AspNetGame.Repositories
{
    public class ResourceRepository : BaseRepository<Resource, long>
    {
        public ResourceRepository() : base(new GameDbContext())
        {
        }
    }
}