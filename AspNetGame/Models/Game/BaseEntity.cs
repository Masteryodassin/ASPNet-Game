using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models
{
    /// <summary>
    /// An interface that describes the base behavior of an entity.
    /// </summary>
    /// <typeparam name="ID">The type of the Primary key</typeparam>
    public abstract class BaseEntity<ID>
    {
        /// <summary>
        /// Returns the entity primary key.
        /// </summary>

        [Key]
        public ID PrimaryKey { get; set; }
    }
}
