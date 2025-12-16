using Officeworkflows.Maui.Models; // Or wherever your DTOs are
using System.Net.Http.Json;
using static Officeworkflows.Maui.Components.Pages.Holidays;

namespace Officeworkflows.Maui.Services
{
    // Make sure this class is public!
    public class HolidayService
    {
        private readonly HttpClient _httpClient;

        public HolidayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<HolidayDto>> GetHolidays()
        {
            // This will now automatically send the auth token
            // once AuthService adds it to the shared HttpClient
            return await _httpClient.GetFromJsonAsync<List<HolidayDto>>("api/holiday")
                   ?? new List<HolidayDto>();
        }

        public async Task<bool> AddHoliday(HolidayDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/holiday", dto);
            return response.IsSuccessStatusCode;
        }
    }
}