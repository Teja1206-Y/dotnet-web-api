using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Officeworkflows.Maui.Components.Pages
{
    public partial class Home
    {
        protected override async Task OnInitializedAsync()
        {
            // read JWT from your static helper
            var token = await Officeworkflows.Maui.Services.SecureStorageService.GetToken();

            if (string.IsNullOrEmpty(token))
                Navigation.NavigateTo("/login", forceLoad: true);
            else
                Navigation.NavigateTo("/dashboard", forceLoad: true);
        }
    }
}
