using MobileApp.Models;
using MobileApp.ViewModels;
using MobileApp.Views.User;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.ReceivedQueries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeOfferForReceivedQuery : ContentPage
    {
        private string _userId;
        public MakeOfferForReceivedQuery(Query query, INavigation navigation)
        {
            InitializeComponent();
            BindingContext = new MakeOfferForReceivedQueryViewModel(query, navigation);
            _userId = query.UserId;
        }

        private void TextCell_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UserDetails(_userId));
        }
    }
}