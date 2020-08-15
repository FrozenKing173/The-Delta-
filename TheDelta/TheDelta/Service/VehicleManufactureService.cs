using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDelta.Interfaces;
using TheDelta.Models;

namespace TheDelta.Service
{
    public class VehicleManufactureService : IVehicleManufactureService
    {
        private readonly IBodyHandler _bodyHandler;

        public VehicleManufactureService(IBodyHandler bodyHandler)
        {
            _bodyHandler = bodyHandler;
        }

        public async Task<Vehicle> Build(CreateVehicleCommand command)
        {
            Vehicle vehicle;

            try
            {
                VehicleTypes type;
                VehicleBody body;

                Enum.TryParse<VehicleTypes>(command.Vehicle, out type);
                body = await _bodyHandler.Build(command.Body);

                switch (type)
                {
                    case VehicleTypes.BMW:
                        vehicle = new BMW(command.Id, body, command.Color);
                        break;
                    case VehicleTypes.Ford:
                        vehicle = new Ford(command.Id, body, command.Color);
                        break;
                    default:
                        vehicle = null;
                        break;
                }
            }
            catch(Exception exception)
            {
                return null;
            }
            
            return vehicle;
        }

        public async Task QualityTestRun(Vehicle vehicle)
        {
            string result = vehicle.Run();
            if (result.Contains("good"))
            {
                vehicle.ApproveVehicle();
            }
        }

        public async Task<string> Release(Vehicle vehicle)
        {
            string release = "";
            if (vehicle.IsQualityApproved())
            {
                release = vehicle.ToString() + " Manufactured year: " + vehicle.VehicleManufacturedYear();
            }
            else
            {
                release = "No Release date yet.";
            }
            return release;
        }
    }
}
