﻿using MobileApp.Models;
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
            SelectReceivedQuery = new Command<Query>(GoToMakeOfferForReceivedQuery);
            SelectSubmittedQuery = new Command<Query>(GoToSubmittedQueryOffers);
            
            RefreshSubmittedQueries = new Command(LoadSubmittedQueries);
            RefreshReceivedQueries = new Command(LoadReceivedQueries);

            //MessagingCenter.Subscribe<PlaceBidViewModel, AuctionItem>(this, Constants.MSG_ITEMUPDATED, ItemUpdated);
        }

        public ICommand SelectReceivedQuery
        {
            get;
            private set;
        }

        public void GoToMakeOfferForReceivedQuery(Query query)
        {
            Navigation.PushAsync(
                new MakeOfferForReceivedQuery(query));
        }

        public ICommand SelectSubmittedQuery
        {
            get;
            private set;
        }

        public void GoToSubmittedQueryOffers(Query query)
        {
            Navigation.PushAsync(
                new SubmittedQueryOffers(query));
        }

        private ObservableCollection<Query> _submittedQueries;
        public ObservableCollection<Query> SubmittedQueries
        {
            get { return _submittedQueries; }
            set {
                _submittedQueries = value;
                NotifyPropertyChanged("SubmittedQueries");
            }
        }

        private ObservableCollection<Query> _receivedQueries;
        public ObservableCollection<Query> ReceivedQueries
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
                SubmittedQueries = new ObservableCollection<Query>(itemsResult);
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