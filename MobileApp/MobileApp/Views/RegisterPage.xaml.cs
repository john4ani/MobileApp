using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();            

            DisplayNameEntry.ReturnCommand = new Command(() => EmailEntry.Focus());
            EmailEntry.ReturnCommand = new Command(() => PasswordEntry.Focus());
            
            PasswordEntry.ReturnCommand = new Command(() => ConfirmpasswordEntry.Focus());
            ConfirmpasswordEntry.ReturnCommand = new Command(() => Register.Focus());
        }

        private async void SignupValidation_ButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DisplayNameEntry.Text) || string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
            else if(RepresentingBusiness.IsChecked && (string.IsNullOrEmpty(BusinessNameEntry.Text) || string.IsNullOrEmpty(BusinessRegNoEntry.Text)))
            {
                await DisplayAlert("Enter Business Data", "When representing a business, your Business Name and Business Registration Number are mandatory.", "OK");
            }
            else if (!string.Equals(PasswordEntry.Text, ConfirmpasswordEntry.Text))
            {
                WarningLabel.Text = "Enter Same Password";
                PasswordEntry.Text = string.Empty;
                ConfirmpasswordEntry.Text = string.Empty;
                WarningLabel.TextColor = Color.IndianRed;
                WarningLabel.IsVisible = true;
            }
            else
            {
                var user = new Models.User
                {
                    Email = EmailEntry.Text,
                    DisplayName = DisplayNameEntry.Text,
                    Password = PasswordEntry.Text,
                    Id = Guid.NewGuid().ToString(),
                    CurrentAddress = AddressEntry.Text
                };

                try
                {
                    var insertedOk = await App.GetUserService().AddUserAsync(user);
                    if (insertedOk)
                    {
                        await DisplayAlert("User Add", "Registration Successfull.", "OK");
                        await Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        await DisplayAlert("User Add", "Something went wrong.", "OK");
                        WarningLabel.IsVisible = false;
                        EmailEntry.Text = string.Empty;
                        DisplayNameEntry.Text = string.Empty;
                        PasswordEntry.Text = string.Empty;
                        ConfirmpasswordEntry.Text = string.Empty;                        
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("User Add", "Registration not successfull.", "OK");
                }
            }
        }

        private async void Login_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void OnRepresentingBusinessClicked(object sender, CheckedChangedEventArgs e)
        {
            BussinessFields.IsVisible = e.Value;
        }
    }
}