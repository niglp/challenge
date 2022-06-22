using SiccarCodeTest.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiccarCodeTest.Domain.Interfaces
{
    public interface IVehicleTaxRule
    {
        int CalculateTax(Vehicle vehicle);
    }
}
