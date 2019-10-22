using Microsoft.WindowsAzure.MobileServices;
using MobileApp.Services;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class App : Application
    {
        private static IQueriesService _queriesService;
        private static IUserService _userService;

        public App()
        {
            //var mobileClient = new MobileServiceClient("http://localhost/MobileAppBackend");
            _queriesService = new MockQueriesService();
            _userService = new MockUserService();
            InitializeComponent();
            var userProfileCreated = false;

            if (!userProfileCreated)
                MainPage = new NavigationPage(new MainPage());
            else
                MainPage = new NavigationPage(new Queries());
        }

        public static IQueriesService GetQueringService()
        {
            return _queriesService;
        }

        public static IUserService GetUserService()
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
