using F1CarsAPI.Data;
using F1CarsAPI.Models;
using F1CarsAPI.Services.Interfaces;
using F1CarsAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace F1CarsAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _carService.GetAllCarsAsync().ConfigureAwait(false); 
            return Ok(cars);
        }

        // GET: api/cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _carService.GetCarByIdAsync(id).ConfigureAwait(false); 
            if (car == null)
                return NotFound();

            return Ok(car);
        }

        // POST: api/cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(CreateCarRequestModel car)
        {
            var created = await _carService.CreateCarAsync(car).ConfigureAwait(false); 
            return CreatedAtAction(nameof(GetCar), new { id = created.Id }, created);
        }

        // PUT: api/cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            var success = await _carService.UpdateCarAsync(id, car).ConfigureAwait(false); 
            if (!success)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var deleted = await _carService.DeleteCarAsync(id).ConfigureAwait(false);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }



}














/*
[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly AppDbContext _context;
    public CarsController(AppDbContext context)
    {
        _context = context;
    }
    // GET: api/cars
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars()
    {
        return await _context.Cars.ToListAsync();
    }
    // GET: api/cars/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> GetCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        return car;
    }
    // POST: api/cars
    [HttpPost]
    public async Task<ActionResult<Car>> PostCar(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
    }
    // PUT: api/cars/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCar(int id, Car car)
    {
        if (id != car.Id)
        {
            return BadRequest();
        }
        _context.Entry(car).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CarExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }
    // DELETE: api/cars/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    private bool CarExists(int id)
    {
        return _context.Cars.Any(e => e.Id == id);
    }
}
}
*/