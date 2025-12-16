namespace Officeworkflows.Api.Services.Dto.Holidays
{
    public class HolidayRequestDto
    {
        public DateTime Date { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
    }
}
