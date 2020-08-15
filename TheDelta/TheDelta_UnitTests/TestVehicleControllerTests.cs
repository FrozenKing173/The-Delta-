using Moq;
using System;
using System.Threading.Tasks;
using TheDelta.Controllers;
using TheDelta.Handlers;
using TheDelta.Interfaces;
using TheDelta.Models;
using TheDelta.Service;
using Xunit;

namespace TheDelta_UnitTests
{
    public class TestVehicleControllerTests
    {
        private VehicleController _controller;
        private Mock<IVehicleManufactureService> _service;

        public TestVehicleControllerTests()
        {
            _service = new Mock<IVehicleManufactureService>();
            _controller = new VehicleController(_service.Object);
        }

        /// <summary>
        /// a basic Test for VehicleController with its relevant service and handler.
        ///</summary>

        [Fact]
        public async Task TestVehicleControllerShouldWork()
        {
            CreateVehicleCommand createVehicleCommand = new CreateVehicleCommand()
            {
                Id = Guid.NewGuid(),
                Vehicle = "Ford",
                Body = "Normal",
                Color = "Blue"
            };
            _service.Setup(x => x.Build(createVehicleCommand));

            await _controller.CreateVehicle(createVehicleCommand);

            _service.Verify(x => x.Build(It.Is<CreateVehicleCommand>(command => command.Id == createVehicleCommand.Id)));
        }
    }
}
