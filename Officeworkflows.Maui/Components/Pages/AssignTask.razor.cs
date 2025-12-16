using Officeworkflows.Maui.Models.Tasks;
using Officeworkflows.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Officeworkflows.Maui.Components.Pages
{
    public partial class AssignTask
    {

        private CreateTaskDto TaskModel = new();
        private List<UserDto> Employees = new();
        private string Message = "";
        private bool isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            var token = await SecureStorageService.GetToken();

            if (string.IsNullOrEmpty(token))
            {
                Navigation.NavigateTo("/login", true);
                return;
            }

            Http.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // TODO: FIX ↓ once API is ready
            // Employees = await Http.GetFromJsonAsync<List<UserDto>>("api/users");
        }

        private async Task AssignTaskHandler()
        {
            try
            {
                isLoading = true;
                Message = "";

                if (TaskModel.AssignedToUserId == 0)
                {
                    Message = "❌ Please select an employee.";
                    return;
                }

                var response = await Http.PostAsJsonAsync("api/tasks", TaskModel);

                Message = response.IsSuccessStatusCode
                    ? "Success: Task assigned!"
                    : "❌ Failed to assign the task!";
            }
            finally
            {
                isLoading = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/dashboard");
        }

        public class UserDto
        {
            public int Id { get; set; }
            public string FullName { get; set; } = "";
            public string Email { get; set; } = "";
        }
    }
}
