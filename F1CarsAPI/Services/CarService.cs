using F1CarsAPI.Data;
using F1CarsAPI.Models;
using F1CarsAPI.Services.Interfaces;
using F1CarsAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Linq.Expressions;



namespace F1CarsAPI.Services
{

    public class CarService : ICarService
    {
        private readonly AppDbContext _context;

     
        public CarService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarResponseModel>> GetAllCarsAsync()
        {
            var cars = await _context.Cars.Include(c => c.Team).ToListAsync().ConfigureAwait(false);
            return cars.Select(c => c.ToResponseModel());
        }


        public async Task<CarResponseModel?> GetCarByIdAsync(EntityIdRequestModel request)
        {
            var car = await _context.Cars
                .Include(c => c.Team)
                .FirstOrDefaultAsync(c => c.Id == request.Id)
                .ConfigureAwait(false);

            return car?.ToResponseModel();
        }

        /*
        public async Task<CarResponseModel> CreateCarAsync(CreateCarModel car)
        {
            var newCar = new Car
            {
                Model = car.Model,
                Year = car.Year,
                Horsepower = car.Horsepower,
                TeamId = car.TeamId,
                CreatedAt = DateTime.Now,
            };
            _context.Cars.Add(newCar);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var savedCar = await _context.Cars
              .Include(c => c.Team)
              .FirstOrDefaultAsync(c => c.Id == newCar.Id)
              .ConfigureAwait(false);

            return savedCar!.ToResponseModel(); 
        }
        */
        public async Task<CarResponseModel> CreateCarAsync(CreateCarRequestModel request)
        {
            var newCar = request.ToEntity();  // testing mapping extension
            _context.Cars.Add(newCar);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var savedCar = await _context.Cars
                .Include(c => c.Team)
                .FirstOrDefaultAsync(c => c.Id == newCar.Id)
                .ConfigureAwait(false);

            return savedCar!.ToResponseModel();
        }

        /*
        public async Task<bool> UpdateCarAsync(int id, Car car)
        {
            if (id != car.Id)
                return false;

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false); 
                return true;
            }
            catch
            {
           
                if (!await _context.Cars.AnyAsync(c => c.Id == id).ConfigureAwait(false))
                    return false;

                throw; 
            }
        }*/
        public async Task<bool> UpdateCarAsync(EntityIdRequestModel idRequest, CreateCarRequestModel request)
        {
            var existingCar = await _context.Cars.FindAsync(idRequest.Id).ConfigureAwait(false);
            if (existingCar == null)
                return false;

            existingCar.UpdateEntity(request);

            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }





        public async Task<bool> DeleteCarAsync(EntityIdRequestModel request)
        {
            var car = await _context.Cars.FindAsync(request.Id).ConfigureAwait(false);
            if (car == null)
                return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
    }

}
