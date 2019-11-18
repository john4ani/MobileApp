using MobileApp.Models;
using MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.SubmittedQueries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReceivedOfferTakeAction : ContentPage
    {
        QueryOffer _offer;
        public ReceivedOfferTakeAction(QueryOffer offer, INavigation navigation)
        {
            InitializeComponent();
            //this.BindingContext = new ReceivedOfferTakeActionViewModel(offer, navigation);
            _offer = offer;
        }

        private async void AcceptButton_Clicked(object sender, System.EventArgs e)
        {
            _offer.Status = OfferStatus.Accepted;
            await App.GetQueringService().UpdateQueryOfferAsync(_offer);
            await Navigation.PopAsync();
        }

        private async void RejectButton_Clicked(object sender, System.EventArgs e)
        {
            _offer.Status = OfferStatus.Irrelevant;
            await App.GetQueringService().UpdateQueryOfferAsync(_offer);
            await Navigation.PopAsync();
        }
    }
}