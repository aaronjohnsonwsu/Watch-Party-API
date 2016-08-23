using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WatchPartyApi.Models
{
    public class WatchPartyDbContext : DbContext
    {
        public WatchPartyDbContext(DbContextOptions<WatchPartyDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventComment> EventComments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
    }
}
