using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobileApp.ViewModels;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel(Navigation, Alert);

            DisplayNameEntry.ReturnCommand = new Command(() => EmailEntry.Focus());
            EmailEntry.ReturnCommand = new Command(() => PasswordEntry.Focus());
            
            PasswordEntry.ReturnCommand = new Command(() => ConfirmpasswordEntry.Focus());
            ConfirmpasswordEntry.ReturnCommand = new Command(() => Register.Focus());
        }

        public async void Alert(string title, string message, string cancel)
        {
            await DisplayAlert(title, message, cancel);
        }
    }
}