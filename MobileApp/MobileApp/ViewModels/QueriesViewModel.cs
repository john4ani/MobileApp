using MobileApp.Models;
using MobileApp.Views.ReceivedQueries;
using MobileApp.Views.SubmittedQueries;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class QueriesViewModel : ViewModelBase
    {

        public QueriesViewModel(INavigation navigation) : base(navigation)
        {
            SelectReceivedQuery = new Command<Query>(GoToMakeOfferForReceivedQuery);
            SelectSubmittedQuery = new Command<SubmittedQueryViewModel>(GoToSubmittedQueryOffers);
            
            RefreshSubmittedQueries = new Command(LoadSubmittedQueries);
            RefreshReceivedQueries = new Command(LoadReceivedQueries);

            MessagingCenter.Subscribe<MakeOfferForReceivedQueryViewModel, Query>(this, Constants.MSG_ITEMUPDATED, ItemUpdated);
        }        

        public ICommand RefreshReceivedQueries
        {
            get; private set;
        }

        public ICommand RefreshSubmittedQueries
        {
            get; private set;
        }

        public ICommand SelectReceivedQuery
        {
            get;
            private set;
        }

        public ICommand SelectSubmittedQuery
        {
            get;
            private set;
        }        

        private ObservableCollection<SubmittedQueryViewModel> _submittedQueries;
        public ObservableCollection<SubmittedQueryViewModel> SubmittedQueries
        {
            get { return _submittedQueries; }
            set {
                _submittedQueries = value;
                NotifyPropertyChanged(nameof(SubmittedQueries));
            }
        }

        private ObservableCollection<Query> _receivedQueries;
        public ObservableCollection<Query> ReceivedQueries
        {
            get { return _receivedQueries; }
            set
            {
                _receivedQueries = value;
                NotifyPropertyChanged(nameof(ReceivedQueries));
            }
        }

        public void Load()
        {
            if (_submittedQueries == null)
                LoadSubmittedQueries();
            if (_receivedQueries == null)
                LoadReceivedQueries();
        }

        private void GoToMakeOfferForReceivedQuery(Query query)
        {
            Navigation.PushAsync(
                new MakeOfferForReceivedQuery(query, Navigation));
        }

        private void GoToSubmittedQueryOffers(SubmittedQueryViewModel query)
        {
            Navigation.PushAsync(
                new SubmittedQueryOffers(query, Navigation));
        }

        private void ItemUpdated(MakeOfferForReceivedQueryViewModel arg1, Query arg2)
        {
            var submittedQueryViewModel = SubmittedQueries.Where(q => q.Id == arg2.Id).FirstOrDefault();
            if (submittedQueryViewModel != null)
            {
                submittedQueryViewModel.OffersCount++;
            }
        }

        private async void LoadSubmittedQueries()
        {
            IsLoading = true;
            try
            {
                var itemsResult = await App.GetQueriesService().GetSubmittedQueries();
                var submittedQueries = itemsResult.Select(q => new SubmittedQueryViewModel(q, Navigation) { OffersCount = App.GetQueriesService().GetSubmittedQueryOffers(q.Id).Result.Count() });
                SubmittedQueries = new ObservableCollection<SubmittedQueryViewModel>(submittedQueries);
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

        private async void LoadReceivedQueries()
        {
            IsLoading = true;
            try
            {
                var itemsResult = await App.GetQueriesService().GetReceivedQueries();
                ReceivedQueries = new ObservableCollection<Query>(itemsResult);
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
