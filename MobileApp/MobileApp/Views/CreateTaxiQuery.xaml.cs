using MobileApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateTaxiQuery : ContentPage
	{
		public CreateTaxiQuery ()
		{
			InitializeComponent ();
		}

        private async void SubmitQuery_ButtonClicked(object sender, EventArgs e)
        {
            var query = new Query
            {
                Name = queryFrom.Text + " - " + queryTo.Text,
                Description = queryDescription.Text,
                Category = "Taxi",
                EventDate = queryDate.Date + queryTime.Time,
                UserId = App.GetUserService().GetLoggedInUserAsync().Result.Id,
                Id = Guid.NewGuid().ToString()
            };
            await App.GetQueringService().MakeQuery(query);
            await Navigation.PushAsync(new Queries());
        }
    }
}