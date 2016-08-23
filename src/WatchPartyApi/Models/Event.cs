using System;
using System.Collections.Generic;

namespace WatchPartyApi.Models
{
    public class Event
    {

        public string Id { get; set; }
        public string TeamId { get; set; }
        public string GameId { get; set; }
        public string GooglePlaceId { get; set; }
        public DateTime DateAdded { get; set; }
        public string CreatedByUserId { get; set; }
        public int NumberAttending { get; set; }
        public bool IsCancelled { get; set; }
        public string CancellationReason { get; set; }
        public string LocationCoordinates { get; set; }

        public Team Team { get; set; }
        public Game Game { get; set; }
        public List<EventComment> Comments { get; set; }
    }
}
