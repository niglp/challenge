using SiccarCodeTest.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SiccarCodeTest.Domain.Converters
{
    public class VehicleTypeConverter : JsonConverter<Vehicle>
    {
        /// <summary>
        /// The logic for determining which child type a vehicle should be deserialised into. 
        /// Implemented by Nigel
        /// </summary>
        public override Vehicle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Take a copy of the reader to determine the vehicle type with, we can then pass the original object to the appropriate deserialiser.
            Utf8JsonReader readerCopy = reader;

            if (readerCopy.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            while (readerCopy.Read())
            {
                if (readerCopy.TokenType == JsonTokenType.PropertyName)
                {
                    String propertyName = readerCopy.GetString();
                    readerCopy.Read();

                    if (propertyName == "type")
                    {
                        Type vehicleType;
                        if (TypeMap.TryGetValue(readerCopy.GetString(), out vehicleType))
                        {
                            return (Vehicle)JsonSerializer.Deserialize(ref reader, vehicleType, options);
                        }

                        throw new NotSupportedException("Unknown vehicle type");
                    }
                }

                if (readerCopy.TokenType == JsonTokenType.EndObject)
                {
                    throw new KeyNotFoundException("Missing type property");
                }
            }

             throw new JsonException("Unable to deserialise vehicle");
        }

        // Added by Nigel
        public override bool CanConvert(Type typeToConvert) => typeof(Vehicle).IsAssignableFrom(typeToConvert);

        public override void Write(Utf8JsonWriter writer, Vehicle value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }

        private static readonly Dictionary<string, Type> TypeMap = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
        {
            { VehicleType.Car, typeof(Car) },
            { VehicleType.HGV, typeof(HGV) }
        };
    }
}
