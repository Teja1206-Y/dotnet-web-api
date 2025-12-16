namespace OfficeWorkflows.Api.DTOs.Leave
{
    public class CreateLeaveDto
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
