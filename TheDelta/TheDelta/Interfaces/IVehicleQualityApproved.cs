using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDelta.Interfaces
{
    public interface IVehicleQualityApproved
    {
        public void ApproveVehicle();
        public void DisapproveVehicle();
        public bool IsQualityApproved();
    }
}
