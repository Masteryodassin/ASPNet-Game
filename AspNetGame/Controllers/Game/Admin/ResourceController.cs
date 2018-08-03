using AspNetGame.Controllers.Game.Core;
using AspNetGame.Models.Game.Base;
using AspNetGame.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetGame.Controllers.Game.Admin
{
    [Authorize(Roles = "Admin")]
    public class ResourceController : GameController<Resource>
    {
        public ResourceController() : base(new ResourceRepository())
        {
        }
    }
}