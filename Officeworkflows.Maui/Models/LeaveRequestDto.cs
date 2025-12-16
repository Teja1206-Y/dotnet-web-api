using System;
using System.ComponentModel.DataAnnotations;

namespace Officeworkflows.Maui.Models.Leaves
{
    public class LeaveRequestDto
    {
        [Required]
        public string LeaveType { get; set; } = "";

        [Required]
        public DateTime FromDate { get; set; } = DateTime.Today;

        [Required]
        public DateTime ToDate { get; set; } = DateTime.Today;

        [Required]
        [StringLength(200)]
        public string Reason { get; set; } = "";
    }
}
