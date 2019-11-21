using MobileApp.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class MakeOfferForReceivedQueryViewModel : ViewModelBase
    {
        private Query _receivedQuery;

        public MakeOfferForReceivedQueryViewModel(Query item, INavigation navigation) : base(navigation)
        {
            _receivedQuery = item;
            ReceivedQueryUser = App.GetUserService().GetUserAsync(item.UserId).Result;
            Price = 0;
            MakeOfferCommand = new Command<Offer>(ExecuteMakeOffer, CanExecuteMakeOffer);
        }

        public ICommand MakeOfferCommand { get; private set; }

        public User ReceivedQueryUser { get; set; }

        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    NotifyPropertyChanged(nameof(Price));
                }
            }
        }        

        public Query ReceivedQuery
        {
            get { return _receivedQuery; }
            set
            {
                _receivedQuery = value;
                NotifyPropertyChanged(nameof(ReceivedQuery));
            }
        }

        private bool CanExecuteMakeOffer(Offer parameter)
        {
            return true;
        }

        private async void ExecuteMakeOffer(Offer parameter)
        {

            var newBid = await App.GetQueriesService().MakeSubmittedQueryOffer(
                new QueryOffer{ QueryId = _receivedQuery.Id, OfferPrice = Price, Description = "Offer for " + _receivedQuery.Name, UserId = App.GetUserService().GetLoggedInUserAsync().Result.Id });

            MessagingCenter.Send(this, Constants.MSG_ITEMUPDATED, ReceivedQuery);

            //move back to the page they were on before bidding
            await Navigation.PopAsync();

        }        
    }
}
