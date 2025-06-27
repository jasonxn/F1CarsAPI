    using F1CarsAPI.Data;
    using F1CarsAPI.Models;
using F1CarsAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace F1CarsAPI.Services
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContext _context;

        public TeamService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.Include(t => t.Cars).ToListAsync();
        }

        public async Task<Team?> GetTeamByIdAsync(int id)
        {
            return await _context.Teams.Include(t => t.Cars).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<bool> UpdateTeamAsync(int id, Team updatedTeam)
        {
            if (id != updatedTeam.Id)
                return false;

            _context.Entry(updatedTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                if (!await _context.Teams.AnyAsync(t => t.Id == id))
                    return false;

                throw;
            }
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
                return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
