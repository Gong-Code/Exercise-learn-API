using learnApi.Data.Entities;
using learnApi.Models.CarDtos;
using Microsoft.AspNetCore.Mvc;

namespace learnApi.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCars()
        {
            var result = CarEntity.AllCars;

            return Ok(result);
        }

        [HttpGet("{carId}")]
        public ActionResult<Car> GetCarById(int carId)
        {
            var result = CarEntity.AllCars.Cars.FirstOrDefault(x => x.Id == carId);

            if (result == null)
            {
                return NotFound("Car ID not found.");
            }

            return Ok(result);
        }
    }
}
