using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models.Game.Contracts
{
    public interface IMobile
    {
        /// <summary>
        /// Moves the unit to another planet
        /// </summary>
        /// <param name="destination">The destination planet</param>
        void Move(Planet destination);

        /// <summary>
        /// Indicates whether the unit is currently moving
        /// </summary>
        /// <returns></returns>
        bool IsMoving();
    }
}
