using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Timeloop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.ViewModels
{
    /*public class ResourcesViewModel
    {
        public List<ResourceViewModel> ResourceAmounts { get; set; }

        public long TickSize { get; set; }
        public static ResourcesViewModel Build(Player player)
        {
            if (player == null || player.Resources == null) return null;

            var resources = player.Resources
                .Select(p => new ResourceViewModel()
                {
                    Id = p.Id,
                    GainPerTick = 100,
                    Resource = p.Resource,
                    Amount = p.Amount
                }).ToList();

            return new ResourcesViewModel()
            {
                ResourceAmounts = resources,
                TickSize = Constants.TICK_DELAY, 
            };
        }

    }

    public class ResourceViewModel
    {
        public long Id { get; set; }
        public long GainPerTick { get; set; }

        public Resource Resource { get; set; }

        public long Amount { get; set; }
    }*/
}