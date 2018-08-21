using System.ComponentModel.DataAnnotations;

namespace AspNetGame.Models.Game.Core
{
    /// <summary>
    /// An abstract class that represent the base entity for
    /// the application
    /// </summary>
    /// <typeparam name="TId">The type of Primary Key</typeparam>
    public abstract class BaseEntity<TId> where TId : struct
    {
        /// <summary>
        /// Returns the entity primary key.
        /// </summary>
        [Key]
        public TId Id { get; set; }
    }
}