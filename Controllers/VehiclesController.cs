using System;
using System.Threading.Tasks;
using AutoMapper;
using Controllers.Resources;
using Persistence;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using COREMES.Core;
using System.Collections.Generic;

namespace Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public VehiclesController(IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;

        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle(SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            repository.Add(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await repository.GetVehicle(id);
            if (vehicle == null)
                return NotFound();

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle((id));

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            var vehicle = await repository.GetVehicle(id, includeRelated: false);
            if (vehicle == null)
                return NotFound();

            repository.Remove(vehicle);

            await unitOfWork.CompleteAsync();

            return Ok(vehicle);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {

            var vehicle = await repository.GetVehicle(id);
            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);

        }

        [HttpGet]
        public async Task<IEnumerable<VehicleResource>> GetVehicles()
        {
            var vehicles = await repository.GetVehicles();

            return mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicles);
        }

    }
}