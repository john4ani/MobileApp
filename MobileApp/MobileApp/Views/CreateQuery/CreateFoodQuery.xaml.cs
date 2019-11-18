using MobileApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.CreateQuery
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateFoodQuery : ContentPage
	{
		public CreateFoodQuery ()
		{
			InitializeComponent ();
            queryDeliveryAddress.Text = App.GetUserService().GetLoggedInUserAsync().Result.CurrentAddress;

        }

        private async void SubmitQuery_ButtonClicked(object sender, EventArgs e)
        {
            var query = new Query
            {
                Name = queryName.Text,
                Description = queryDescription.Text,
                Category = "Food",
                EventDate = queryDate.Date + queryTime.Time,
                UserId = App.GetUserService().GetLoggedInUserAsync().Result.Id,
                Id = Guid.NewGuid().ToString(),
                NeedsDelivery = queryDelivery.IsChecked,
                DeliveryAddress = queryDeliveryAddress.Text
            };
            await App.GetQueringService().MakeQuery(query);
            await Navigation.PushAsync(new HomePage());
        }

        private void QueryDelivery_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            queryDeliveryAddress.IsVisible = e.Value;            
        }
    }
}