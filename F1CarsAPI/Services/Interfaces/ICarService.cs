using F1CarsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F1CarsAPI.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();        
        Task<Car?> GetCarByIdAsync(int id);             
        Task<Car> CreateCarAsync(Car car);               
        Task<bool> UpdateCarAsync(int id, Car car);     
        Task<bool> DeleteCarAsync(int id);          
    }

}
