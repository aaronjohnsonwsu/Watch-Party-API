using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchPartyApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WatchPartyApi.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private WatchPartyDbContext _context;

        public TeamsController(WatchPartyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Team>> Get()
        {
            return await _context.Teams.Include(t => t.Games)
                                       .Include(t => t.Events)
                                       .Include(t => t.UserTeams).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Team> Get(string id)
        {
            return await _context.Teams.Include(t => t.Games)
                                       .Include(t => t.Events)
                                       .Include(t => t.UserTeams).FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
