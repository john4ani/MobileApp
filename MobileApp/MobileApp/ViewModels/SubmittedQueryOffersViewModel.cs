using MobileApp.Models;
using MobileApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class SubmittedQueryOffersViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Query _submittedQuery;
        private ObservableCollection<QueryOffer> _offers;

        public SubmittedQueryOffersViewModel(Query submittedQuery, INavigation navigation) : base(navigation)
        {
            _submittedQuery = submittedQuery;
            TakeActionOnReceivedOffer = new Command<QueryOffer>(ActionOnReceivedOffer);
            MessagingCenter.Subscribe<SubmittedQueryOffersViewModel, QueryOffer>(this, Constants.MSG_ITEMUPDATED, ItemUpdated);
        }

        public ICommand TakeActionOnReceivedOffer
        {
            get;
            private set;
        }

        public void ActionOnReceivedOffer(QueryOffer item)
        {
            Navigation.PushAsync(
                new ReceivedOfferTakeAction(item, Navigation));
        }

        public void ItemUpdated(SubmittedQueryOffersViewModel model, QueryOffer item)
        {
            if (Items != null)
            {
                var targetItem = Items.First((i) => i.Id == item.Id);
                targetItem.OfferPrice = item.OfferPrice;
            }
        }

        public ObservableCollection<QueryOffer> Items
        {
            get { return _offers; }
            set
            {
                _offers = value;
                NotifyPropertyChanged("Items");
            }
        }

        public async Task<bool> Load()
        {
            //escape if already loaded
            if (Items != null)
                return false;

            IsLoading = true;

            var offers = await App.GetQueringService().GetSubmittedQueryOffers(_submittedQuery.Id);
            Items = new ObservableCollection<QueryOffer>(offers);

            IsLoading = false;
            return true;
        }

    }
}
