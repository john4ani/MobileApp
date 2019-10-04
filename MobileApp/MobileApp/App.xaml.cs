using Microsoft.WindowsAzure.MobileServices;
using MobileApp.Services;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class App : Application
    {
        private static QueriesService _queriesService;
        private static UserService _userService;

        public App()
        {
            var mobileClient = new MobileServiceClient("https://mobileappbackend20191004060520.azurewebsites.net/");
            _queriesService = new QueriesService(mobileClient);
            _userService = new UserService(mobileClient);
            InitializeComponent();
            var userProfileCreated = false;

            if (!userProfileCreated)
                MainPage = new NavigationPage(new MainPage());
            else
                MainPage = new NavigationPage(new Queries());
        }

        public static QueriesService GetQueringService()
        {
            return _queriesService;
        }

        public static UserService GetUserService()
        {
            return _userService;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
