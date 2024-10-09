namespace EventRegestration1.Models.DTO
{
    public class EventDTO
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
    }
}
