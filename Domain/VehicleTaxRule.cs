using SiccarCodeTest.Domain.Interfaces;
using SiccarCodeTest.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiccarCodeTest.Domain
{
    public class VehicleTaxRule : IVehicleTaxRule
    {
        public string AppliesTo;
        public int TaxAmount;

        public static readonly VehicleTaxRule CarBaseTax = new VehicleTaxRule()
        {
            AppliesTo = VehicleType.Car,
            TaxAmount = 100,
        };
        public static readonly VehicleTaxRule HGVBaseTax = new VehicleTaxRule()
        {
            AppliesTo = VehicleType.HGV,
            TaxAmount = 140
        };

        /// <summary>
        /// Returns the amount of tax that the tax rule specifies
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>The tax amount according to the rule</returns>
        public virtual int CalculateTax(Vehicle vehicle)
        {
            _ = vehicle ?? throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null.");

            return AppliesTo == vehicle.Type ? TaxAmount : 0;
        }
    }
}
