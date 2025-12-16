namespace Officeworkflows.Api.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // national / optional / company-specific
    }
}
