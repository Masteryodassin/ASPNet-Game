using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models.Game.Contracts
{
    /// <summary>
    /// Represents the behavior of a terrestrial unit, which means
    /// a unit that is build on a planet
    /// </summary>
    public interface Terrestrial
    {
        /// <summary>
        /// The planet on which is build the current terrestrial unit (ManyToOne)
        /// </summary>
        Planet Planet { get; set; }
    }
}
