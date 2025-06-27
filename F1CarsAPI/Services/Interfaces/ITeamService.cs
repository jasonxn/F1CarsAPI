using F1CarsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F1CarsAPI.Services.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team?> GetTeamByIdAsync(int id);
        Task<Team> CreateTeamAsync(Team team);
        Task<bool> UpdateTeamAsync(int id, Team updatedTeam);
        Task<bool> DeleteTeamAsync(int id);
    }

}
