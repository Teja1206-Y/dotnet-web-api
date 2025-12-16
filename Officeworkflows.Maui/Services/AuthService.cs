using Newtonsoft.Json;
using Officeworkflows.Maui.Models;   // ✅ IMPORTANT: DTO namespace
using Officeworkflows.Maui.Services.Dto;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static Officeworkflows.Maui.Components.Pages.Holidays;

namespace Officeworkflows.Maui.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {

            Console.WriteLine("🔐 LoginAsync() CALLED");


            var dto = new LoginRequestDto   // ✅ Using DTO instead of anonymous object
            {
                Email = email,
                Password = password
            };




            Console.WriteLine($"📤 Sending Login request to: {_httpClient.BaseAddress}api/auth/login");
            Console.WriteLine($"📦 Payload → Email: {dto.Email}, Password: {dto.Password}");


            var response = await _httpClient.PostAsJsonAsync("api/auth/login", dto);

            Console.WriteLine($"✅ StatusCode: {response.StatusCode}");


            var responseJson = await response.Content.ReadAsStringAsync();


            Console.WriteLine($"🔍 Response JSON: {responseJson}");


            if (!response.IsSuccessStatusCode)
            {

                Console.WriteLine("❌ Login Failed.");

                return null;
            }

            var result = JsonConvert.DeserializeObject<LoginResponse>(responseJson);


            Console.WriteLine("✅ Token parsed and returned");


            return result?.Token;
        }

        private class LoginResponse
        {
            public string Token { get; set; }  // ✅ Consistent casing (PascalCase)
        }

        public async Task<bool> RegisterAsync(string fullName, string email, string password)
        {
            var dto = new RegisterRequestDto
            {
                FullName = fullName,
                Email = email,
                Password = password
            };

            var json = JsonConvert.SerializeObject(dto);

            var response = await _httpClient.PostAsync(
                "api/auth/register",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            return response.IsSuccessStatusCode;
        }
       



        
    }
}



