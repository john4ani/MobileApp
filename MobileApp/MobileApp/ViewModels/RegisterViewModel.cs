using MobileApp.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class RegisterViewModel
    {
        RegistrationService _registrationService = new RegistrationService();

        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(c => 
                {
                    _registrationService.RegisterAsync(DisplayName,Email,Password,ConfirmPassword);
                });
            }
        }
    }
}
