using MobileApp.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class MakeOfferForReceivedQueryViewModel
    : ViewModelBase, INotifyPropertyChanged
    {
        private ReceivedQuery _receivedQuery;

        public MakeOfferForReceivedQueryViewModel(ReceivedQuery item, INavigation navigation) : base(navigation)
        {
            _receivedQuery = item;
            Price = 0;
            MakeOfferCommand = new Command<Bid>(ExecuteMakeOffer, CanExecuteMakeOffer);
        }


        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    NotifyPropertyChanged("Price");
                }
            }
        }


        public ReceivedQuery ReceivedQuery
        {
            get { return _receivedQuery; }
            set
            {
                _receivedQuery = value;
                NotifyPropertyChanged("ReceivedQuery");
            }
        }

        public ICommand MakeOfferCommand { get; private set; }

        public async void ExecuteMakeOffer(Bid parameter)
        {

            var newBid = await App.GetQueringService().MakeSubmittedQueryOffer(
                new SubmittedQueryOffer({ = targetItem.Id, BidAmount = BidAmount });

            Item.CurrentBid = newBid.BidAmount;

            MessagingCenter.Send<PlaceBidViewModel, AuctionItem>(this, Constants.MSG_ITEMUPDATED, Item);

            //move back to the page they were on before bidding
            await Navigation.PopAsync();

        }
        public bool CanExecuteMakeOffer(Bid parameter)
        {
            return true;
        }
    }
}
