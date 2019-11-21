
using System;
using MobileApp.Models;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class SubmittedQueryViewModel : ViewModelBase, IQuery
    {
        public SubmittedQueryViewModel(INavigation navigation) : base(navigation)
        {

        }

        public SubmittedQueryViewModel(IQuery query, INavigation navigation):this(navigation)
        {
            Id = query.Id;
            Name = query.Name;
            UserId = query.UserId;
            Category = query.Category;
            Description = query.Description;
            NeedsDelivery = query.NeedsDelivery;
            EventDate = query.EventDate;
        }

        private int _offersCount;
        public int OffersCount
        {
            get { return _offersCount; }
            set
            {
                _offersCount = value;
                NotifyPropertyChanged(nameof(OffersCount));
            }
        }

        public string Category { get; set; }
        public string DeliveryAddress { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public bool NeedsDelivery { get; set; }
        public string UserId { get; set; }
    }
}
