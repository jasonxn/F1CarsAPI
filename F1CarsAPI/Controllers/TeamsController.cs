﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F1CarsAPI.Data;
using F1CarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace F1CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TeamsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.Teams.ToListAsync().ConfigureAwait(false);
        }
        // GET: api/teams/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return team;
        }
        // POST: api/teams
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
        }
        // PUT: api/teams/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }
            _context.Entry(team).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)

            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }

        // DELETE: api/teams/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

}
