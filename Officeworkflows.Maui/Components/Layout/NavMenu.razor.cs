using Officeworkflows.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Officeworkflows.Maui.Components.Layout
{
    public partial class NavMenu
    {
        async Task Logout()
        {
            SecureStorageService.ClearToken();
            Navigation.NavigateTo("/login", true);
        }
    }
}
