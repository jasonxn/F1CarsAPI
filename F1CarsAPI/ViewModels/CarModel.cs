using F1CarsAPI.Models;

namespace F1CarsAPI.ViewModels
{
    public static class CarMappingExtensions
    {
        public static void UpdateEntity(this Car car, CreateCarRequestModel request)
        {
            car.Model = request.Model;
            car.Year = request.Year;
            car.Horsepower = request.Horsepower;
            car.TeamId = request.TeamId;
        }

        public static CarResponseModel ToResponseModel(this Car car)
        {
            return new CarResponseModel
            {
                Id = car.Id,
                Model = car.Model,
                Year = car.Year,
                Horsepower = car.Horsepower,
                CreatedAt = car.CreatedAt.UtcDateTime,
                TeamName = car.Team?.Name ?? ""
            };
        }

        public static Car ToEntity(this CreateCarRequestModel request)
        {
            return new Car
            {
                Model = request.Model,
                Year = request.Year,
                Horsepower = request.Horsepower,
                TeamId = request.TeamId,
                CreatedAt = DateTime.Now
            };
        }
    }


}
