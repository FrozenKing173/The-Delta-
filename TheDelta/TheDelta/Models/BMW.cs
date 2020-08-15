using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TheDelta.Models
{
    public class BMW : Vehicle
    {
        public override Guid Id { get; set; }

        public BMW()
        {
        }
        public BMW(Guid id, VehicleBody body, string color) {
            Id = id;
            Body = body;

            if (String.IsNullOrEmpty(color))
            {
                color = "white";
            }
            else
            {
                Color = color;
            }
            
        }

        protected override int Wheels => 4;

        protected override int Engine => 2000;

        public override string Color { get; set; }

        public override VehicleBody Body { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
