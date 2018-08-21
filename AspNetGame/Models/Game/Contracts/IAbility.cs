using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models.Game.Contracts
{
    public interface IAbilities: IAttacker, IBuilder, IExtractor, IMobile, IResearcher, IStorage
    {
    }
}
