using F1CarsAPI.Models;

namespace F1CarsAPI.ViewModels
{
    public class TeamModel
    {
    }

    public class CreatTeamModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public static class TeamMappingExtensions
    {
        public static void UpdateEntity(this Team team, CreateTeamRequestModel request)
        {
            team.Name = request.Name;
            team.Country = request.Country;
        }

        public static TeamResponseModel ToResponseModel(this Team team)
        {
            return new TeamResponseModel
            {
                Id = team.Id,
                Name = team.Name,
                Country = team.Country,
                CreatedAt = team.CreatedAt.UtcDateTime,
                Cars = team.Cars?.Select(c => c.ToResponseModel()).ToList() ?? new List<CarResponseModel>()

            };
        }

        public static Team ToEntity(this CreateTeamRequestModel request)
        {
            return new Team
            {
                Name = request.Name,
                Country = request.Country,
                CreatedAt = DateTime.Now,
                Cars = new List<Car>() 
            };
            {
               
            };
        }
    }

}
