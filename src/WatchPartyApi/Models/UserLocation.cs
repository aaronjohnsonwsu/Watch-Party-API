namespace WatchPartyApi.Models
{
    public class UserLocation
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string GooglePlaceId { get; set; }

        public User User { get; set; }
    }
}
