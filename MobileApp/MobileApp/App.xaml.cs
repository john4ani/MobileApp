using Xamarin.Forms;

namespace MobileApp
{
    public partial class App : Application
    {
        private static QueringService _service;
        static App()
        {
            _service = new QueringService("https://mobileappbackendion.azurewebsites.net/");
        }
        public App()
        {
            InitializeComponent();
            var userProfileCreated = true;

            if (!userProfileCreated)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new Queries());
        }

        public static QueringService GetQueringService()
        {
            return _service;
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
