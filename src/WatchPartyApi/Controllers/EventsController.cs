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
    public class EventsController : Controller
    {
        private WatchPartyDbContext _context;

        public EventsController(WatchPartyDbContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public async Task<List<Event>> Get()
        {
            return await _context.Events.Include(e => e.Team)
                                        .Include(e => e.Game)
                                        .Include(e => e.Comments).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Event> Get(string id)
        {
            return await _context.Events.Include(e => e.Team)
                            .Include(e => e.Game)
                            .Include(e => e.Comments).FirstOrDefaultAsync(e => e.Id == id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Event evnt)
        {
            if (evnt == null)
            {
                return BadRequest("Invalid passed data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Events.Add(evnt);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Db Update Error has occured");
            }

            return CreatedAtRoute("WatchPartyApi", new {id = evnt.Id}, evnt);
        }

    }
}
