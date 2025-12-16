namespace Officeworkflows.Api.Services.Dto.Tasks

{
    public class CreateTaskDto
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Deadline { get; set; }
        public int AssignedToUserId { get; set; }   // ✅ required for manager assignment
        public string Priority { get; set; } = "Medium";
    }
}

