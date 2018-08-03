using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Units;
using AspNetGame.Controllers.Game.Core;
using AspNetGame.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetGame.Controllers.Game.Admin
{
    [Authorize(Roles = "Admin")]
    public class UnitTemplateController: GameController<UnitTemplate>
    {
        public UnitTemplateController() : base(new UnitTemplateRepository()) { }
    }
}