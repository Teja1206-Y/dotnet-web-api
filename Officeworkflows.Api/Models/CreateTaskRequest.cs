namespace Officeworkflows.Api.Models
{
    public class CreateTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int? AssignedToUserId { get; set; }   // optional at creation
    }
}
