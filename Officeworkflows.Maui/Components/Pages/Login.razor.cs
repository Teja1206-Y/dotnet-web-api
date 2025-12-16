using Officeworkflows.Maui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Officeworkflows.Maui.Components.Pages
{
    public partial class Login
    {
        private LoginModel loginModel = new LoginModel();
        private string ErrorMessage = string.Empty;
        private bool isLoading = false;
        private string passwordFieldType = "password";
        private string passwordToggleIcon = "fas fa-eye";

        private class LoginModel
        {
            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Password is required")]
            [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
            public string Password { get; set; } = string.Empty;
        }

        private void TogglePasswordVisibility()
        {
            if (passwordFieldType == "password")
            {
                passwordFieldType = "text";
                passwordToggleIcon = "fas fa-eye-slash";
            }
            else
            {
                passwordFieldType = "password";
                passwordToggleIcon = "fas fa-eye";
            }
        }
        private async Task LoginUser()
        {
            try
            {
                isLoading = true;
                ErrorMessage = string.Empty;
                StateHasChanged(); // Force UI update

                var token = await AuthService.LoginAsync(loginModel.Email, loginModel.Password);

                if (string.IsNullOrEmpty(token))
                {
                    ErrorMessage = "Invalid email or password";
                    return;
                }

                // Fixed: Use the static class method correctly
                await SecureStorageService.SaveToken(token);

                Navigation.NavigateTo("/", true);
            }
            catch (Exception ex)
            {
                ErrorMessage = "An error occurred during login. Please try again.";
                Console.WriteLine($"Login error: {ex.Message}");
            }
            finally
            {
                isLoading = false;
                StateHasChanged(); // Force UI update
            }
        }


        protected override void OnInitialized()
        {
            // Initialize component
            base.OnInitialized();
        }
    }
}
