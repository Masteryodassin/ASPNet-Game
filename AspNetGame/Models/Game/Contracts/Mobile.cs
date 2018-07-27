using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models.Game.Contracts
{
    public interface Mobile
    {
        void Move(Planet destination);

        bool IsMoving();
    }
}
