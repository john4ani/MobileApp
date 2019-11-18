using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage()
        {
            InitializeComponent();
            
            NavigationPage.SetHasBackButton(this, false);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            firstPassword.ReturnCommand = new Command(() => secondPassword.Focus());
            var forgetpassword_tap = new TapGestureRecognizer();
            forgetpassword_tap.Tapped += Forgetpassword_tap_Tapped;
            forgetLabel.GestureRecognizers.Add(forgetpassword_tap);
        }
        private void Forgetpassword_tap_Tapped(object sender, EventArgs e)
        {
            popupLoadingView.IsVisible = true;
        }

        private async void EmailCheckEvent(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(useridValidationEntry.Text))
            {
                await DisplayAlert("Alert", "Enter Mail Id", "OK");
            }
            else
            {
                var isEmailValid = await App.GetUserService().ValidateUserEmailAsync(useridValidationEntry.Text);
                if (isEmailValid)
                {
                    popupLoadingView.IsVisible = false;
                    passwordView.IsVisible = true;
                }
                else
                {
                    await DisplayAlert("User Mail Id Not Exist", "Enter Correct User Name", "OK");
                }
            }
        }
        private async void Password_ClickedEvent(object sender, EventArgs e)
        {
            if (!string.Equals(firstPassword.Text, secondPassword.Text))
            {
                warningLabel.Text = "Enter Same Password";
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else if ((string.IsNullOrWhiteSpace(firstPassword.Text)) || (string.IsNullOrWhiteSpace(secondPassword.Text)))
            {
                await DisplayAlert("Alert", " Enter Password", "OK");
            }
            else
            {
                try
                {
                    var return1 = await App.GetUserService().UpdateUserPasswordAsync(useridValidationEntry.Text, firstPassword.Text);
                    passwordView.IsVisible = false;
                    if (return1)
                    {
                        await DisplayAlert("Password Updated", "User Data updated", "OK");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private async void LoginValidation_ButtonClicked(object sender, EventArgs e)
        {
            if (userNameEntry.Text != null && passwordEntry.Text != null)
            {
                var validData = await App.GetUserService().ValidateLoginAsync(userNameEntry.Text, passwordEntry.Text);
                if (validData)
                {
                    popupLoadingView.IsVisible = false;
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    popupLoadingView.IsVisible = false;
                    await DisplayAlert("Login Failed", "Username or Password Incorrect", "OK");
                }
            }
            else
            {
                popupLoadingView.IsVisible = false;
                await DisplayAlert("He He", "Enter User Name and Password Please", "OK");
            }
        }
    }
}