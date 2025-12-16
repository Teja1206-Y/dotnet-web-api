using System;
using System.ComponentModel.DataAnnotations;

namespace Officeworkflows.Maui.Models.Tasks
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "Task title is required")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Deadline is required")]
        public DateTime Deadline { get; set; }

        [Required(ErrorMessage = "Select employee")]
        public int AssignedToUserId { get; set; }
        public string Priority { get; set; } = "Medium";
    }
}
