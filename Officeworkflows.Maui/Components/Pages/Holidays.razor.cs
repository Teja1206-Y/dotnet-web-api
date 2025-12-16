using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Officeworkflows.Maui.Components.Pages
{
    public partial class Holidays
    {
        List<HolidayEvent> HolidayEvents = new();
        List<HolidayDto> AllHolidays = new();
        List<HolidayDto> UpcomingHolidays = new();

        int UpcomingHolidaysCount = 0;
        int PastHolidaysCount = 0;
        string NextHolidayName = "None";

        protected override async Task OnInitializedAsync()
        {
            var token = await Officeworkflows.Maui.Services.SecureStorageService.GetToken();

            if (string.IsNullOrEmpty(token))
            {
                Navigation.NavigateTo("/login", true);
                return;
            }


            Http.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            try
            {
                using var resp = await Http.GetAsync("api/holiday");

                if (!resp.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to load holidays: {resp.StatusCode}");
                    AllHolidays = new List<HolidayDto>();
                }
                else
                {
                    var json = await resp.Content.ReadFromJsonAsync<List<HolidayDto>>();
                    AllHolidays = json ?? new List<HolidayDto>();
                }

                // Fill scheduler events
                HolidayEvents = AllHolidays.Select(h => new HolidayEvent
                {
                    Id = h.Id,
                    Subject = h.Name,
                    StartTime = h.Date,
                    EndTime = h.Date.AddHours(24),
                    IsAllDay = true
                }).ToList();

                CalculateHolidayStats();
            }
            catch
            {
                AllHolidays = new List<HolidayDto>();
            }
        }

        private void CalculateHolidayStats()
        {
            var today = DateTime.Today;
            UpcomingHolidays = AllHolidays.Where(h => h.Date >= today).OrderBy(h => h.Date).ToList();

            UpcomingHolidaysCount = UpcomingHolidays.Count;
            PastHolidaysCount = AllHolidays.Count - UpcomingHolidaysCount;

            NextHolidayName = UpcomingHolidays.FirstOrDefault()?.Name ?? "None";
        }

        private string GetDaysAwayText(DateTime date)
        {
            int days = (date - DateTime.Today).Days;
            return days switch
            {
                0 => "Today",
                1 => "Tomorrow",
                _ => $"{days} days away"
            };
        }
        private void GoBack()
        {
            Navigation.NavigateTo("/dashboard");
        }
        public class HolidayDto
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Name { get; set; }
        }

        public class HolidayEvent
        {
            public int Id { get; set; }
            public string Subject { get; set; } = "";
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool IsAllDay { get; set; }
        }
    }
}
