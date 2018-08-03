using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models.Game.Core
{
    /// <summary>
    /// An abstract class that defines an entity that can be displayed
    /// in the UI with an image URL.
    /// </summary>
    /// <typeparam name="ID">The type of the Primary key</typeparam>
    public abstract class DisplayableEntity<ID> : BaseEntity<long>
    {
        /// <summary>
        /// The displayable and friendly name of the entity
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The image path to display for this entity
        /// </summary>
        [DisplayName("Set an image path")]
        public string ImagePath { get; set; }
    }
}
