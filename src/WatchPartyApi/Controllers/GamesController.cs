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
    public class GamesController : Controller
    {
        private readonly WatchPartyDbContext _context;

        public GamesController(WatchPartyDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<List<Game>> Get()
        {
            return await _context.Games.Include(g => g.Events)
                                       .Include(g => g.Team).ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Game> Get(string id)
        {
            return await _context.Games.Include(g => g.Events)
                .Include(g => g.Team).FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
