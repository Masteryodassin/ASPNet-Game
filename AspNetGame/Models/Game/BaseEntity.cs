using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models
{
    /// <summary>
    /// An interface that describes the base behavior of an entity.
    /// </summary>
    /// <typeparam name="ID">The type of the Primary key</typeparam>
    interface BaseEntity<ID>
    {
        /// <summary>
        /// Returns the entity primary key.
        /// </summary>
        ID PrimaryKey { get; set; }
    }
}
