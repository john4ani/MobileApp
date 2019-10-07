using MobileApp.ViewModels;
using MobileApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Queries : TabbedPage
    {
        public Queries()
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
            Navigation.PushAsync(new QueryCategoriesPage());
        }
    }
}