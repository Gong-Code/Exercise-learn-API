using learnApi.Data.Entities;
using learnApi.Models.FuelDtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace learnApi.Controllers
{
    [Route("api/cars/{carId}/fuel")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Fuel>> GetFuels(int carId)
        {
            var car = CarEntity.AllCars.Cars.FirstOrDefault(c => c.Id == carId);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car.Fuels);
        }

        [HttpGet("{fuelId}", Name = "GetFuel")]
        public ActionResult<Fuel> GetFuelById(int carId, int fuelId)
        {
            var car = CarEntity.AllCars.Cars.FirstOrDefault(c => c.Id == carId);

            if (car == null)
            {
                return NotFound("Car ID not found.");
            }

            var fuel = car.Fuels.FirstOrDefault(c => c.Id == fuelId);

            if (fuel == null)
            {
                return NotFound("Fuel ID not found.");
            }

            return Ok(fuel);
        }

        [HttpPost]
        public ActionResult<Fuel> CreateFuel(int carId, CreateFuel fuel)
        {
            var car = CarEntity.AllCars.Cars.FirstOrDefault(c => c.Id == carId);

            if (car == null)
            {
                return NotFound();
            }

            var maxFuelId = CarEntity.AllCars.Cars.SelectMany(f => f.Fuels).Max(x => x.Id);

            var finalFuel = new Fuel()
            {
                Id = ++maxFuelId,
                FuelType = fuel.FuelType,
                Description = fuel.Description

            };

            car.Fuels.Add(finalFuel);

            return CreatedAtRoute("GetFuel", new { carId = carId, fuelId = finalFuel.Id }, finalFuel);
        }

        [HttpPut("{fuelId}")]
        public ActionResult UpdateFuel(int carId, int fuelId, UpdateFuel fuel)
        {
            var car = CarEntity.AllCars.Cars.FirstOrDefault(c => c.Id == carId);
            if (car == null)
                return NotFound("Car ID not found.");

            var fuelFromStore = car.Fuels.FirstOrDefault(f => f.Id == fuelId);
            if (fuelFromStore == null)
                return NotFound("Fuel ID not found.");

            fuelFromStore.FuelType = fuel.FuelType;
            fuelFromStore.Description = fuel.Description;

            return NoContent();
        }

        [HttpPatch("{fuelId}")]
        public ActionResult PartiallyUpdateFuel(int carId, int fuelId, JsonPatchDocument<UpdateFuel> patchDocument)
        {
            var car = CarEntity.AllCars.Cars.FirstOrDefault(c => c.Id == carId);
            if (car == null)
                return NotFound();

            var fuelFromEntity = car.Fuels.FirstOrDefault(f => f.Id == fuelId);
            if (fuelFromEntity == null)
                return NotFound();

            var fuelToPatch = new UpdateFuel()
            {
                FuelType = fuelFromEntity.FuelType,
                Description = fuelFromEntity.Description
            };

            patchDocument.ApplyTo(fuelToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(patchDocument))
            {
                return BadRequest(ModelState);
            }

            fuelFromEntity.FuelType = fuelToPatch.FuelType;
            fuelFromEntity.Description = fuelToPatch.Description;

            return NoContent();
        }
    }
}
