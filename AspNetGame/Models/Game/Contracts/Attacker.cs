using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AspNetGame.Models.Game.Contracts
{
    /// <summary>
    /// Represents the behavior of a unit that have attacking capabilities.
    /// </summary>
    public interface Attacker
    {
        /// <summary>
        /// Attacks a unit
        /// </summary>
        /// <param name="target">The unit to attack</param>
        void Attack(Unit target);
    }
}
