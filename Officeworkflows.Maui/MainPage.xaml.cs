using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Officeworkflows.Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();   // ✅ Required

            ShowSnackbar();          // ✅ Call the method
        }

        private async void ShowSnackbar()
        {
            await this.DisplaySnackbar("Toolkit is working 🎉");
        }
    }
}
