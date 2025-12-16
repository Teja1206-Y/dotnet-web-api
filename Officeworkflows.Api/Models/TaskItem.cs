namespace Officeworkflows.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        // ✅ we use this to track completion
        public bool IsCompleted { get; set; } = false;

        // ✅ Task assigned to a specific user (optional)
        public int? AssignedToUserId { get; set; }
        public User? AssignedToUser { get; set; }
    }
}
