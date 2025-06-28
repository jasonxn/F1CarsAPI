using F1CarsAPI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F1CarsAPI.Services.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamResponseModel>> GetAllTeamsAsync();
        Task<TeamResponseModel?> GetTeamByIdAsync(EntityIdRequestModel request);
        Task<TeamResponseModel> CreateTeamAsync(CreateTeamRequestModel request);
        Task<bool> UpdateTeamAsync(EntityIdRequestModel idRequest, CreateTeamRequestModel updateRequest);
        Task<bool> DeleteTeamAsync(EntityIdRequestModel request);
    }
}
