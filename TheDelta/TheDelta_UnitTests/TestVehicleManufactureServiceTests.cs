using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheDelta.Handlers;
using TheDelta.Interfaces;
using TheDelta.Models;
using TheDelta.Service;
using Xunit;

namespace TheDelta_UnitTests
{
    public class TestVehicleManufactureServiceTests
    {
        private readonly VehicleManufactureService _sut;
        private readonly IBodyHandler _handler;

        public TestVehicleManufactureServiceTests()
        {
            _handler = new BodyHandler();
            _sut = new VehicleManufactureService(_handler);
        }

        /// <summary>
        /// a Test for VehicleManufactureService given with a new vehicle command should return Ford vehicle
        ///</summary>

        [Fact]
        public async Task TestVehicleManufactureService_GivenWith_Vehicle_ShouldReturn_Ford()
        {
            CreateVehicleCommand createVehicleCommand = new CreateVehicleCommand()
            {
                Id = Guid.NewGuid(),
                Vehicle = "Ford",
                Body = "Normal",
                Color = "Blue"
            };

            Vehicle vehicle = await _sut.Build(createVehicleCommand);

            Assert.True(vehicle.GetType() == typeof(Ford));
        }

        /// <summary>
        /// a Test for VehicleManufactureService given with a new vehicle command should be BMW vehicle
        ///</summary>

        [Fact]
        public async Task TestVehicleManufactureService_GivenWith_Vehicle_ShouldReturn_BMW()
        {
            CreateVehicleCommand createVehicleCommand = new CreateVehicleCommand()
            {
                Id = Guid.NewGuid(),
                Vehicle = "BMW",
                Body = "Normal",
                Color = "Blue"
            };

            Vehicle vehicle = await _sut.Build(createVehicleCommand);

            Assert.True(vehicle.GetType() == typeof(BMW));
        }

        /// <summary>
        /// a Test for VehicleManufactureService given with a new BMW vehicle command and quality Test Run, then vehicle should be Quality Approved
        ///</summary>

        [Fact]
        public async Task TestVehicleManufactureService_GivenWith_Vehicle_AND_QualityTestRun_ShouldBe_QualityApproved()
        {
            CreateVehicleCommand createVehicleCommand = new CreateVehicleCommand()
            {
                Id = Guid.NewGuid(),
                Vehicle = "BMW",
                Body = "Normal",
                Color = "Blue"
            };

            Vehicle vehicle = await _sut.Build(createVehicleCommand);
            await _sut.QualityTestRun(vehicle);

            Assert.True(vehicle.IsQualityApproved());
        }

        /// <summary>
        /// a Test for VehicleManufactureService given with a new BMW vehicle command, then vehicle should return released details with manufactured year.
        ///</summary>

        [Fact]
        public async Task TestVehicleManufactureService_GivenWith_Vehicle_ShouldReturn_ReleasedDetails()
        {
            CreateVehicleCommand createVehicleCommand = new CreateVehicleCommand()
            {
                Id = Guid.NewGuid(),
                Vehicle = "BMW",
                Body = "Normal",
                Color = "Blue"
            };

            Vehicle vehicle = await _sut.Build(createVehicleCommand);
            await _sut.QualityTestRun(vehicle);
            string result = await _sut.Release(vehicle);

            Assert.False(result == "No Release date yet.");
            Assert.Contains("year", result);
        }
    }
}
