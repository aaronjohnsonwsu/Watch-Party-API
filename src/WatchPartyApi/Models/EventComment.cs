namespace WatchPartyApi.Models
{
    public class EventComment
    {
        public string Id { get; set; }
        public string EventId { get; set; }
        public string CreatedByUserId { get; set; }
        public string ParentCommentId { get; set; }
        public string Comment { get; set; }
        public int NumberOfFlags { get; set; }
        public bool IsDeleted { get; set; }
    }
}
