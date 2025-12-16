using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Notifications;
using System.ComponentModel.DataAnnotations;

namespace Officeworkflows.Maui.Components.Pages
{
    public partial class Register
    {
        private RegisterModel registerModel = new();
        private bool isLoading = false;
        private bool showPassword = false;
        private bool showConfirmPassword = false;

        private SfToast Toast;
        private string toastMessage = "";
        private string toastType = "";

        private class RegisterModel
        {
            [Required(ErrorMessage = "Full name is required")]
            public string FullName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Password is required")]
            [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
            public string Password { get; set; } = string.Empty;

            [Required(ErrorMessage = "Please confirm your password")]
            [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
            public string ConfirmPassword { get; set; } = string.Empty;
        }

        private void TogglePasswordVisibility() => showPassword = !showPassword;
        private void ToggleConfirmPasswordVisibility() => showConfirmPassword = !showConfirmPassword;

        private async Task RegisterUser()
        {
            try
            {
                isLoading = true;
                StateHasChanged();

                bool success = await AuthService.RegisterAsync(registerModel.FullName, registerModel.Email, registerModel.Password);

                if (success)
                {
                    toastType = "success";
                    toastMessage = "Account created successfully!";
                    await Toast.ShowAsync();
                    await Task.Delay(1500);
                    Navigation.NavigateTo("/login", true);
                }
                else
                {
                    toastType = "error";
                    toastMessage = "Registration failed. Please try again.";
                    await Toast.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                toastType = "error";
                toastMessage = "Something went wrong. Try again.";
                await Toast.ShowAsync();
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                isLoading = false;
                StateHasChanged();
            }
        }
    }
}
