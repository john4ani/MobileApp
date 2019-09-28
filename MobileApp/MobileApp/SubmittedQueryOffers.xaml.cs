using MobileApp.Models;
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
            this.BindingContext = new QueryOffersViewModel(query, Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((QueryOffersViewModel)this.BindingContext).Load();
        }

        /*     protected void Item_Tapped(object sender, ItemTappedEventArgs e)
             {
                 Navigation.PushAsync(
                     new PlaceBid((AuctionItem)e.Item));    
             }
             */
    }
}