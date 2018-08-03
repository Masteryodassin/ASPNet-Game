using AspNetGame.Models;
using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game.Base
{
    /// <summary>
    /// Represents a resource that can be collected and spent in the game.
    /// Resource is a DisplayableEntity so it has a name and an optional self representing picture URL
    /// </summary>
    public class Resource : DisplayableEntity<long>
    {


    }
}