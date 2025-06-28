using F1CarsAPI.Models;

namespace F1CarsAPI.ViewModels
{
    public static class CarResponseModelExtensions
    {
        public static CarResponseModel CarToResponseModel(this Car c)
        {
            return new CarResponseModel
            {
                Id = c.Id,
                Model = c.Model,
                Year = c.Year,
                Horsepower = c.Horsepower,
                CreatedAt = c.CreatedAt.UtcDateTime,
                TeamId = c.TeamId,
                TeamName = c.Team?.Name ?? string.Empty
            };
        }
    }
}
