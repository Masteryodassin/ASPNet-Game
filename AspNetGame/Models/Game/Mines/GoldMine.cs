using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Mines
{
    public class GoldMine : IGoldExtractor
    {

        long IExtractor.Extraction()
        {
            throw new NotImplementedException();
        }
    }
}