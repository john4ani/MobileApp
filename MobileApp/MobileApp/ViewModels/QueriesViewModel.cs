using MobileApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class QueriesViewModel : ViewModelBase
    {

        public QueriesViewModel(INavigation navigation) : base(navigation)
        {
            SelectReceivedQuery = new Command<ReceivedQuery>(GoToMakeOfferForReceivedQuery);
            SelectSubmittedQuery = new Command<SubmittedQuery>(GoToSubmittedQueryOffers);
            
            RefreshSubmittedQueries = new Command(LoadSubmittedQueries);
            RefreshReceivedQueries = new Command(LoadReceivedQueries);

            //MessagingCenter.Subscribe<PlaceBidViewModel, AuctionItem>(this, Constants.MSG_ITEMUPDATED, ItemUpdated);
        }

        public ICommand SelectReceivedQuery
        {
            get;
            private set;
        }

        public void GoToMakeOfferForReceivedQuery(ReceivedQuery query)
        {
            Navigation.PushAsync(
                new MakeOfferForReceivedQuery(query));
        }

        public ICommand SelectSubmittedQuery
        {
            get;
            private set;
        }

        public void GoToSubmittedQueryOffers(SubmittedQuery query)
        {
            Navigation.PushAsync(
                new SubmittedQueryOffers(query));
        }

        //// command and delegate to move to make offer
        //public ICommand MakeOffer
        //{
        //    get; private set;

        //}

        //public void MakeOfferForQuery(ReceivedQuery item)
        //{
        //    var targetItem = new Query
        //    {
        //        Id = item.Id,
        //        Name = item.Name,
        //        Description = item.Description,
        //        CurrentBid = item.CurrentBid
        //    };

        //    Navigation.PushAsync(new PlaceBid(targetItem));
        //}

        private ObservableCollection<SubmittedQuery> _submittedQueries;
        public ObservableCollection<SubmittedQuery> SubmittedQueries
        {
            get { return _submittedQueries; }
            set {
                _submittedQueries = value;
                NotifyPropertyChanged("SubmittedQueries");
            }
        }

        private ObservableCollection<ReceivedQuery> _receivedQueries;
        public ObservableCollection<ReceivedQuery> ReceivedQueries
        {
            get { return _receivedQueries; }
            set
            {
                _receivedQueries = value;
                NotifyPropertyChanged("ReceivedQueries");
            }
        }

        public void Load()
        {
            if (_submittedQueries == null)
                LoadSubmittedQueries(null);
            if (_receivedQueries == null)
                LoadReceivedQueries(null);
        }

        public ICommand RefreshSubmittedQueries
        {
            get; private set;
        }

        public async void LoadSubmittedQueries(object p)
        {
            IsLoading = true;
            try
            {
                var itemsResult = await App.GetQueringService().GetSubmittedQueries();
                SubmittedQueries = new ObservableCollection<SubmittedQuery>(itemsResult);
            }
            catch (Exception ex)
            {
                //TODO: alert to error
            }
            finally
            {
                IsLoading = false;
            }
        }

        public ICommand RefreshReceivedQueries
        {
            get; private set;
        }

        public async void LoadReceivedQueries(object p)
        {
            IsLoading = true;
            try
            {
                var itemsResult = await App.GetQueringService().GetReceivedQueries();
                ReceivedQueries = new ObservableCollection<ReceivedQuery>(itemsResult);
            }
            catch (Exception ex)
            {
                //TODO: alert to error
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
