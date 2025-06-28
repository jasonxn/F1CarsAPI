using F1CarsAPI.Models;
using F1CarsAPI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F1CarsAPI.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarResponseModel>> GetAllCarsAsync();
        Task<CarResponseModel?> GetCarByIdAsync(EntityIdRequestModel request);
        Task<CarResponseModel> CreateCarAsync(CreateCarRequestModel request);
        Task<bool> UpdateCarAsync(EntityIdRequestModel idRequest, CreateCarRequestModel updateRequest);
        Task<bool> DeleteCarAsync(EntityIdRequestModel request);
    }

}
