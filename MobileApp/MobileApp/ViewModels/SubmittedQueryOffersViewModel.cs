using MobileApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
                new ReceivedOfferTakeAction(item));
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

        public void Load()
        {
            //escape if already loaded
            if (Items != null)
                return;

            IsLoading = true;

            App.GetQueringService().GetSubmittedQueryOffers(_submittedQuery.Id).ContinueWith(
                (ait) =>
                {
                    if (ait.Exception == null)
                    {
                        Items = new ObservableCollection<QueryOffer>(ait.Result);
                    }
                    else
                    {
                        //handle exception
                    }

                    IsLoading = false;
                });
        }

    }
}
