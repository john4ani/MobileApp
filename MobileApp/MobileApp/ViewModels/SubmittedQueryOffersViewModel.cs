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
        private SubmittedQuery _submittedQuery;
        private ObservableCollection<SubmittedQueryOffer> _offers;

        public SubmittedQueryOffersViewModel(SubmittedQuery submittedQuery, INavigation navigation) : base(navigation)
        {
            _submittedQuery = submittedQuery;
            TakeActionOnReceivedOffer = new Command<SubmittedQueryOffer>(ActionOnReceivedOffer);
            MessagingCenter.Subscribe<SubmittedQueryOffersViewModel, SubmittedQueryOffer>(this, Constants.MSG_ITEMUPDATED, ItemUpdated);
        }

        public ICommand TakeActionOnReceivedOffer
        {
            get;
            private set;
        }

        public void ActionOnReceivedOffer(SubmittedQueryOffer item)
        {
            Navigation.PushAsync(
                new ReceivedOfferTakeAction(item));
        }

        public void ItemUpdated(SubmittedQueryOffersViewModel model, SubmittedQueryOffer item)
        {
            if (Items != null)
            {
                var targetItem = Items.First((i) => i.Id == item.Id);
                targetItem.OfferPrice = item.OfferPrice;
            }
        }
        public ObservableCollection<SubmittedQueryOffer> Items
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
                        Items = new ObservableCollection<SubmittedQueryOffer>(ait.Result);
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
