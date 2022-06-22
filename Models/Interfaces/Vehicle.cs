using SiccarCodeTest.Domain.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SiccarCodeTest.Interfaces.Domain
{
    [JsonConverter(typeof(VehicleTypeConverter))]
    public abstract class Vehicle
    {
        public Vehicle() { }

        public string Registration { get; init; }
        public virtual string Type { get; init; }
        public int TotalTax { get; private set; } = 0;

        public void SetTotalTax(int tax) => TotalTax = tax;
    }
}
