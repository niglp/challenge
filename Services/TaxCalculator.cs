using SiccarCodeTest.Domain;
using SiccarCodeTest.Domain.Interfaces;
using SiccarCodeTest.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiccarCodeTest.Services
{
    public static class TaxCalculator
    {
        private static readonly List<IVehicleTaxRule> _rules = new List<IVehicleTaxRule>
        {
            VehicleTaxRule.HGVBaseTax,
            VehicleTaxRule.CarBaseTax,
            VehicleTaxRuleWithCondition.MaxHGVTrailerLoad,
            VehicleTaxRuleWithCondition.NumberOfCarSeats,
        };

        /// <summary>
        /// Calculates the total tax for a vehicle using a list of tax rules.
        /// </summary>
        /// <param name="vehicle"></param>
        public static void CalulateVehicleTax(Vehicle vehicle)
        {
            int totalTax = 0;
            _rules.ForEach(t => totalTax += t.CalculateTax(vehicle));
            vehicle.SetTotalTax(totalTax);
        }
    }
}

