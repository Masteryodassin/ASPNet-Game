using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models.Game.Contracts
{
    /// <summary>
    /// Represents the ability for a kind of unit to create another units
    /// </summary>
    public interface IBuilder
    {
        float BuildingSpeedRatio { get; set; }
    }
}
