using SiccarCodeTest.Domain.Interfaces;
using SiccarCodeTest.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiccarCodeTest.Domain
{
    public class VehicleTaxRuleWithCondition : VehicleTaxRule, IVehicleTaxRule
    {
        public static readonly VehicleTaxRule NumberOfCarSeats = new VehicleTaxRuleWithCondition()
        {
            AppliesTo = VehicleType.Car,
            TaxAmount = 25,
            PropertyName = nameof(Car.NumberOfSeats),
            Condition = numberOfSeats => (int)numberOfSeats > 5 || (int)numberOfSeats <= 2
        };
        public static readonly VehicleTaxRule MaxHGVTrailerLoad = new VehicleTaxRuleWithCondition()
        {
            AppliesTo = VehicleType.HGV,
            TaxAmount = 100,
            PropertyName = nameof(HGV.MaxTrailerLoad),
            Condition = maxTrailerLoad => (int)maxTrailerLoad > 200
        };

        public string PropertyName;
        public Func<object, bool> Condition;

        /// <summary>
        /// Returns the amount of tax that the tax rule specifies
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>The tax amount according to the rule</returns>
        public override int CalculateTax(Vehicle vehicle)
        {
            _ = vehicle ?? throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null.");
            _ = PropertyName ?? throw new ArgumentNullException(nameof(PropertyName), "PropertyName cannot be null.");
            _ = Condition ?? throw new ArgumentNullException(nameof(Condition), "Condition cannot be null.");

            return AppliesTo == vehicle.Type ? ApplyCondition(vehicle) : 0;
        }

        /// <summary>
        /// Applies the specific condition depending on the vehicles type
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        private int ApplyCondition(Vehicle vehicle)
        {
            var propertyValue = vehicle.GetType().GetProperty(PropertyName).GetValue(vehicle);

            return Condition(propertyValue) ? TaxAmount : 0;
        }
    }
}
