    using F1CarsAPI.Data;
    using F1CarsAPI.Models;
using F1CarsAPI.Services.Interfaces;
using F1CarsAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1CarsAPI.Services
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContext _context;

        public TeamService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamResponseModel>> GetAllTeamsAsync()
        {
            var teams = await _context.Teams
                .Include(t => t.Cars)
                .ToListAsync()
                .ConfigureAwait(false);

            return teams.Select(t => t.ToResponseModel());
        }

        public async Task<TeamResponseModel?> GetTeamByIdAsync(EntityIdRequestModel request)
        {
            var team = await _context.Teams
                .Include(t => t.Cars)
                .FirstOrDefaultAsync(t => t.Id == request.Id)
                .ConfigureAwait(false);

            return team?.ToResponseModel();
        }


        public async Task<TeamResponseModel> CreateTeamAsync(CreateTeamRequestModel request)
        {
            var newTeam = request.ToEntity();

            _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var savedTeam = await _context.Teams
                .Include(t => t.Cars)
                .FirstOrDefaultAsync(t => t.Id == newTeam.Id)
                .ConfigureAwait(false);

            return savedTeam!.ToResponseModel();
        }

        public async Task<bool> UpdateTeamAsync(EntityIdRequestModel idRequest, CreateTeamRequestModel updateRequest)
        {
            var existingTeam = await _context.Teams
                .FirstOrDefaultAsync(t => t.Id == idRequest.Id)
                .ConfigureAwait(false);

            if (existingTeam == null)
                return false;

            existingTeam.UpdateEntity(updateRequest);

            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteTeamAsync(EntityIdRequestModel request)
        {
            var team = await _context.Teams.FindAsync(request.Id).ConfigureAwait(false);
            if (team == null)
                return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
    }

}
