using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using TheDelta.Interfaces;

namespace TheDelta.Models
{
    public abstract class Vehicle : IVehicleYearModel, IVehicleQualityApproved
    {
        public abstract Guid Id { get; set; }
        private bool QualityApproved = false;

        protected virtual int Wheels { get; set; } = 0;
        protected abstract int Engine { get; }

        public abstract string Color { get; set; }
        public abstract VehicleBody Body { get; set; }

        public virtual string Run()
        {
            // Test based on Vehicle being instantiated
            if (Wheels != 0  && Engine > 0 && Body != null)
            {
                return "Vehicle is running in good condition";
            }
            else
            {
                return "Vehicle is running in poor condition";
            }
        }

        public override string ToString()
        {
            return "Vehicle: " + Id.ToString() + " has " + Wheels + " Wheels, " + Body.Body + " colored " + Color + " and running on a " + Engine + "cc Engine.";
        }

        public int VehicleManufacturedYear()
        {
            return int.Parse(DateTime.Now.ToString("yyyy"));
        }

        public void ApproveVehicle()
        {
            QualityApproved = true;
        }

        public void DisapproveVehicle()
        {
            QualityApproved = false;
        }

        public bool IsQualityApproved()
        {
            return QualityApproved;
        }
    }
}
