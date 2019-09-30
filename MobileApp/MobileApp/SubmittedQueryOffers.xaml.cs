using MobileApp.Models;
using MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubmittedQueryOffers : ContentPage
	{
		public SubmittedQueryOffers ()
		{
			InitializeComponent ();
		}

        public SubmittedQueryOffers(SubmittedQuery query) : this()
        {
            this.BindingContext = new SubmittedQueryOffersViewModel(query, Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((SubmittedQueryOffersViewModel)this.BindingContext).Load();
        }

        /*     protected void Item_Tapped(object sender, ItemTappedEventArgs e)
             {
                 Navigation.PushAsync(
                     new PlaceBid((AuctionItem)e.Item));    
             }
             */
    }
}