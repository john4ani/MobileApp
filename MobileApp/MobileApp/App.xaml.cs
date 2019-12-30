using Microsoft.WindowsAzure.MobileServices;
using MobileApp.Repositories;
using MobileApp.Services;
using MobileApp.Views;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class App : Application
    {
        private static IQueriesService _queriesService;
        private static IUserService _userService;
        private static IBusinessService _businessService;

        public App()
        {
            //var mobileClient = new MobileServiceClient("http://localhost/MobileAppBackend");
            _queriesService = new MockQueriesService();
            _userService = new MockUserService();

            var businessRepository = new BusinessRepository();
            _businessService = new BusinessService(businessRepository);

            InitializeComponent();
            var userProfileCreated = false;

            if (!userProfileCreated)
                MainPage = new NavigationPage(new MainPage());
            else
                MainPage = new NavigationPage(new HomePage());
        }

        public static IQueriesService GetQueriesService()
        {
            return _queriesService;
        }

        public static IUserService GetUserService()
        {
            return _userService;
        }

        public static IBusinessService GetBusinessService()
        {
            return _businessService;
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
