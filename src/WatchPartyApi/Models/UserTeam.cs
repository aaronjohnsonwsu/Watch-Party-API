namespace WatchPartyApi.Models
{
    public class UserTeam
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string TeamId { get; set; }

        public User User { get; set; }
        public Team Team { get; set; }
    }
}
