namespace Officeworkflows.Api.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }

        public int UserId { get; set; }  // FK reference to Users table
        public User? User { get; set; }  // <-- ✅ Navigation Property

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string Reason { get; set; }

        public string Status { get; set; } = "Pending"; // Pending / Approved / Rejected
        public DateTime RequestedDate { get; internal set; }
    }
}
