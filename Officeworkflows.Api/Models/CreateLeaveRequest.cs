namespace Officeworkflows.Api.Models
{
    public class CreateLeaveRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; }
    }
}
