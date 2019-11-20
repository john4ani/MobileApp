using MobileApp.Models;
using MobileApp.ViewModels;
using MobileApp.Views.User;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.SubmittedQueries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReceivedOfferTakeAction : ContentPage
    {
        public ReceivedOfferTakeAction(QueryOffer offer, INavigation navigation)
        {
            InitializeComponent();
            BindingContext = new ReceivedOfferTakeActionViewModel(offer, navigation);
        }

        
        private async void RejectButton_Clicked(object sender, System.EventArgs e)
        {
            //_offer.Status = OfferStatus.Irrelevant;
            //await App.GetQueringService().UpdateQueryOfferAsync(_offer);
            await Navigation.PopAsync();
        }
    }
}