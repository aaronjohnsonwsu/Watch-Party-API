using System.Collections.Generic;

namespace WatchPartyApi.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<UserLocation> UserLocations { get; set; }
        public List<UserTeam> UserTeams { get; set; }
    }
}
