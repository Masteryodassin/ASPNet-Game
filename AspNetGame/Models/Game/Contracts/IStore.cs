using AspNetGame.Models.Game.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models.Game.Contracts
{
    /// <summary>
    /// Represents the ability to store a particular king of resource.
    /// A unit can store only one type of resource.
    /// </summary>
    public interface IStorage
    {
        Resource StoredResource { get; set; }

        long StorageCapacity { get; set; } 
    }
}
