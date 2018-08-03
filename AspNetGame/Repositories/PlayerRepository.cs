using AspNetGame.Models.Game;
using AspNetGame.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetGame.Repositories
{
    public class PlayerRepository : GameRepository<Player>
    {
        public PlayerRepository() : base()
        {

        }
    }
}