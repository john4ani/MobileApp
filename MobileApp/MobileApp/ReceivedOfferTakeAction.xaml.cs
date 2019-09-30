using MobileApp.Models;
using MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReceivedOfferTakeAction : TabbedPage
    {
        public ReceivedOfferTakeAction(SubmittedQueryOffer offer)
        {
            InitializeComponent();
            this.BindingContext = new ReceivedOfferTakeActionViewModel(offer, Navigation);
        }
    }
}