using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.CreateQuery
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectQueryCategory : ContentPage
	{
		public SelectQueryCategory()
		{
			InitializeComponent ();
		}

        private async void OnFoodButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateFoodQuery());
        }

        private async void OnTaxiButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateTaxiQuery());
        }

        private async void OnDrugsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateDrugsQuery());
        }

        private async void OnGroceryButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateGroceryQuery());
        }

        private async void OnP2pButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePearToPearQuery());
        }
    }
}