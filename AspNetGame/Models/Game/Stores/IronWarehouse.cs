using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Stores
{
    public class IronWarehouse : IIronStore
    {
        public long Capacity()
        {
            throw new NotImplementedException();
        }
    }
}