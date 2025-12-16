using Microsoft.AspNetCore.Components;
using Officeworkflows.Maui.Services;
using Officeworkflows.Maui.Models; // Make sure your LeaveDto is here
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Officeworkflows.Maui.Services.Dto;

namespace Officeworkflows.Maui.Components.Pages
{
    public partial class Leaves
    {
        // 1. INJECT YOUR SERVICES
        [Inject]
        private LeaveService LeaveSvc { get; set; }

        [Inject]
        private NavigationManager Navigation { get; set; }

        // 2. DEFINE YOUR PROPERTIES
        int TotalLeaves = 24; // TODO: Get from API
        int UsedLeaves = 8;   // TODO: Get from API
        int AvailableLeaves => TotalLeaves - UsedLeaves;

        private List<LeaveDto> LeaveHistory { get; set; } = new List<LeaveDto>();
        private string ErrorMessage { get; set; }

        // 3. LOAD DATA FROM THE API WHEN THE PAGE LOADS
        protected override async Task OnInitializedAsync()
        {
            try
            {
                LeaveHistory = await LeaveSvc.GetLeaves();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Failed to load leave history: {ex.Message}";
                Console.WriteLine(ErrorMessage);
            }
        }

        // 4. YOUR NAVIGATION METHODS
        private void ApplyLeave()
        {
            // This button navigates to your *other* page
            Navigation.NavigateTo("/apply-leave");
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/dashboard");
        }
        private void Addleave()
        {
            Navigation.NavigateTo("/applyleave");
        }
    }
}