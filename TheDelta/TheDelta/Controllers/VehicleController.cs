using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheDelta.Models;
using TheDelta.Interfaces;
using Newtonsoft.Json;

namespace TheDelta.Controllers
{
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleManufactureService _vehicleManufactureService;

        public VehicleController(IVehicleManufactureService vehicleManufactureService) 
        {
            _vehicleManufactureService = vehicleManufactureService;
        }

        [HttpPost]
        [Route("commands/vehicle-create")]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleCommand command)
        {
            if(command.Validate())
            {
                Vehicle vehicle = await _vehicleManufactureService.Build(command);
                if (vehicle == null)
                {
                    return BadRequest();
                }

                await _vehicleManufactureService.QualityTestRun(vehicle);
                VehicleReleaseResponse response = new VehicleReleaseResponse
                {
                    Release = await _vehicleManufactureService.Release(vehicle)
                };

                return new ContentResult
                {
                    Content = JsonConvert.SerializeObject(response),
                    StatusCode = 200,
                    ContentType = "json/application"
                };
                
            }
           
            return BadRequest();
        }
    }
}
