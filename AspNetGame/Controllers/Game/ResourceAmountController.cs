using AspNetGame.Models.Game;
using AspNetGame.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetGame.Controllers.Game
{
    public class ResourceAmountController: Controller
    {


        private GamePlayerProvider GamePlayerProvider { get; set; }
        public ResourceAmountController()
        {
            GamePlayerProvider = IoC.Resolve<GamePlayerProvider>();
        }

        protected async Task<Player> GetPlayer()
        {
            if (User != null)
            {
                return await GamePlayerProvider.GetPlayer(User);
            }
            else
            {
                throw new Exception("Could not resolve the current player.");
            }
        }

        [HttpGet, ActionName("Index")]
        public async Task<JsonResult> GetResourcesAmount()
        {
            var context = IoC.Resolve<GameDbContext>();

            var amounts = context.ResourceAmount.Include("Resource").ToList();
            return Json(amounts, JsonRequestBehavior.AllowGet);
        }
    }
}