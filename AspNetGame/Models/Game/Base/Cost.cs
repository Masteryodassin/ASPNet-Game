using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Base;

namespace AspNetGame.Models.Game.Base
{
    public class Cost: BaseEntity<long>
    {
        public Resource Resource { get; set; }

        public long Amount { get; set; }
    }
}