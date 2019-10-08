using MobileApp.Models;
using System;
using System.Diagnostics;
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
            NavigationPage.SetHasBackButton(this, false);

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
                var user = new User
                {
                    Email = EmailEntry.Text,
                    DisplayName = DisplayNameEntry.Text,
                    Password = PasswordEntry.Text
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
                    Debug.WriteLine(ex);
                }
            }
        }

        private async void Login_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}