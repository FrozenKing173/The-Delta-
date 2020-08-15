using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDelta.Models;

namespace TheDelta.Interfaces
{
    public interface IVehicleManufactureService
    {
        public Task<Vehicle> Build(CreateVehicleCommand command);
        public Task QualityTestRun(Vehicle vehicle);
        public Task<string> Release(Vehicle vehicle);
    }

}
