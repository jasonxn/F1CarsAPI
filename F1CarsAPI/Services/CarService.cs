using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1CarsAPI.Data;
using F1CarsAPI.Models;
using F1CarsAPI.Services.Interfaces;


namespace F1CarsAPI.Services
{

    public class CarService : ICarService
    {
        private readonly AppDbContext _context;

     
        public CarService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.Include(c => c.Team).ToListAsync();
        }

       
        public async Task<Car?> GetCarByIdAsync(int id)
        {
            return await _context.Cars.Include(c => c.Team).FirstOrDefaultAsync(c => c.Id == id);
        }

       
        public async Task<Car> CreateCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<bool> UpdateCarAsync(int id, Car car)
        {
            if (id != car.Id)
                return false;

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
           
                if (!await _context.Cars.AnyAsync(c => c.Id == id))
                    return false;

                throw; 
            }
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
