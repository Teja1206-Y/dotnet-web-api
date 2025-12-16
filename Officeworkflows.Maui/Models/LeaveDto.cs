using System;

namespace Officeworkflows.Maui.Services.Dto
{
    // This is the DTO for GETTING leaves from the API
    public class LeaveDto
    {
        // Properties the server will send back
        public Guid Id { get; set; }
        public string LeaveType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Approved"
        // public string EmployeeName { get; set; } // Add other fields as needed
    }
}