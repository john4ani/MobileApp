using System;
using System.Windows.Input;
using Xamarin.Forms;

using MobileApp.Views;
using MobileApp.Models;

namespace MobileApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly Action<string, string, string> Alert;
        public RegisterViewModel(INavigation navigation, Action<string,string,string> alert) : base(navigation)
        {
            Alert = alert;
        }

        private string _displayName;
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                NotifyPropertyChanged(nameof(DisplayName));
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyPropertyChanged(nameof(Email));
            }
        }

        private bool _representingBusiness;
        public bool RepresentingBusiness
        {
            get { return _representingBusiness; }
            set
            {
                _representingBusiness = value;
                NotifyPropertyChanged(nameof(RepresentingBusiness));
                NotifyPropertyChanged(nameof(AddressPlaceholder));
            }
        }

        private string _businessName;
        public string BusinessName
        {
            get { return _businessName; }
            set
            {
                _businessName = value;
                NotifyPropertyChanged(nameof(BusinessName));
            }
        }

        private string _businessRegistrationNumber;
        public string BusinessRegistrationNumber
        {
            get { return _businessRegistrationNumber; }
            set
            {
                _businessRegistrationNumber = value;
                NotifyPropertyChanged(nameof(BusinessRegistrationNumber));
            }
        }

        private bool _onlineBusiness;
        public bool OnlineBusiness
        {
            get { return _onlineBusiness; }
            set
            {
                _onlineBusiness = value;
                NotifyPropertyChanged(nameof(OnlineBusiness));
                NotifyPropertyChanged(nameof(AddressPlaceholder));
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                NotifyPropertyChanged(nameof(Address));
            }
        }

        public string AddressPlaceholder
        {
            get { return _representingBusiness ? (_onlineBusiness ? "Business Web Address" : "Business Address") : "Your Address"; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                NotifyPropertyChanged(nameof(ConfirmPassword));
            }
        }

        private string _warningText;

        public string WarningText
        {
            get { return _warningText; }
            set
            {
                _warningText = value;
                NotifyPropertyChanged(nameof(WarningText));
                NotifyPropertyChanged(nameof(WarningIsVisible));
            }
        }

        public bool WarningIsVisible
        {
            get { return !string.IsNullOrEmpty(WarningText); }
        }

        public ICommand Register
        {
            get
            {
                return new Command(async c =>
                {
                    if (string.IsNullOrWhiteSpace(DisplayName) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
                    {
                        Alert("Enter Data", "Enter Valid Data", "OK");
                    }
                    else if (RepresentingBusiness && (string.IsNullOrEmpty(BusinessName) || string.IsNullOrEmpty(BusinessRegistrationNumber)))
                    {
                        Alert("Enter Business Data", "When representing a business, your Business Name and Business Registration Number are mandatory.", "OK");
                    }
                    else if (!string.Equals(Password, ConfirmPassword))
                    {
                        WarningText = "Enter Same Password";
                        Password = string.Empty;
                        ConfirmPassword = string.Empty;

                    }
                    else
                    {
                        if (RepresentingBusiness)
                        {
                            var validBusiness = await App.GetBusinessService().ValidateBusinessAsync(BusinessRegistrationNumber);
                            if (validBusiness)
                            {
                                var business = new Business
                                {
                                    Name = BusinessName,
                                    RegistrationNumber = BusinessRegistrationNumber,
                                    Address = Address,
                                    Id = Guid.NewGuid().ToString(),
                                    OnlineBusiness = OnlineBusiness
                                };
                                await App.GetBusinessService().AddBusinessAsync(business);
                            }
                            else Alert("Enter Business Data", "Business with given Registration Number is already registred.", "OK");
                        }

                        var user = new User
                        {
                            Email = Email,
                            DisplayName = DisplayName,
                            Password = Password,
                            Id = Guid.NewGuid().ToString(),
                            CurrentAddress = Address
                        };

                        try
                        {
                            var insertedOk = await App.GetUserService().AddUserAsync(user);
                            if (insertedOk)
                            {
                                Alert("User Add", "Registration Successfull.", "OK");
                                await Navigation.PushAsync(new LoginPage());
                            }
                            else
                            {
                                Alert("User Add", "Something went wrong.", "OK");
                                Email = string.Empty;
                                DisplayName = string.Empty;
                                Password = string.Empty;
                                ConfirmPassword = string.Empty;
                            }
                        }
                        catch (Exception ex)
                        {
                            Alert("User Add", "Registration not successfull.", "OK");
                        }
                    }
                });
            }
        }

        public ICommand GoToLogin
        {
            get
            {
                return new Command(async c =>
                {
                    await Navigation.PushAsync(new LoginPage());
                });
            }
        }
    }
}
