using AspNetGame.Models.Game.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models.Game.Contracts
{
    /// <summary>
    /// Represents the ability to extract a particularkind of resource.
    /// A unit can extract only one type of resource.
    /// </summary>
    public interface IExtractor
    {
        Resource ExtractedResource { get; set; }

        long ExtractionAmount { get; set; }
    }
}
