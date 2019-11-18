using MobileApp.ViewModels;
using MobileApp.Views.CreateQuery;
using MobileApp.Views.GoogleMaps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new QueriesViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((QueriesViewModel)BindingContext).Load();
        }

        private void NewQueryButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SelectQueryCategory());
        }

        private void ManageSubscriptionsButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MapView());
        }
    }
}