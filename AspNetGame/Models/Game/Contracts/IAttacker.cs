using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Units;
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
    public interface IAttacker
    {
        /// <summary>
        /// Attacks a unit
        /// </summary>
        /// <param name="target">The unit to attack</param>
        void Attack(UnitTemplate target);
    }
}
