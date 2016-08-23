using System.Collections.Generic;

namespace WatchPartyApi.Models
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Mascot { get; set; }
        public string EspnPageUrl { get; set; }
        public string EspnTeamId { get; set; }
        public string Conference { get; set; }
        public int NationalRank { get; set; }

        public List<Game> Games { get; set; }
        public List<Event> Events { get; set; }
        public List<UserTeam> UserTeams { get; set; }
    }
}
