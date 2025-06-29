﻿using F1CarsAPI.Data;
using F1CarsAPI.Models;
using F1CarsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace F1CarsAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync().ConfigureAwait(false);
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id).ConfigureAwait(false);
            if (team == null)
                return NotFound();

            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            var created = await _teamService.CreateTeamAsync(team).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetTeam), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            var success = await _teamService.UpdateTeamAsync(id, team).ConfigureAwait(false);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var deleted = await _teamService.DeleteTeamAsync(id).ConfigureAwait(false);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }



}



























/*
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

}*/
