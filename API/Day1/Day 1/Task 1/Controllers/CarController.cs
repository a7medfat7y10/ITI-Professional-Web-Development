using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_1.Filters;
using Task_1.Models;

namespace Task_1.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public ILogger<CarController> Logger { get; set; }
        public CarController(ILogger<CarController> logger) 
        {
            Logger = logger;
        }

        /// GetAll
        [HttpGet]
        public ActionResult<List<Car>> GetAll() {
            Logger.LogInformation("Getting all data");
            return CarList.Cars;
        }

        /// GetById
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetById(int id) {
            Car? car = CarList.Cars.FirstOrDefault(c => c.Id == id);
            if(car is null)
            {
                return NotFound();
            }
            return car;
        }


        /// Post
        [HttpPost]
        [Route("V1")]
        public ActionResult Add(Car car) { 
            car.Id = new Random().Next(10, 1000);
            car.Type = "Gas";
            CarList.Cars.Add(car);
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new {id = car.Id},
                value: new { Message = "Car has been added successfully." });
        }

        
        [HttpPost]
        [Route("V2")]
        [ValidateCarType]
        public ActionResult AddV2(Car car)
        {
            car.Id = new Random().Next(10, 1000);
            car.Type = "Gas";
            CarList.Cars.Add(car);
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = car.Id },
                value: new { Message = "Car has been added successfully." });
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(Car car, int id) {
            if(car.Id == id)
            {
                return BadRequest();
            }
            var carToUpdate = CarList.Cars.FirstOrDefault(c => c.Id == id);
            if(carToUpdate is null)
            {
                return NotFound();
            }
            car.Color = carToUpdate.Color;
            car.Model = carToUpdate.Model;
            car.Manufacture = carToUpdate.Manufacture;
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteById(int id) {
            var carTodelete = CarList.Cars.FirstOrDefault(c => c.Id == id);
            if(carTodelete is null)
            {
                return NotFound();
            }
            CarList.Cars.Remove(carTodelete);
            return NoContent();
        }


    }
}
