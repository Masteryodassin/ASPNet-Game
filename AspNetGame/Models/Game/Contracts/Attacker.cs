using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models.Game.Contracts
{
    /// <summary>
    /// Represents the behavior of a unit that have attacking capabilities.
    /// </summary>
    public interface Attacker
    {
        /// <summary>
        /// The attack point, which means the amount of damage that the unit can cause.
        /// </summary>
        long AttackPoint { get; set; }
    }
}
