namespace Officeworkflows.Api.Services.Dto.Holidays
{
    public class HolidayResponseDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
    }
}
