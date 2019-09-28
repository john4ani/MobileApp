using MobileApp.ViewModels;
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
            this.BindingContext = new QueriesViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((QueriesViewModel)BindingContext).Load();
        }
    }
}