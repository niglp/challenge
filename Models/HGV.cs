using SiccarCodeTest.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiccarCodeTest.Domain
{
    public class HGV : Vehicle
    {
        public override string Type { get; init; } = VehicleType.HGV;
        public int MaxTrailerLoad { get; init; }
    }
}
