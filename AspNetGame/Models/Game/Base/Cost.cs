using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Base;

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
    }
}