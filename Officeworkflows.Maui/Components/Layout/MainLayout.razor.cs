using Officeworkflows.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Officeworkflows.Maui.Components.Layout
{
    public partial class MainLayout
    {
        private bool isDrawerOpen = false;

        private void ToggleDrawer()
        {
            isDrawerOpen = !isDrawerOpen;
        }

        private bool IsActive(string route)
        {
            return Navigation.Uri.Contains(route);
        }

        private async Task Logout()
        {
            SecureStorageService.ClearToken();
            Navigation.NavigateTo("/login", true);
        }

        private void Navigate(string url)
        {
            Navigation.NavigateTo(url);
            isDrawerOpen = false;
        }
    } 
}

