namespace Officeworkflows.Api.Services.Dto.Holidays
{
    public class CreateHolidayDto
    {
        public DateTime Date { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";  // Optional (public, optional, festival)
    }
}
