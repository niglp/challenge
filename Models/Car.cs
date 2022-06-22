using SiccarCodeTest.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiccarCodeTest.Domain
{
    public class Car : Vehicle
    {
        public override string Type { get; init; } = VehicleType.Car;
        public int NumberOfSeats { get; init; }
    }
}
