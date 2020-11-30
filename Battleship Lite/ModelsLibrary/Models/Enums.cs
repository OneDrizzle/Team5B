using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models
{
    // 0 = Empty, 1 = Ship, 2 = Miss, 3 = Hit, 4 = Sunk
    public enum GridSpotStatus
    {
        Empty,
        Ship,
        Miss,
        Hit,
        Sunk 
    }
}
