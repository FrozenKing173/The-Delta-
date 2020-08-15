using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheDelta.Models
{
    public class CreateVehicleCommand
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Vehicle")]
        public string Vehicle { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }

        [JsonProperty("Color")]
        public string Color { get; set; }

        public bool Validate()
        {
            bool success = false;
            if(!Guid.Equals(Id, Guid.Empty) && !String.IsNullOrEmpty(Vehicle) && !String.IsNullOrEmpty(Body))
            {
                success = true;
            }
            return success;
        }
    }
}
