using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Units;

namespace AspNetGame.Models.Game.Base
{
    /// <summary>
    /// Represents a cost in resource to build/develop units/technologies.
    /// A cost is the association of a type of resource and of an amount
    /// </summary>
    public class ResourceAmount: BaseEntity<long>
    {
        /// <summary>
        /// The type of resource
        /// </summary>
        public Resource Resource { get; set; }

        /// <summary>
        /// The required amount
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// The player who has its resource amount
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// The cost in resource of the unitTemplate
        /// </summary>
        public UnitTemplate UnitTemplate { get; set; }

       
    }
}