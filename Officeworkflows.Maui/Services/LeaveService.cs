using Officeworkflows.Maui.Models.Leaves; // Update with your DTOs
using Officeworkflows.Maui.Services.Dto;
using System.Net.Http.Json;

namespace Officeworkflows.Maui.Services
{
    public class LeaveService
    {
        private readonly HttpClient _httpClient;

        public LeaveService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Example: Get all leaves
        public async Task<List<LeaveDto>> GetLeaves()
        {
            return await _httpClient.GetFromJsonAsync<List<LeaveDto>>("api/leave")
                   ?? new List<LeaveDto>();
        }

        // Example: Apply for a new leave
        public async Task<bool> ApplyLeave(LeaveRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/leave", dto);
            return response.IsSuccessStatusCode;
        }
    }
}