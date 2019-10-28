using MobileApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreatePearToPearQuery : ContentPage
	{
		public CreatePearToPearQuery()
		{
			InitializeComponent ();
		}

        private async void SubmitQuery_ButtonClicked(object sender, EventArgs e)
        {
            var query = new Query
            {
                Name = queryGroceryList.Text,
                Description = queryDescription.Text,
                Category = "PearToPear",
                EventDate = queryDate.Date + queryTime.Time,
                UserId = App.GetUserService().GetLoggedInUserAsync().Result.Id,
                Id = Guid.NewGuid().ToString()
            };
            await App.GetQueringService().MakeQuery(query);
            await Navigation.PushAsync(new Queries());
        }
    }
}