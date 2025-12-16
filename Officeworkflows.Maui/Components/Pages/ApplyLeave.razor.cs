using Microsoft.AspNetCore.Components;
using Officeworkflows.Maui.Models.Leaves;
using Officeworkflows.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Officeworkflows.Maui.Components.Pages
{
    public partial class ApplyLeave
    {
        // 2. Inject services
        [Inject]
        public LeaveService LeaveSvc { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        // 3. Use the correct DTO we created: ApplyLeaveDto
        public LeaveRequestDto Leave { get; set; } = new();
        public bool isLoading = false;
        public string Message = "";

        // 4. This is the handler your form calls
        public async Task ApplyLeaveHandler()
        {
            isLoading = true;
            Message = "";

            try
            {
                // 5. Use the LeaveService
                bool success = await LeaveSvc.ApplyLeave(Leave);

                if (success)
                {
                    Message = "Success: Leave Applied!";
                    Leave = new(); // Clear the form
                }
                else
                {
                    Message = "Error: Could not submit leave.";
                }
            }
            catch (Exception ex)
            {
                Message = $"Error: {ex.Message}";
            }

            isLoading = false;
        }

        public void GoBack()
        {
            // Go back to the dashboard
            Navigation.NavigateTo("/leaves");
        }
    }
}
