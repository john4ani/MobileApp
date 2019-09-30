using MobileApp.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class ReceivedOfferTakeActionViewModel
    : ViewModelBase, INotifyPropertyChanged
    {
        private QueryOffer _offer;

        public ReceivedOfferTakeActionViewModel(QueryOffer offer, INavigation navigation) : base(navigation)
        {
            _offer = offer;
            AcceptOfferCommand = new Command<Offer>(ExecuteAcceptOffer, CanExecuteAcceptOffer);
        }       


        public QueryOffer Offer
        {
            get { return _offer; }
            set
            {
                _offer = value;
                NotifyPropertyChanged("Offer");
            }
        }

        public ICommand AcceptOfferCommand { get; private set; }

        public async void ExecuteAcceptOffer(Offer parameter)
        {
            //#TODO
            //var newBid = await App.GetQueringService().MakeSubmittedQueryOffer(
            //    new SubmittedQueryOffer{ SubmittedQueryId = _receivedQuery.Id, OfferPrice = Price });

            MessagingCenter.Send(this, Constants.MSG_ITEMUPDATED, Offer);

            //move back to the page they were on before bidding
            await Navigation.PopAsync();

        }
        public bool CanExecuteAcceptOffer(Offer parameter)
        {
            return true;
        }
    }
}
